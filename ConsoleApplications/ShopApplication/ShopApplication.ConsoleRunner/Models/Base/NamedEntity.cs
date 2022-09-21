namespace ShopApplication.ConsoleRunner.Models.Base;

public abstract class NamedEntity : Entity
{
    public string Name { get; set; }

    public string Description { get; set; }
}
