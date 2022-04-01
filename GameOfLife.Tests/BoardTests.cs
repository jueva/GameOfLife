using Xunit;

namespace GameOfLife.Tests;

public class BoardTests
{
    [Fact]
    public void Ctor_WidthAndHeightProvided_WidthAndHeightAreSetCorrectly()
    {
        var b = new Board(4, 2);
        var cell = b.GetCell(3, 1);
        Assert.NotNull(cell);
    }

    [Fact]
    public void Ctor_WidthAndHeightProvided_AllCellsAreInitialzedAsDead()
    {
        var board = new Board(2, 2);
        for (int x = 0; x < 2; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                AssertCellIsDead(board, x, y);
            }
        }
    }

    [Fact]
    public void Ctor_CellsProvided_WidthAndHeightAreSetCorrectly()
    {
        var board = new Cell[,]
        {
            { new(0), new(1), new(0), new(0) },
            { new(0), new(1), new(0), new(0) },
        };
        var b = new Board(board);
        Assert.Equal(4, b.Width);
        Assert.Equal(2, b.Height);
    }

    [Fact]
    public void GetNeighbours_CellHasNoNeighbours_ResultEmpty()
    {
        var board = new Board(1, 1);
        
        var neighbours = board.GetNeighbours(0, 0);
        
        Assert.Empty(neighbours);
    }

    [Fact]
    public void GetNeighbours_CellHasNeighbours_ResultIsNotEmpty()
    {
        var neighbourCell = new Cell(0);
        var cells = new[,]
        {
            { new(0) },
            { neighbourCell },
        };
        var board = new Board(cells);
        
        var neighbours = board.GetNeighbours(0, 0);
        
        Assert.Collection(neighbours,
            c=> Assert.Same(neighbourCell, c));
    }


    private void AssertCellIsAlive(Board board, int x, int y)
    {
        Assert.True(board.GetCell(x, y).IsAlive);
    }

    private void AssertCellIsDead(Board board, int x, int y)
    {
        Assert.False(board.GetCell(x, y).IsAlive);
    }
}