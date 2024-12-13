using AutoMapper;
using DinoPark.BL.Users.Entities;
using DinoPark.DataAccess.Entities;
using DinoPark.DataAccess.Repository;

namespace DinoPark.BL.Users.Providers;

public class UsersProvider : IUsersProvider
{
     private readonly IRepository<UserEntity> _usersRepository;
    private readonly IMapper _mapper;
    
    public UsersProvider(IRepository<UserEntity> usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserModel> GetAllUsers(UserModelFilter filter = null)
    {
        var userNamePart = filter.UserNamePart;
        var emailPart = filter?.EmailPart;
        var phoneNumberPart = filter?.PhoneNumberPart;
        var role = filter?.Role;
        
        var users = _usersRepository.GetAll(u =>
            (userNamePart == null || u.UserName.Contains(userNamePart)) &&
            (emailPart == null || u.Email.Contains(emailPart)) &&
            (phoneNumberPart == null || u.PhoneNumber.Contains(phoneNumberPart)) &&
            (role == null || u.Role == role));
        
        return _mapper.Map<IEnumerable<UserModel>>(users);
    }

    public UserModel GetUserInfo(int userId)
    {
        var user = _usersRepository.GetById(userId) 
                   ?? throw new ArgumentException("User not found");
        
        return _mapper.Map<UserModel>(user);
    }
}