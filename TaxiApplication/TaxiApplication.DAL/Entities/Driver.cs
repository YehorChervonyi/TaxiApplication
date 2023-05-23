namespace TaxiApplication.DAL.Entities;

public class Driver : BaseEntity
{
    public string name { get; set; }
    public string surname { get; set; }
    public int? experience { get; set; }
    public int status { get; set; } = 0;

    public virtual ICollection<Order>? orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<Car>? cars { get; set; } = new HashSet<Car>();
    
}