namespace FirstWebApi.Helpers
{
    public static class CalculationHelpers
    {
        public static decimal CalculateDiscount(int price)
        {
            if (price >= 10)
            {
                return 0.10M;
            }

            return 0.05M;
        }
    }
}
