using AutoMapper;
using DinoPark.BL.Areas.Entities;
using DinoPark.Service.Controllers.Areas.Entities;

namespace DinoPark.Service.Mapper;

public class AreasServiceProfile : Profile
{
    public AreasServiceProfile()
    {
        CreateMap<CreateAreaRequest, CreateAreaModel>();
        CreateMap<AreaFilter, AreaModelFilter>();  
    }
}