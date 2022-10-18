using ReflectionDemo.Models;

namespace ReflectionDemo.Repositories
{
    public class PointModelRepository
    {
        public async Task<PointModel> Get(int x, int y)
        {
            return new PointModel()
            {

            };
        }

        public Tuple<int, int> UpdatePoints(ref int x, ref int y)
        {
            // performs various modifications
            x = 5;
            y = 10;

            return Tuple.Create(x, y);
        }

        public void UpdatePoints(PointModel pointModel)
        {
            // performs various modifications
            pointModel.X = 5;
            pointModel.Y = 10;
        }

        public Tuple<int, int> GetUpdatedPoints()
        {
            // perform calculation.

            return Tuple.Create(5, 10);
        }
    }
}
