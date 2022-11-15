namespace SquareManagement.Repositories
{
    public class SqlConstants
    {
        public const string InsertPointListCommand = @"INSERT INTO public.pointlists(name) VALUES(@Name)";
    }
}
