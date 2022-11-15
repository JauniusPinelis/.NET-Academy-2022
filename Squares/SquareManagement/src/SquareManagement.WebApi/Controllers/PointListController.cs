﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SquareManagement.Services.Dtos.Points;
using SquareManagement.Services.Points;

namespace SquareManagement.WebApi.Controllers;

[ApiController]
[Route("pointlists")]
public class PointListController : ControllerBase
{
    private readonly IMediator _mediator;

    public PointListController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[HttpPost]
    //public async Task<IActionResult> Create(CreatePointList createPointList)
    //{
    //    var pointListCreated = await _pointListService.Create(createPointList);

    //    return StatusCode(201, pointListCreated);
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Remove(int id)
    //{
    //    await _pointListService.Remove(id);

    //    return NoContent();
    //}

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
