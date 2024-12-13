using AutoMapper;
using DinoPark.BL.Users.Entities;
using DinoPark.DataAccess.Entities;
using DinoPark.DataAccess.Repository;

namespace DinoPark.BL.Users.Managers;

public class UsersManager : IUsersManager
{
    private readonly IRepository<UserEntity> _usersRepository;
    private readonly IMapper _mapper;

    public UsersManager(IRepository<UserEntity> usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public UserModel CreateUser(CreateUserModel model)
    {
        var entity = _mapper.Map<UserEntity>(model);
        try
        {
            entity = _usersRepository.Save(entity);
            return _mapper.Map<UserModel>(entity);
        }
        catch (Exception e)
        {
            throw new ArgumentException("User already exists");
        }
    }

    public void DeleteUser(int userId)
    {
        var entity = _usersRepository.GetById(userId);
        if (entity == null)
        {
            throw new ArgumentException("User not found");
        }
        _usersRepository.Delete(entity);
    }

}