namespace FirstWebApi.Exceptions
{
    public class NotFoundException : ArgumentException
    {
        public NotFoundException() : base("Not found")
        {

        }
    }
}
