namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Point represents a point on a map.
    /// </summary>
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}
