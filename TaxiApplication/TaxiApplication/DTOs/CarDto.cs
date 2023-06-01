namespace TaxiApplication.DTOs;

public class CarDto
{
    public int? tariffId { get; set; }
    public int? driverId { get; set; }
    public string plate { get; set; }
    public string brand { get; set; }
    public string model { get; set; }
    public int seats { get; set; }
}