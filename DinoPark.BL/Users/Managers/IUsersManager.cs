using DinoPark.BL.Users.Entities;

namespace DinoPark.BL.Users.Managers;

public interface IUsersManager
{
    UserModel CreateUser(CreateUserModel model);
    void DeleteUser(int userId);
}