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
        public void LiveCellWithNoNeighbors_Dies()
        {
            grid.SeedCell(0, 0);
            grid.calculateNextGeneration();

            grid.Cells[0, 0].Alive.Should().Be(false);
        }

        [Fact]
        public void LiveCellWithOneNeighbor_Dies()
        {
            grid.SeedCell(2, 1);
            grid.SeedCell(1, 1);
            grid.calculateNextGeneration();

            grid.Cells[2, 1].Alive.Should().Be(false);
        }

        [Fact]
        public void LiveCellWithFourNeighbors_Dies()
        {
            grid.SeedCell(2, 1);
            grid.SeedCell(2, 2);
            grid.SeedCell(1, 2);
            grid.SeedCell(1, 1);
            grid.SeedCell(1, 0);
            grid.calculateNextGeneration();

            grid.Cells[2, 1].Alive.Should().Be(false);
        }

        [Fact]
        public void LiveCellWithFiveNeighbors_Dies()
        {
            grid.SeedCell(2, 1);
            grid.SeedCell(2, 2);
            grid.SeedCell(1, 2);
            grid.SeedCell(1, 1);
            grid.SeedCell(1, 0);
            grid.SeedCell(2, 0);
            grid.calculateNextGeneration();

            grid.Cells[2, 1].Alive.Should().Be(false);
        }

        [Fact]
        public void LiveCellWithTwoNeighbors_Lives()
        {
            grid.SeedCell(2, 1);
            grid.SeedCell(2, 2);
            grid.SeedCell(1, 2);
            grid.calculateNextGeneration();

            grid.Cells[2, 1].Alive.Should().Be(true);
        }

        [Fact]
        public void LiveCellWithThreeNeighbors_Lives()
        {
            grid.SeedCell(2, 1);
            grid.SeedCell(2, 2);
            grid.SeedCell(1, 2);
            grid.SeedCell(1, 1);
            grid.calculateNextGeneration();

            grid.Cells[2, 1].Alive.Should().Be(true);
        }

        [Fact]
        public void DeadCellWithTwoNeighbors_RemainsDead()
        {
            grid.SeedCell(1, 2);
            grid.SeedCell(1, 1);
            grid.calculateNextGeneration();

            grid.Cells[2, 1].Alive.Should().Be(false);
        }

        [Fact]
        public void DeadCellWithThreeNeighbors_Lives()
        {
            grid.SeedCell(2, 2);
            grid.SeedCell(1, 2);
            grid.SeedCell(1, 1);
            grid.calculateNextGeneration();

            grid.Cells[2, 1].Alive.Should().Be(true);
        }
    }
}
