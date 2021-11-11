using System;

namespace GameOfLife
{
    public class Grid
    {
        public Cell[,] Cells { get; }

        public Grid(int size)
        {
            Cells = new Cell[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }
        }

        public void SeedCell(int x, int y)
        {
            Cells[x, y].Alive = true;
        }
    }
}