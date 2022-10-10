namespace ReflectionDemo.DiscountStrategies
{
    public interface IDiscountStrategy
    {
        bool Applies(ShopItem shopItem);
        decimal CalculateDiscount();
    }
}