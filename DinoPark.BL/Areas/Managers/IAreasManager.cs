using DinoPark.BL.Areas.Entities;

namespace DinoPark.BL.Areas.Managers;

public interface IAreasManager
{
    AreaModel CreateArea(CreateAreaModel model);
    void DeleteArea(int areaId);
}