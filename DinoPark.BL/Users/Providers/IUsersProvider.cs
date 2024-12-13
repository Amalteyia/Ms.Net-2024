using DinoPark.BL.Users.Entities;

namespace DinoPark.BL.Users.Providers;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetAllUsers(UserModelFilter filter = null);
    UserModel GetUserInfo(int userId);
}