using AutoMapper;
using DinoPark.BL.Users.Entities;
using DinoPark.DataAccess.Entities;

namespace DinoPark.BL.Mapper;

public class UsersBLProfile : Profile
{
    public UsersBLProfile()
    {
        CreateMap<UserEntity, UserModel>();
        
        CreateMap<CreateUserModel, UserEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
            .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
            .ForMember(dest => dest.ModificationTime, opt => opt.Ignore());
    }
}