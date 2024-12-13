namespace DinoPark.BL.Users.Entities;

public class CreateUserModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public int Role { get; set; }
}