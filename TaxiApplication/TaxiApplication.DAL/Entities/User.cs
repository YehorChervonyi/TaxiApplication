namespace Data.Entities;

public class User : BaseEntity
{
    public string name { get; set; }
    public string? surname { get; set; }
    public string phone { get; set; }
    public string login { get; set; }
    public string password { get; set; }

    public ICollection<Order>? orders { get; set; } = new HashSet<Order>();
}