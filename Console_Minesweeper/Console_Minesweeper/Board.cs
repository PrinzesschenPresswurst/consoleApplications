namespace Console_Minesweeper;

public class Board
{
    public int BoardColumns { get; private set; }
    public int BoardRows { get; private set; }
    public Cell[,] CellArray { get; private set; }
    private int MineCount { get; set; }


    public Board(int boardRows, int boardColumns, int mineCount)
    {
        BoardColumns = boardColumns;
        BoardRows = boardRows;
        MineCount = mineCount;
        CellArray = new Cell[boardRows, boardColumns];
        CreateCellArray();
        AddMines();
        CalculateAdjacentMines();
    }

    private void CreateCellArray()
    {
        for (int i = 0; i < CellArray.GetLength(0); i++)
        {
            for (int j = 0; j < CellArray.GetLength(1); j++)
            {
                CellArray[i, j] = new Cell
                {
                    Row = i,
                    Column = j
                };
            }
        }
    }

    private void AddMines()
    {
        if (MineCount > BoardColumns * BoardRows)
        {
            Console.WriteLine("too many mines");
            MineCount = BoardColumns * BoardRows;
        }
            
        for (int i = 0; i < MineCount; i++)
        {
            Random r = new Random();
            int row = r.Next(0, BoardRows);
            int column = r.Next(0, BoardColumns);
            while (CellArray[row, column].IsMine)
            {
                 column = r.Next(0, BoardColumns);
                 row = r.Next(0, BoardRows );
            }
            CellArray[row, column].IsMine = true;
        }
    }
    
    private void CalculateAdjacentMines()
    {
        int[,] neighborPositions = 
        {
            { 1, 0 },
            { -1, 0 },
            { 0, 1 },
            { 0, -1 },
            { -1, -1 },
            { 1, 1 },
            { -1, 1 },
            { 1, -1 }
        };

        foreach (var cell in CellArray)
        {
            int adjacentMineCount = 0;
            for (int i = 0; i < neighborPositions.GetLength(0); i++)
            {
                int rowToCheck = cell.Row + neighborPositions[i, 0];
                int columnToCheck = cell.Column + neighborPositions[i, 1];

                if (rowToCheck >= 0 && rowToCheck < BoardRows && columnToCheck >= 0 && columnToCheck < BoardColumns)
                {
                    if (CellArray[rowToCheck, columnToCheck].IsMine)
                        adjacentMineCount++;
                }
            }
            cell.AdjacentMines = adjacentMineCount;
        }
    }
}