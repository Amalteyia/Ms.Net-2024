namespace DinoPark.Service.Controllers.Users.Entities;

public class UserFilter
{
    public string? UserNamePart { get; set; }
    public string? EmailPart { get; set; }
    public string? PhoneNumberPart { get; set; }
    public int? Role { get; set; }
}