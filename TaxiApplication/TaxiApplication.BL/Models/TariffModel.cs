namespace TaxiApplication.BL.Models;

public class TariffModel
{
    public int id { get; set; }
    public string name { get; set; }
    public float  price { get; set; }
    public float fee { get; set; }
}