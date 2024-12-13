using AutoMapper;
using DinoPark.BL.Areas.Entities;
using DinoPark.DataAccess.Entities;
using DinoPark.DataAccess.Repository;

namespace DinoPark.BL.Areas.Managers;

public class AreasManager: IAreasManager
{
    private readonly IRepository<AreaEntity> _areasRepository;
    private readonly IMapper _mapper;

    public AreasManager(IRepository<AreaEntity> areasRepository, IMapper mapper)
    {
        _areasRepository = areasRepository;
        _mapper = mapper;
    }

    public AreaModel CreateArea(CreateAreaModel model)
    {
        var entity = _mapper.Map<AreaEntity>(model);
        try
        {
            entity = _areasRepository.Save(entity);
            return _mapper.Map<AreaModel>(entity);
        }
        catch (Exception e)
        {
            throw new ArgumentException("Area already exists");
        }
    }

    public void DeleteArea(int areaId)
    {
        var entity = _areasRepository.GetById(areaId);
        if (entity == null)
        {
            throw new ArgumentException("Area not found");
        }
        _areasRepository.Delete(entity);
    }
}