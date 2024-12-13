using AutoMapper;
using DinoPark.BL.Users.Entities;
using DinoPark.Service.Controllers.Users.Entities;

namespace DinoPark.Service.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<RegisterUserRequest, CreateUserModel>();
        CreateMap<UserFilter, UserModelFilter>();   
    }
}