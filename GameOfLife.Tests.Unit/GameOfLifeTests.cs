using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests.Unit
{
    public class GameOfLifeTests
    {
        [Fact]
        public void CreatingGrid_DimensionsAreCorrect()
        {
            Grid grid = new Grid(10);

            grid.Cells.Length.Should().Be(100);
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
    }
}
