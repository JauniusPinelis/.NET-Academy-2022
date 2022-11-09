using Microsoft.AspNetCore.Mvc;
using SquareManagement.Services.Dtos;
using SquareManagement.Services.Services;

namespace SquareManagement.WebApi.Controllers;

[ApiController]
[Route("pointlists")]
public class PointListController : ControllerBase
{
    private readonly PointListService _pointListService;

    public PointListController(PointListService pointListService)
    {
        _pointListService = pointListService;
    }

    public async Task<IActionResult> Create(CreatePointList createPointList)
    {
        await _pointListService.Create(createPointList);

        return StatusCode(201);
    }
}
