namespace ReflectionDemo.DiscountStrategies
{
    public class TenPercentDiscountStrategy : IDiscountStrategy
    {
        public bool Applies(ShopItem shopItem)
        {
            return shopItem.Quantity >= 10;
        }

        public decimal CalculateDiscount()
        {
            return 0.10M;
        }
    }
}
