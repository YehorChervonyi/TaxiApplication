namespace TaxiApplication.BL.Models;

public class OrderModel
{
    public int userId { get; set; }
    public int? driverId { get; set; } 
    public string start { get; set; }
    public string finish { get; set; }
    public int status { get; set; }
    public float price { get; set; }
    public DateTime timeStart { get; set; }
    public DateTime? timeFinish { get; set; }
}