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

                    if (neighborCount == 0 || neighborCount == 1)
                    {
                        currentCell.IsAliveNext = false;
                    }
                    else if (neighborCount == 2)
                    {
                        if (currentCell.Alive)
                        {
                            currentCell.IsAliveNext = true;
                        }
                    }
                    else if (neighborCount == 3)
                    {
                        currentCell.IsAliveNext = true;
                    }
                    else if (neighborCount >= 4)
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

                    currentCell.Alive = currentCell.IsAliveNext;
                }
            }
        }

        private int countNeighbors(int x, int y)
        {
            int count = 0;

            int[,] cellsToCheck = new int[,] {
                {x - 1, y - 1},
                {x - 1, y},
                {x - 1, y + 1},
                {x, y + 1},
                {x + 1, y + 1},
                {x + 1, y},
                {x + 1, y - 1},
                {x, y - 1}
            };

            for (int i = 0; i < cellsToCheck.GetLength(0); i++)
            {
                int xToCheck = cellsToCheck[i, 0];
                int yToCheck = cellsToCheck[i, 1];

                if (IsAlive(xToCheck, yToCheck))
                {
                    count++;
                }
            }

            return count;
        }

        private bool IsAlive(int x, int y)
        {
            if (OffGrid(x, y))
            {
                return false;
            }
            return Cells[x, y].Alive;
        }

        private bool OffGrid(int x, int y)
        {
            return x < 0 || x >= size || y < 0 || y >= size;
        }
    }
}
