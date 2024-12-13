namespace DinoPark.Service.Controllers.Users.Entities;

public class RegisterUserRequest
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public int Role { get; set; }
}