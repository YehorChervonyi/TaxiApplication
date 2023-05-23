// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {
    // Set up default authentication header
    if (localStorage.getItem('Bearer'))
    {
        $.ajaxSetup({
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('Bearer')
            }
        });
        
        
    }
    var sec = 0;
    var rand;
});
function logout(){
    localStorage.removeItem('Bearer');
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

nominContainer.addEventListener("change", async ()=>
{
    waitingRouting();
})

async function newOrder(price, name){
    if (nomin._selectedRoute){
        sec =0;
        rand = Math.floor(Math.random() *60);
        console.log(rand);
        $.ajax(
            {
                type:'get',
                url:'/getTariffByName',
                dataType: 'json',
                data:
                    {
                        name: name,
                    },
                success: function (tariff)
                {
                    $.ajax(
                        {
                            type:'get',
                            url:'/getFreeCarsByTariffId',
                            dataType: 'json',
                            data:
                                {
                                    id: tariff[0].id,
                                },
                            success: function (car)
                            {
                                $.ajax({
                                    type: 'get',
                                    url : '/getUserId',
                                    data:
                                        {
                                            token:localStorage.getItem('Bearer'), 
                                        },
                                    success: function (res) {
                                        $.ajax({
                                            type: 'post',
                                            url: '/newOrder',
                                            data: {
                                                userId: res,
                                                driverId: car[0].driverId,
                                                start: nomin._selectedRoute.waypoints[0].name.split(",").reverse().join(),
                                                finish : nomin._selectedRoute.waypoints[nomin._selectedRoute.waypoints.length -1].name.split(",").reverse().join(),
                                                status : 0,
                                                price : price,
                                                timeStart: new Date().toJSON(),
                                            },
                                            success: function (res)
                                            {
                                                waitingForCar();
                                                timer();
                                            },
                                        });    
                                    }
                                })
                            }
                        });
                }
            });

    }
    else {
        window.confirm("Route not selected");
    }

}
function waitingForCar()
{
    var result ='<div class="text-center">'+
        '<div class="spinner-border" role="status">'+
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
        type: 'get',
        url : '/getUserId',
        data:
            {
                token:localStorage.getItem('Bearer'),
            },
        success: function (res){
            $.ajax({
                type: 'post',
                url: '/setStatusToLastUserOrder',
                data:
                    {
                        userId: res,
                        status: -1
                    }
            });
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

function waitingRouting()
{
    if (nomin._selectedRoute){
        getTariffs();
    }
    else
    {
        setTimeout(waitingRouting, 500);
    }
}

function timer()
{
    
    if (sec === rand)
    {
        console.log(sec, rand)
        // result = '<div class="card" style="width: 18rem;">'+
        //     '  <img src="/img/driver/driver.png" class="card-img-top"'+
        //     '  <div class="card-body">'+
        //     '    <h5 class="card-title">Card title</h5>'+
        //     '    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card\'s content.</p>'+
        //     '    <a href="#" class="btn btn-primary">Go somewhere</a>'+
        //     '  </div>'+
        //     '</div>'
        result = '<div class="text-center"><h3>Timer working</h3><br>'+
            '<button onclick="getTariffs(); cancelOrder()" type="button" class="btn btn-danger">Відмінити замовлення</button></div>'
        $('#userPanel').html(result);
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
