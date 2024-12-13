namespace DinoPark.DataAccess.Entities;

public class UserEntity : IBaseEntity
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }

    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public int Role { get; set; }
    
    public List<DinoEntity> Dinos { get; set; }
}