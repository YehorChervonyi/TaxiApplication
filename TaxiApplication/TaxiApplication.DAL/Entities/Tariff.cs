namespace Data.Entities;

public class Tariff : BaseEntity
{
    public string name { get; set; }
    public float  price { get; set; }
    public float fee { get; set; }
    
    public ICollection<Car>? cars { get; set; } = new HashSet<Car>();
}