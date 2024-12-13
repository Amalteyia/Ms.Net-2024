namespace DinoPark.Service.Controllers.Areas.Entities;

public class AreaFilter
{
    public String? DiscriptionPart { get; set; }
    public int? MinDangerLevel { get; set; }
    public int? MaxDangerLevel { get; set; }
    public int? MinSquare { get; set; }
    public int? MaxSquare { get; set; }
}