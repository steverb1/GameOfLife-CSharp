namespace GameOfLife
{
    public class Grid
    {
        public Cell[,] Cells { get; }

        public Grid(int size)
        {
            Cells = new Cell[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Cells[i, j] = new Cell();
                }
            }
        }

    }
}