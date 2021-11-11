using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests.Unit
{
    public class GameOfLifeTests
    {
        Grid grid;
        int size;

        public GameOfLifeTests()
        {
            size = 10;
            grid = new Grid(size);
        }

        [Fact]
        public void CreatingGrid_DimensionsAreCorrect()
        {
            grid.Cells.Length.Should().Be(size * size);
        }

        [Fact]
        public void CreatingGrid_AllCellsAreDead()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid.Cells[i,j].Alive.Should().Be(false);
                }
            }
        }

        [Fact]
        public void InitializeStartingState_SeededCellsAreAlive()
        {
            grid.SeedCell(0, 0);

            grid.Cells[0, 0].Alive.Should().Be(true);
        }

        [Fact]
        public void CellWithNoNeighbors_Dies()
        {
            grid.SeedCell(0, 0);
            grid.calculateNextGeneration();

            grid.Cells[0, 0].Alive.Should().Be(false);
        }

        [Fact]
        public void CellWithOneNeighbor_Dies()
        {
            grid.SeedCell(0, 0);
            grid.SeedCell(1, 0);
            grid.calculateNextGeneration();

            grid.Cells[0, 0].Alive.Should().Be(false);
            grid.Cells[1, 0].Alive.Should().Be(false);
        }
    }
}
