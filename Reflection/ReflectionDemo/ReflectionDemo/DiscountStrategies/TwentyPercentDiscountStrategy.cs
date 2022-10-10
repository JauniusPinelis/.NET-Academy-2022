namespace ReflectionDemo.DiscountStrategies
{
    public class TwentyPercentDiscountStrategy : IDiscountStrategy
    {
        public bool Applies(ShopItem shopItem)
        {
            return shopItem.Quantity >= 10;
        }

        public decimal CalculateDiscount()
        {
            return 0.20M;
        }
    }
}
