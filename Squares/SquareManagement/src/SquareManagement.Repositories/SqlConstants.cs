namespace SquareManagement.Repositories
{
    public static class SqlConstants
    {
        public const string InsertPointListCommand = @"INSERT INTO public.point_lists(name) VALUES(@Name)";
    }
}
