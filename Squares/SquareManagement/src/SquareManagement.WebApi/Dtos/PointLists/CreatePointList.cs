using System.ComponentModel.DataAnnotations;

namespace SquareManagement.WebApi.Dtos.PointLists;

public class CreatePointList
{
    [Required]
    [MinLength(4)]
    public string Name { get; set; } = "";
}
