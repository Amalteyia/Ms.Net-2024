namespace DinoPark.BL.Areas.Entities;

public class AreaModelFilter
{
    public String? NamePart { get; set; }
    public String? DiscriptionPart { get; set; }
    public int? MinDangerLevel { get; set; }
    public int? MaxDangerLevel { get; set; }
    public int? MinSquare { get; set; }
    public int? MaxSquare { get; set; }
}