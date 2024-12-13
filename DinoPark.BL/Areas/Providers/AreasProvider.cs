using AutoMapper;
using DinoPark.BL.Areas.Entities;
using DinoPark.DataAccess.Entities;
using DinoPark.DataAccess.Repository;

namespace DinoPark.BL.Areas.Providers;

public class AreasProvider : IAreasProvider
{
    private readonly IRepository<AreaEntity> _areasRepository;
    private readonly IMapper _mapper;
    
    public AreasProvider(IRepository<AreaEntity> areasRepository, IMapper mapper)
    {
        _areasRepository = areasRepository;
        _mapper = mapper;
    }
    public IEnumerable<AreaModel> GetAllAreas(AreaModelFilter filter = null)
    {
        var namePart = filter.NamePart;
        var discriptionPart = filter?.DiscriptionPart;
        var minDangerLevel = filter?.MinDangerLevel;
        var maxDangerLevel = filter?.MaxDangerLevel;
        var minSquare = filter?.MinSquare;
        var maxSquare = filter?.MaxSquare;
        
        var users = _areasRepository.GetAll(u =>
            (namePart == null || u.Name.Contains(namePart)) &&
            (discriptionPart == null || u.Discription.Contains(discriptionPart)) &&
            (minDangerLevel == null || u.DangerLevel >= minDangerLevel) &&
            (maxDangerLevel == null || u.DangerLevel <= maxDangerLevel) &&
            (minSquare == null || u.Square >= minSquare) &&
            (maxSquare == null || u.Square <= maxSquare));
        
        return _mapper.Map<IEnumerable<AreaModel>>(users);
    }

    public AreaModel GetAreaInfo(int areaId)
    {
        var area = _areasRepository.GetById(areaId) 
                   ?? throw new ArgumentException("Area not found");
        
        return _mapper.Map<AreaModel>(area);
    }
}