namespace SquareManagement.Repositories
{
    public static class SqlConstants
    {
        public const string InsertPointListCommand = @"INSERT INTO public.pointlists(name) VALUES(@Name)";
    }
}
