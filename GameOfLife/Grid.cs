namespace GameOfLife
{
    public class Grid
    {
        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; set; }
    }
}