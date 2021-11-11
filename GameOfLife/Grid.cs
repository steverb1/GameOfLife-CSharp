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
            Cells[x, y].IsAliveNext = true;
        }

        public void calculateNextGeneration()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Cell currentCell = Cells[x, y];
                    int neighborCount = countNeighbors(x, y);

                    if (neighborCount == 0)
                    {
                        currentCell.IsAliveNext = false;
                    }
                    else if (neighborCount == 1)
                    {
                        currentCell.IsAliveNext = false;
                    }
                    else if (neighborCount == 2)
                    {
                        currentCell.IsAliveNext = true;
                    }
                    else if (neighborCount == 4)
                    {
                        currentCell.IsAliveNext = false;
                    }
                }
            }

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Cell currentCell = Cells[x, y];

                    if (currentCell.Alive != currentCell.IsAliveNext)
                    {
                        currentCell.Alive = currentCell.IsAliveNext;
                    }
                }
            }
        }

        private int countNeighbors(int x, int y)
        {
            int count = 0;

            if (IsAlive(x, y + 1))
            {
                count++;
            }
            if (IsAlive(x - 1, y + 1))
            {
                count++;
            }
            if (IsAlive(x - 1, y))
            {
                count++;
            }
            if (IsAlive(x - 1, y - 1))
            {
                count++;
            }
            if (IsAlive(x, y - 1))
            {
                count++;
            }
            if (IsAlive(x + 1, y - 1))
            {
                count++;
            }
            if (IsAlive(x + 1, y))
            {
                count++;
            }
            if (IsAlive(x + 1, y + 1))
            {
                count++;
            }

            return count;
        }

        private bool IsAlive(int x, int y)
        {
            if (x < 0 || x >= size || y < 0 || y >= size)
            {
                return false;
            }
            return Cells[x, y].Alive;
        }
    }
}