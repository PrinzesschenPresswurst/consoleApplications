namespace Console_Minesweeper;

public class Cell
{
    public bool IsMine { get;  set; }
    public bool IsCovered { get; set; } = true;
    public int Row { get; init; }
    public int Column { get; init; }
    public int AdjacentMines { get; set; }

    public Cell(int row, int column)
    {
        Row = row;
        Column = column;
    }
}