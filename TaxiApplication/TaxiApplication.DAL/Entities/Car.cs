namespace TaxiApplication.DAL.Entities;

public class Car : BaseEntity
{
    public int? tariffId { get; set; }
    
    public int? driverId { get; set; }
    public string plate { get; set; }
    public string brand { get; set; }
    public string model { get; set; }
    public int seats { get; set; }
    
    public virtual Driver driver { get; set; }
    public virtual Tariff? tariff { get; set; }
    
    
}