namespace FisSst.BlazorMaps
{
    /// <summary>
    /// Represents a point with x and y coordinates in pixels.
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
