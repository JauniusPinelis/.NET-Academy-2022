namespace ReflectionDemo.DiscountStrategies
{
    public class FreeDiscountStrategy : IDiscountStrategy
    {
        public bool Applies(ShopItem shopItem)
        {
            return shopItem.Name == "Free";
        }

        public decimal CalculateDiscount()
        {
            return 1;
        }
    }
}
