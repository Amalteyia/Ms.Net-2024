namespace DinoPark.Service.Controllers.Areas.Entities;

public class CreateAreaRequest
{
    public String Name { get; set; }
    public String Discription { get; set; }
    public int DangerLevel { get; set; }
    public int Square { get; set; }
}