namespace SquareManagement.Core.Exceptions
{
    public class PointListNotFoundException : Exception
    {
        public PointListNotFoundException() : base("PointList was not found")
        {

        }
    }
}
