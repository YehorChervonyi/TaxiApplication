using System.Diagnostics.CodeAnalysis;
using TaxiApplication.DAL.Entities;

namespace Test;

public class Comparator
{
    internal class UserEqualityComparer : IEqualityComparer<User>
    {
        public bool Equals([AllowNull] User x, [AllowNull] User y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.id == y.id
                   && x.name == y.name
                   && x.phone == y.phone
                   && x.login == y.login;
        }

        public int GetHashCode([DisallowNull] User obj)
        {
            return obj.GetHashCode();
        }
    }
    
    internal class CarEqualityComparer : IEqualityComparer<Car>
    {
        public bool Equals([AllowNull] Car x, [AllowNull] Car y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.id == y.id
                   && x.tariffId == y.tariffId
                   && x.driverId == y.driverId
                   && x.plate == y.plate
                   && x.brand == y.brand
                   && x.model == y.model
                   && x.seats == y.seats
                   && x.driver == y.driver
                   && x.tariff == y.tariff;
        }

        public int GetHashCode([DisallowNull] Car obj)
        {
            return obj.GetHashCode();
        }
    }
    
    internal class DriverEqualityComparer : IEqualityComparer<Driver>
    {
        public bool Equals([AllowNull] Driver x, [AllowNull] Driver y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.id == y.id
                   && x.name == y.name
                   && x.surname == y.surname
                   && x.experience == y.experience
                   && x.status == y.status
                   && x.orders == y.orders
                   && x.cars == y.cars;
        }

        public int GetHashCode([DisallowNull] Driver obj)
        {
            return obj.GetHashCode();
        }
    }
    
    internal class TariffEqualityComparer : IEqualityComparer<Tariff>
    {
        public bool Equals([AllowNull] Tariff x, [AllowNull] Tariff y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.id == y.id
                   && x.name == y.name
                   && x.price == y.price
                   && x.fee == y.fee
                   && x.cars == y.cars;
        }

        public int GetHashCode([DisallowNull] Tariff obj)
        {
            return obj.GetHashCode();
        }
    }
    
    internal class OrderEqualityComparer : IEqualityComparer<Order>
    {
        public bool Equals([AllowNull] Order x, [AllowNull] Order y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.id == y.id
                   && x.userId == y.userId
                   && x.driverId == y.driverId
                   && x.start == y.start
                   && x.finish == y.finish
                   && x.status == y.status
                   && x.price == y.price
                   && x.timeStart == y.timeStart
                   && x.timeFinish == y.timeFinish
                   && x.user == y.user
                   && x.driver == y.driver;
        }

        public int GetHashCode([DisallowNull] Order obj)
        {
            return obj.GetHashCode();
        }
    }
    
}