using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SquareManagement.Core.Model;
using SquareManagement.Services.Services;
using SquareManagement.WebApi.Dtos.PointLists;

namespace SquareManagement.WebApi.Controllers;

[ApiController]
[Route("pointlists")]
public class PointListController : ControllerBase
{
    private readonly PointListService _pointListService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreatePointList> _pointListValidator;

    public PointListController(PointListService pointListService, IMapper mapper, IValidator<CreatePointList> validator)
    {
        _pointListService = pointListService;
        _mapper = mapper;
        _pointListValidator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePointList createPointList)
    {

        var entity = _mapper.Map<PointListModel>(createPointList);
        var pointListCreated = await _pointListService.Create(entity);

        //return property
        return CreatedAtAction(nameof(Get), new { id = pointListCreated.Id }, pointListCreated);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var pointListEntity = await _pointListService.Get(id);
        return Ok(_mapper.Map<PointList>(pointListEntity));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        await _pointListService.Remove(id);

        return NoContent();
    }

    //[HttpPost("{pointlist}/point")]
    //public async Task<IActionResult> CreatePoint(int pointListId, CreatePoint createPoint)
    //{


    //    // return properly
    //    return StatusCode(201, pointCreated);
    //}
}
