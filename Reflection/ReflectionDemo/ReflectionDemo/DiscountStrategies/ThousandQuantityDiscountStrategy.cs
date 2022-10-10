namespace ReflectionDemo.DiscountStrategies
{
    public class ThousandQuantityDiscountStrategy : IDiscountStrategy
    {
        public bool Applies(ShopItem shopItem)
        {
            return shopItem.Quantity == 1000;
        }

        public decimal CalculateDiscount()
        {
            return 1;
        }
    }
}
