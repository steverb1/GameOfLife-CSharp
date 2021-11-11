using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests.Unit
{
    public class GameOfLifeTests
    {
        [Fact]
        public void CreatingGrid_DimensionsAreCorrect()
        {
            int size = 10;
            Grid grid = new Grid(size);

            grid.Cells.Length.Should().Be(size * size);
        }

        [Fact]
        public void CreatingGrid_AllCellsAreDead()
        {
            int size = 10;
            Grid grid = new Grid(size);

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
            int size = 10;
            Grid grid = new Grid(size);

            grid.SeedCell(0, 0);

            grid.Cells[0, 0].Alive.Should().Be(true);
        }
    }
}
