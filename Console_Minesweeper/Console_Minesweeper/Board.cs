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
        AddMinesWithArray();
        CalculateAdjacentMines();
    }

    private void CreateCellArray()
    {
        for (int row = 0; row < BoardRows; row++)
        {
            for (int column = 0; column < BoardColumns; column++)
            {
                CellArray[row, column] = new Cell(row, column);
            }
        }
    }
    
    private void AddMinesWithArray()
    {
        if (MineCount > BoardColumns * BoardRows)
        {
            Console.WriteLine("too many mines");
            MineCount = BoardColumns * BoardRows;
        }
        
        Random r = new Random();
        List<int[]> positionsToPlaceMines = new List<int[]>();
        foreach (var cell in CellArray)
        {
            positionsToPlaceMines.Add([cell.Row, cell.Column]);
        }
        
        for (int i = 0; i < MineCount; i++)
        {
            int index = r.Next(0, positionsToPlaceMines.Count);
            int[] position = positionsToPlaceMines[index];
            int row = position[0]; 
            int column = position[1]; 
            CellArray[row, column].IsMine = true;
            positionsToPlaceMines.RemoveAt(index);
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