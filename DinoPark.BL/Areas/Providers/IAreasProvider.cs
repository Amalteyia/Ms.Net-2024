using DinoPark.BL.Areas.Entities;

namespace DinoPark.BL.Areas.Providers;

public interface IAreasProvider
{
    IEnumerable<AreaModel> GetAllAreas(AreaModelFilter filter = null);
    AreaModel GetAreaInfo(int areaId);
}