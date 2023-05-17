using AutoMapper;
using TaxiApplication.BL.Models;
using TaxiApplication.DTOs;

namespace TaxiApplication.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        
        //Mapping dtos to models
        
        CreateMap<CarDto, CarModel>()
            .ForMember(carModel=>carModel.plate,
                opt=>opt.MapFrom(carDto=>carDto.plate))
            .ForMember(carModel=>carModel.brand,
                opt=>opt.MapFrom(carDto=>carDto.brand))
            .ForMember(carModel=>carModel.model,
                opt=>opt.MapFrom(carDto=>carDto.model))
            .ForMember(carModel=>carModel.seats,
                opt=>opt.MapFrom(carDto=>carDto.seats))
            .ForMember(carModel=>carModel.tariffId,
                opt=>opt.MapFrom(carDto=>carDto.tariffId))
            .ForMember(carModel=>carModel.driverId,
                opt=>opt.MapFrom(carDto=>carDto.driverId));

        CreateMap<DriverDto, DriverModel>()
            .ForMember(driverModel=>driverModel.name,
                opt=>opt.MapFrom(driverDto=>driverDto.name))
            .ForMember(driverModel=>driverModel.surname,
                opt=>opt.MapFrom(driverDto=>driverDto.surname))
            .ForMember(driverModel=>driverModel.experience,
                opt=>opt.MapFrom(driverDto=>driverDto.experience));
        
        CreateMap<OrderDto, OrderModel>()
            .ForMember(orderModel=>orderModel.userId, 
                opt=>opt.MapFrom(orderDto=>orderDto.userId))
            .ForMember(orderModel=>orderModel.start, 
                opt=>opt.MapFrom(orderDto=>orderDto.start))
            .ForMember(orderModel=>orderModel.finish, 
                opt=>opt.MapFrom(orderDto=>orderDto.finish))
            .ForMember(orderModel=>orderModel.status, 
                opt=>opt.MapFrom(orderDto=>orderDto.status))
            .ForMember(orderModel=>orderModel.price, 
                opt=>opt.MapFrom(orderDto=>orderDto.price))
            .ForMember(orderModel=>orderModel.timeStart, 
                opt=>opt.MapFrom(orderDto=>orderDto.timeStart))
            .ForMember(orderModel=>orderModel.timeFinish, 
                opt=>opt.MapFrom(orderDto=>orderDto.timeFinish))
            .ForMember(orderModel=>orderModel.driverId, 
                opt=>opt.MapFrom(orderDto=>orderDto.driverId));

        CreateMap<TariffDto, TariffModel>()
            .ForMember(tariffModel=>tariffModel.name,
                opt=>opt.MapFrom(tariffDto=>tariffDto.name))
            .ForMember(tariffModel=>tariffModel.price,
                opt=>opt.MapFrom(tariffDto=>tariffDto.price))
            .ForMember(tariffModel=>tariffModel.fee,
                opt=>opt.MapFrom(tariffDto=>tariffDto.fee));

        CreateMap<UserDto, UserModel>()
            .ForMember(userModel=>userModel.name
            ,opt=>opt.MapFrom(userDto=>userDto.name))
            .ForMember(userModel=>userModel.surname
                ,opt=>opt.MapFrom(userDto=>userDto.surname))
            .ForMember(userModel=>userModel.phone
                ,opt=>opt.MapFrom(userDto=>userDto.phone))
            .ForMember(userModel=>userModel.login
                ,opt=>opt.MapFrom(userDto=>userDto.login))
            .ForMember(userModel=>userModel.password
                ,opt=>opt.MapFrom(userDto=>userDto.password));
        
        //Mapping models to dtos
        
        CreateMap<CarModel, CarDto>()
            .ForMember(carDto=>carDto.plate,
                opt=>opt.MapFrom(carModel=>carModel.plate))
            .ForMember(carDto=>carDto.brand,
                opt=>opt.MapFrom(carModel=>carModel.brand))
            .ForMember(carDto=>carDto.model,
                opt=>opt.MapFrom(carModel=>carModel.model))
            .ForMember(carDto=>carDto.seats,
                opt=>opt.MapFrom(carModel=>carModel.seats));

        CreateMap<DriverModel, DriverDto>()
            .ForMember(driverDto=>driverDto.name,
                opt=>opt.MapFrom(driverModel=>driverModel.name))
            .ForMember(driverDto=>driverDto.surname,
                opt=>opt.MapFrom(driverModel=>driverModel.surname))
            .ForMember(driverDto=>driverDto.experience,
                opt=>opt.MapFrom(driverModel=>driverModel.experience));
        
        CreateMap<OrderModel, OrderDto>()
            .ForMember(orderDto=>orderDto.userId, 
                opt=>opt.MapFrom(orderModel=>orderModel.userId))
            .ForMember(orderDto=>orderDto.start, 
                opt=>opt.MapFrom(orderModel=>orderModel.start))
            .ForMember(orderDto=>orderDto.finish, 
                opt=>opt.MapFrom(orderModel=>orderModel.finish))
            .ForMember(orderDto=>orderDto.status, 
                opt=>opt.MapFrom(orderModel=>orderModel.status))
            .ForMember(orderDto=>orderDto.price, 
                opt=>opt.MapFrom(orderModel=>orderModel.price))
            .ForMember(orderDto=>orderDto.timeStart, 
                opt=>opt.MapFrom(orderModel=>orderModel.timeStart))
            .ForMember(orderDto=>orderDto.timeFinish, 
                opt=>opt.MapFrom(orderModel=>orderModel.timeFinish));

        CreateMap<TariffModel, TariffDto>()
            .ForMember(tariffDto=>tariffDto.name,
                opt=>opt.MapFrom(tariffModel=>tariffModel.name))
            .ForMember(tariffDto=>tariffDto.price,
                opt=>opt.MapFrom(tariffModel=>tariffModel.price))
            .ForMember(tariffDto=>tariffDto.fee,
                opt=>opt.MapFrom(tariffModel=>tariffModel.fee));
        
        CreateMap<UserModel, UserDto>()
            .ForMember(userDto=>userDto.name
                ,opt=>opt.MapFrom(userModel=>userModel.name))
            .ForMember(userDto=>userDto.surname
                ,opt=>opt.MapFrom(userModel=>userModel.surname))
            .ForMember(userDto=>userDto.phone
                ,opt=>opt.MapFrom(userModel=>userModel.phone))
            .ForMember(userDto=>userDto.login
                ,opt=>opt.MapFrom(userModel=>userModel.login))
            .ForMember(userDto=>userDto.password
                ,opt=>opt.MapFrom(userModel=>userModel.password));
    }
}