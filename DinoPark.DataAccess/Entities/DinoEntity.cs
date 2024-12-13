namespace DinoPark.DataAccess.Entities;

public class DinoEntity : IBaseEntity
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    
    public String Name { get; set; }
    public String Type { get; set; }
    public DateTime BirthdDate { get; set; }
    public DateTime DeathDate { get; set; }
    
    public List<UserEntity> Employees { get; set; }
    public List<AreaEntity> Areas { get; set; }
}