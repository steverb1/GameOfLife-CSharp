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
    }
}
