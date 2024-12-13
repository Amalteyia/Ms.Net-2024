using AutoMapper;
using DinoPark.BL.Areas.Entities;
using DinoPark.DataAccess.Entities;

namespace DinoPark.BL.Mapper;

public class AreasBLProfile : Profile
{
    public AreasBLProfile()
    {
        CreateMap<AreaEntity, AreaModel>();
        CreateMap<CreateAreaModel, AreaEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
            .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
            .ForMember(dest => dest.ModificationTime, opt => opt.Ignore());
    }
}