namespace DinoPark.BL.Users.Entities;

public class UserModelFilter
{
    public string? UserNamePart { get; set; }
    public string? EmailPart { get; set; }
    public string? PhoneNumberPart { get; set; }
    public int? Role { get; set; }
}