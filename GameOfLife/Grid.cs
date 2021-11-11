using System;

namespace GameOfLife
{
    public class Grid
    {
        public Cell[,] Cells { get; }
        private int size;

        public Grid(int size)
        {
            this.size = size;
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

        public void calculateNextGeneration()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Cell currentCell = Cells[x, y];
                    int neighborCount = countNeighbors(x, y);

                    if (neighborCount == 1)
                    {
                        currentCell.Alive = false;
                    }
                }
            }
        }

        private int countNeighbors(int x, int y)
        {
            return 1;
        }
    }
}