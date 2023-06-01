// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {
    //  default auth header
    var auth;
    if (localStorage.getItem('Bearer'))
    {
        $.ajaxSetup({
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Bearer')
            }
        });
        $.ajax({
            type: 'get',
            url : '/getUserId',
            data:
                {
                    token:localStorage.getItem('Bearer'),
                },
            success: function (res){
                localStorage.setItem("id", res);
            }
        });
        auth = `<a type="button" class="btn btn-outline-primary me-2" onclick="logout()">Logout <i class="bi bi-box-arrow-right"></i></a>`
    }
    else {
        auth = `<a type="button" class="btn btn-outline-primary me-2" href="/Home/LogIn">Login <i class="bi bi-box-arrow-in-left"></i></a>
        <a type="button" class="btn btn-primary" href="/Home/SignIn">Sign-up <i class="bi bi-person-plus"></i></a>`
    }
    $('#auth').html(auth);
    
    var sec = 0;
    var rand;
    var tariffID;
});

function lastOrders()
{
    $.ajax(
        {
            type:'get',
            url:'/getOrdersByUserId',
            dataType: 'json',
            data:{
                id: localStorage.getItem("id")
            },
            success: function (res)
            {
                console.log(res)
                var result = ``;
                if (res.length === 0){
                    result = `<img src="/img/PoroSad.png" class="rounded mx-auto d-block">
                                <h3>Porosad is extremely sad today</h3>`
                }
                document.getElementById('sideBar')
                res.slice(-5).reverse().forEach(function (order)
                {
                 result += `<div class="d-flex justify-content-between align-items-center" >
                    <h5 class="text-start"> <i class="bi bi-dot"></i> ${order.start.split(',').slice(-3)} <br><br> <i class="bi bi-dot"></i> ${order.finish.split(',').slice(-3)} </h5>
                    </div><hr>`
                    // <button class="btn btn-primary"><i class="bi bi-arrow-counterclockwise"></i></button>
                })
                $('#sideBar').html(result)
            }
        });
    
}
function logout(){
    localStorage.removeItem('Bearer');
    localStorage.removeItem("id");
    window.location.href = "/";
}
async function login(){
    var data = {
        login: $('#login').val(),
        password: $('#pass').val()
    }
    $.ajax(
        {
            type:'get',
            url:'/checkLogining',
            dataType: 'json',
            data:data,
            success: function (res)
            {
                if (res)
                {
                    $.ajax(
                        {
                            type:'get',
                            url:'/login',
                            dataType: 'json',
                            data:data,
                            success: function (res)
                            {
                                document.getElementById('login').classList.remove('is-invalid');
                                document.getElementById('pass').classList.remove('is-invalid');
                                localStorage.setItem("Bearer", res);
                                window.location.href = "/";

                            }
                        });
                }
                else
                {
                    document.getElementById('login').classList.add('is-invalid');
                    document.getElementById('pass').classList.add('is-invalid');
                }
            }
        });
}
//For signin
async function regisrt(){
    if (phoneValidation()){
        var data = {
            name: $('#name').val(),
            surname: $('#sur').val(),
            phone: $('#phone').val(),
            login: $('#login').val(),
            password: $('#pass').val()
        }
        $.ajax(
            {
                type:'get',
                url:'/checkPhone',
                dataType: 'json',
                data:data,
                success: function (res)
                {
                    if (res)
                    {
                        document.getElementById('phone').classList.add('is-invalid');
                        return false;
                    }
                    else
                    {
                        document.getElementById('phone').classList.remove('is-invalid');
                        $.ajax(
                            {
                                type:'get',
                                url:'/checkForLogin',
                                dataType: 'json',
                                data:data,
                                success: function (res)
                                {
                                    if (res)
                                    {
                                        document.getElementById('login').classList.add('is-invalid');
                                        return false;
                                    }
                                    else
                                    {
                                        document.getElementById('login').classList.remove('is-invalid');
                                        $.ajax({
                                            type: 'post',
                                            url: '/register',
                                            data: data,
                                            success: function () {
                                                $.ajax(
                                                    {
                                                        type:'get',
                                                        url:'/login',
                                                        dataType: 'json',
                                                        data:data,
                                                        success: function (res)
                                                        {
                                                            localStorage.setItem("Bearer", res);
                                                            window.location.href = "/";

                                                        }
                                                    });
                                            }
                                        });
                                    }
                                }
                            });
                    }
                }
            });
    }
}

function phoneValidation()
{
    var phoneInput = document.getElementById('phone');
    var phoneInputValue = phoneInput.value;
    var digitsOnly = phoneInputValue.replace(/\D/g, '');
    var e164Pattern = /^\+?[1-9]\d{1,14}$/;
    if (!e164Pattern.test(digitsOnly)) {
        phoneInput.classList.add('is-invalid');
        return false;
    }
    phoneInput.classList.remove('is-invalid');
    return true;
}

//For map
var map = L.map('map').setView([49.54686,35.59570], 6);
L.tileLayer('https://cartodb-basemaps-{s}.global.ssl.fastly.net/dark_all/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
}).addTo(map);


var nomin = L.Routing.control({
    geocoder: L.Control.Geocoder.nominatim(),
    showAlternatives: false,
    useZoomParameter: true,
    draggableWaypoints: false,
    routeWhileDragging: true,
    lineOptions: {
        styles: [{color: 'white', opacity: 0.6, weight: 6},]
    }
}).addTo(map);

const nominContainer = nomin.getContainer();

nominContainer.classList.add('dark-theme');
const elements = nominContainer.querySelectorAll('*');
elements.forEach(function (element)
{
    element.classList.add('.dark-theme');
});

nominContainer.childNodes[0].addEventListener("mouseout", async ()=>
{
    waitingRouting();
})



async function newOrder(price, name){
    if (localStorage.getItem('Bearer')) {
        if (nomin._selectedRoute) {
            sec = 0;
            rand = Math.floor(Math.random() * 60);
            console.log(rand);
            $.ajax(
                {
                    type: 'get',
                    url: '/getTariffByName',
                    dataType: 'json',
                    data:
                        {
                            name: name,
                        },
                    success: function (tariff) {
                        tariffID = tariff[0].id;
                        $.ajax(
                            {
                                type: 'get',
                                url: '/getFreeCarsByTariffId',
                                dataType: 'json',
                                data:
                                    {
                                        id: tariff[0].id,
                                    },
                                success: function (car) {
                                    $.ajax({
                                        type: 'post',
                                        url: '/newOrder',
                                        data: {
                                            userId: localStorage.getItem('id'),
                                            driverId: car[0].driverId,
                                            start: nomin._selectedRoute.waypoints[0].name.split(",").reverse().join(),
                                            finish: nomin._selectedRoute.waypoints[nomin._selectedRoute.waypoints.length - 1].name.split(",").reverse().join(),
                                            status: 0,
                                            price: price,
                                            timeStart: new Date().toJSON(),
                                        },
                                        success: function (res) {
                                            waitingForCar();
                                            timer();
                                        },
                                    });
                                }
                            });
                    }
                });

        } else {
            alert("Route not selected");
        }
    }
    else {
        // window.confirm("You are not registered");
        alert("You are not registered");
    }
}
function waitingForCar()
{
    var result ='<div class="text-center">'+
        '<div class="spinner-grow" role="status">'+
        '</div><br>'+
        '<h3 class="visible">Очікуйте, пошук вільного таксі...</h3>'+
        '<h3 id="timersec">0</h3>'+
        '<br>'+
        '<button onclick="getTariffs(); cancelOrder()" type="button" class="btn btn-danger">Відмінити замовлення</button>'+
        '</div>'
    $('#userPanel').html(result);
}
function cancelOrder()
{
    $.ajax({
        type: 'post',
        url: '/setStatusToLastUserOrder',
        data:
            {
                userId: localStorage.getItem('id'),
                status: -1
            }
    });
}

async function getTariffs(){
    if (nomin._selectedRoute){
       await $.ajax(
            {
                type:'get',
                url:'/getAllTariffs',
                dataType: 'json',
                success: function (res)
                {
                    var userPanel = '';
                    res.forEach(function (tariff) {
                        if (nomin._selectedRoute){
                            var price = Math.round(((Number((nomin._selectedRoute.summary.totalDistance)/1000).toFixed(1))*tariff.price).toFixed(1))+tariff.fee;
                            var args = price + ',`'+ tariff.name+'`';
                            userPanel += '<div class="card" style="width: 10vw;">'+
                                '<img  src="/img/cars/'+ tariff.name + '.png" class="card-img-top mx-auto d-block "/>'+
                                '<div class="card-body">'+
                                '</div>'+
                                '<h5 class="card-title">' + tariff.name +'<br>'+ price + ' грн</h5>'+
                                '<button onclick="newOrder('+ args +')" class="orderbtn btn btn-primary mx-1 mb-1">Замовити</button>'+
                                '</div>'+
                                '<br>';
                        }});
                    $('#userPanel').html(userPanel);
                }
            }
        )
    }
}

async function waitingRouting()
{
    if (await nomin._selectedRoute){
        getTariffs();
    }
    else
    {
        setTimeout(waitingRouting, 500);
    }
}

async function timer()
{
    
    if (sec === rand)
    {
        $.ajax({
            type: 'get',
            url: '/getOrdersByUserId',
            data:
                {
                    id: localStorage.getItem('id'),
                },
            success: function (res) {
                var orders = JSON.parse(res)
                $.ajax({
                    type: 'get',
                    url : '/getDriverById',
                    data:
                        {
                            id: orders[orders.length -1].driverId,
                        },
                    success: function (driver) {
                        var parsedDriver = JSON.parse(driver)
                        $.ajax({
                            type: 'get',
                            url: '/getCarByDriverId',
                            data:
                                {
                                    id: parsedDriver.id,
                                },
                            success: function (cars) {
                                const parsedCar = JSON.parse(cars);
                                
                                console.log(parsedCar)
                                console.log(tariffID)
                                var needbleCar = parsedCar.find(function (car)
                                {
                                    return car.tariffId === tariffID;
                                });
                                console.log(needbleCar)
                                result = '<div class="card" style="width: 18rem;">'+
                                    '  <img src="/img/driver/driver.png" class="card-img-top rounded-circle"'+
                                    '  <div class="card-body">'+
                                    '    <h3 class="card-title">'+parsedDriver.name+' '+ parsedDriver.surname +'</h3> <hr>'+
                                    '    <h4 class="card-text">'+ needbleCar.brand +' '+ needbleCar.model + '<br>' + needbleCar.plate + '</h4>'+
                                    '    <button onclick="getTariffs(); cancelOrder()" type="button" class="btn btn-danger">Відмінити замовлення</button>'+
                                    '  </div>'+
                                    '</div>'
                                console.log(sec, rand)
                                $('#userPanel').html(result);
                            }
                        });
                    }
                });
            }
        });
        
        
        
    }
    else
    {
        setTimeout(tick, 1000);
    }
}
function tick()
{
    sec++;
    document.getElementById("timersec").innerHTML = sec;
    timer();
}

function alert(message)
{
    var result = `<div class="alert alert-warning alert-dismissible fade show position-absolute top-0 start-50 translate-middle-x" role="alert">
                   ${message}
                  <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>`
    $('#tooltips').html(result);
}
