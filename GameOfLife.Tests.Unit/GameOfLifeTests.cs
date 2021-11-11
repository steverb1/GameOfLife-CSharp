using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests.Unit
{
    public class GameOfLifeTests
    {
        [Fact]
        public void CreatingGrid_DimensionsAreCorrect()
        {
            Grid grid = new Grid(10, 10);

            grid.Width.Should().Be(10);
            grid.Height.Should().Be(9);
        }
    }
}
