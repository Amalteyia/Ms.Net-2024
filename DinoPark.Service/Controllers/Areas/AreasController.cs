using System.Text;
using AutoMapper;
using DinoPark.BL.Areas.Entities;
using DinoPark.BL.Areas.Managers;
using DinoPark.BL.Areas.Providers;
using DinoPark.BL.Users.Entities;
using DinoPark.BL.Users.Managers;
using DinoPark.BL.Users.Providers;
using DinoPark.Service.Controllers.Areas.Entities;
using DinoPark.Service.Controllers.Users.Entities;
using DinoPark.Service.Validator.Areas;
using DinoPark.Service.Validator.Users;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace DinoPark.Service.Controllers.Areas;

[ApiController]
[Route("[controller]")]
public class AreasController : ControllerBase
{
    private readonly IAreasManager _areaManager;
    private readonly IAreasProvider _areasProvider;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    
    public AreasController(IAreasManager areasManager, IAreasProvider areasProvider, IMapper mapper, ILogger logger)
    {
        _areaManager = areasManager;
        _areasProvider = areasProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult Create([FromQuery] CreateAreaRequest request)
    {
        var validationResult = new CreateAreaRequestValidator().Validate(request);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage);
            var stringBuilder = new StringBuilder();
            foreach (var error in errors)
                stringBuilder.AppendLine(error);
            _logger.Error(stringBuilder.ToString());
            return BadRequest(errors);
        }
        
        var createAreaModel = _mapper.Map<CreateAreaModel>(request);
        try
        {
            var areaModel = _areaManager.CreateArea(createAreaModel);
            return Ok(new AreasListResponse()
            {
                Areas = [areaModel]
            });
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetAllAreas()
    {
        var areas = _areasProvider.GetAllAreas();
        return Ok(new AreasListResponse()
        {
            Areas = areas.OrderBy(u => u.Id).ToList()
        });
    }

    [HttpGet]
    [Route("filtered")]
    public IActionResult GetFilteredAreas([FromQuery] UserFilter areaFilter)
    {
        var areaModelFilter = _mapper.Map<AreaModelFilter>(areaFilter);
        var areas = _areasProvider.GetAllAreas(areaModelFilter);
        return Ok(new AreasListResponse()
        {
            Areas = areas.ToList()
        });
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetUserInfo([FromRoute] int id)
    {
        try
        {
            var area = _areasProvider.GetAreaInfo(id);
            return Ok(area);
        }
        catch (ArgumentException e)
        {
            _logger.Error(e.Message);
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    [Route("[action]/{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            _areaManager.DeleteArea(id);
            return Ok("Area deleted successfully");
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return BadRequest(e.Message);
        }
    }

}