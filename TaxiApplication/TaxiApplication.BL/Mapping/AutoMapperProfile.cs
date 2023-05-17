using AutoMapper;
using TaxiApplication.BL.Models;
using TaxiApplication.DAL.Entities;

namespace TaxiApplication.BL.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //Mapping models to entities
        
        CreateMap<CarModel, Car>()
            .ForMember(car => car.plate,
                opt => opt.MapFrom(carModel => carModel.plate))
            .ForMember(car => car.brand,
                opt => opt.MapFrom(carModel => carModel.brand))
            .ForMember(car => car.model,
                opt => opt.MapFrom(carModel => carModel.model))
            .ForMember(car => car.seats,
                opt => opt.MapFrom(carModel => carModel.seats))
            .ForMember(car => car.tariffId,
                opt => opt.MapFrom(carModel => carModel.tariffId))
            .ForMember(car => car.driverId,
                opt => opt.MapFrom(carModel => carModel.driverId));

        CreateMap<DriverModel, Driver>()
            .ForMember(driver => driver.name,
                opt => opt.MapFrom(driverModel => driverModel.name))
            .ForMember(driver => driver.surname,
                opt => opt.MapFrom(driverModel => driverModel.surname))
            .ForMember(driver => driver.experience,
                opt => opt.MapFrom(driverModel => driverModel.experience));
        
        CreateMap<OrderModel, Order>()
            .ForMember(order => order.start,
                opt => opt.MapFrom(orderModel => orderModel.start))
            .ForMember(order => order.finish,
                opt => opt.MapFrom(orderModel => orderModel.finish))
            .ForMember(order => order.status,
                opt => opt.MapFrom(orderModel => orderModel.status))
            .ForMember(order => order.price,
                opt => opt.MapFrom(orderModel => orderModel.price))
            .ForMember(order => order.timeStart,
                opt => opt.MapFrom(orderModel => orderModel.timeStart))
            .ForMember(order => order.timeFinish,
                opt => opt.MapFrom(orderModel => orderModel.timeFinish))
            .ForMember(order => order.driverId,
                opt => opt.MapFrom(orderModel => orderModel.driverId));
        
        CreateMap<TariffModel, Tariff>()
            .ForMember(tariff=>tariff.name,
                opt=>opt.MapFrom(tariffModel=>tariffModel.name))
            .ForMember(tariff=>tariff.price,
                opt=>opt.MapFrom(tariffModel=>tariffModel.price))
            .ForMember(tariff=>tariff.fee,
                opt=>opt.MapFrom(tariffModel=>tariffModel.fee));

        CreateMap<UserModel, User>()
            .ForMember(user=>user.name,
                opt=>opt.MapFrom(userModel=>userModel.name))
            .ForMember(user=>user.surname,
                opt=>opt.MapFrom(userModel=>userModel.surname))
            .ForMember(user=>user.phone,
                opt=>opt.MapFrom(userModel=>userModel.phone))
            .ForMember(user=>user.login,
                opt=>opt.MapFrom(userModel=>userModel.login))
            .ForMember(user=>user.password,
                opt=>opt.MapFrom(userModel=>userModel.password));
        
        //Mapping entities to models

        CreateMap<Car, CarModel>()
            .ForMember(carModel => carModel.plate,
                opt => opt.MapFrom(car => car.plate))
            .ForMember(carModel => carModel.brand,
                opt => opt.MapFrom(car => car.brand))
            .ForMember(carModel => carModel.model,
                opt => opt.MapFrom(car => car.model))
            .ForMember(carModel => carModel.seats,
                opt => opt.MapFrom(car => car.seats));

        CreateMap<Driver, DriverModel>()
            .ForMember(driverModel => driverModel.name,
                opt => opt.MapFrom(driver => driver.name))
            .ForMember(driverModel => driverModel.surname,
                opt => opt.MapFrom(driver => driver.surname))
            .ForMember(driverModel => driverModel.experience,
                opt => opt.MapFrom(driver => driver.experience));
        
        CreateMap<Order, OrderModel>()
            .ForMember(orderModel => orderModel.start,
                opt => opt.MapFrom(order => order.start))
            .ForMember(orderModel => orderModel.finish,
                opt => opt.MapFrom(order => order.finish))
            .ForMember(orderModel => orderModel.status,
                opt => opt.MapFrom(order => order.status))
            .ForMember(orderModel => orderModel.price,
                opt => opt.MapFrom(order => order.price))
            .ForMember(orderModel => orderModel.timeStart,
                opt => opt.MapFrom(order => order.timeStart))
            .ForMember(orderModel => orderModel.timeFinish,
                opt => opt.MapFrom(order => order.timeFinish));
            
        CreateMap<Tariff, TariffModel>()
            .ForMember(tariffModel=>tariffModel.name,
                opt=>opt.MapFrom(tariff=>tariff.name))
            .ForMember(tariffModel=>tariffModel.price,
                opt=>opt.MapFrom(tariff=>tariff.price))
            .ForMember(tariffModel=>tariffModel.fee,
                opt=>opt.MapFrom(tariff=>tariff.fee));
        
        CreateMap<User, UserModel>()
            .ForMember(userModel=>userModel.name,
                opt=>opt.MapFrom(user=>user.name))
            .ForMember(userModel=>userModel.surname,
                opt=>opt.MapFrom(user=>user.surname))
            .ForMember(userModel=>userModel.phone,
                opt=>opt.MapFrom(user=>user.phone))
            .ForMember(userModel=>userModel.login,
                opt=>opt.MapFrom(user=>user.login))
            .ForMember(userModel=>userModel.password,
                opt=>opt.MapFrom(user=>user.password));
    }
}