namespace DinoPark.BL.Areas.Entities;

public class AreaModel
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    
    public String Name { get; set; }
    public String Discription { get; set; }
    public int DangerLevel { get; set; }
    public int Square { get; set; }
}