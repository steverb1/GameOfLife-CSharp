namespace GameOfLife
{
    public class Grid
    {
        public Cell[,] Cells { get; }

        public Grid(int size)
        {
            Cells = new Cell[size, size];
        }

    }
}