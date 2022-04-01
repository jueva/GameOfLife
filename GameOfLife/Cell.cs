namespace GameOfLife;

public class Cell
{
    public Cell(int state )
    {
        State = (CellState)state;
    }
    public CellState State { get; set; }
    public bool IsAlive => State == CellState.Alive;
}