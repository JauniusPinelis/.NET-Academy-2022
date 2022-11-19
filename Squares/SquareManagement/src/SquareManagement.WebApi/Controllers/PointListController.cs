using MediatR;
using Microsoft.AspNetCore.Mvc;
using SquareManagement.Services.Dtos.PointLists;
using SquareManagement.Services.Dtos.Points;
using SquareManagement.Services.Points;
using SquareManagement.Services.Services;

namespace SquareManagement.WebApi.Controllers;

[ApiController]
[Route("pointlists")]
public class PointListController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly PointListService _pointListService;

    public PointListController(IMediator mediator, PointListService pointListService)
    {
        _mediator = mediator;
        _pointListService = pointListService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePointList createPointList)
    {
        var pointListCreated = await _pointListService.Create(createPointList);

        return StatusCode(201, pointListCreated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        await _pointListService.Remove(id);

        return NoContent();
    }

    [HttpPost("{pointlist}/point")]
    public async Task<IActionResult> CreatePoint(int pointListId, CreatePoint createPoint)
    {
        var pointCreated = await _mediator.Send(new CreatePointCommand
        {
            PointListId = pointListId,
            CreatePoint = createPoint
        });

        return StatusCode(201, pointCreated);
    }
}
