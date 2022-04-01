using System.ComponentModel;

namespace GameOfLife;

public class Board
{
    public int Height { get; }
    public int Width { get; }

    private Cell[,] Cells;

    public Board(int width, int height)
    {
        Height = height;
        Width = width;
        Cells = new Cell[width, height];
        Init();
    }

    private void Init()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Cells[x, y] = new Cell(0);
            }
        }
    }

    public Board(Cell[,] cells)
    {
        Cells = cells;
        Height = cells.GetLength(0);
        Width = cells.GetLength(1);
    }

    public Cell GetCell(int x, int y)
    {
        return Cells[x, y];
    }
    
    public IEnumerable<Cell> GetNeighbours(int x, int y)
    {
        yield break;
    }

    public int GetAliveNeighboursCount(int x, int y)
    {
        return GetNeighbours(x, y).Count(i => i.IsAlive);
    }

    public void Resize(bool growLeft, bool growUp, bool growRight, bool growDown)
    {
    }
}