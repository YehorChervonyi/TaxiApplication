namespace Data.Entities;

public class Driver : BaseEntity
{
    public string name { get; set; }
    public string surname { get; set; }
    public int? experience { get; set; }
    
    public int? carId { get; set; }

    public ICollection<Order>? orders { get; set; } = new HashSet<Order>();
    public ICollection<Car>? cars { get; set; } = new HashSet<Car>();
    
}