namespace Console_Minesweeper;

public class BoardDrawer
{
    private readonly Board _gameBoard;
    public BoardDrawer(Board board)
    {
        _gameBoard = board;
    }
    
    public void DrawBoard()
    {
        string boarder = new String('-',_gameBoard.BoardColumns * 4 +1);
        string buffer = new string(' ', 3);
        char letter = 'A';
        
        Console.Write(buffer + "  ");
        for (int i = 1; i < _gameBoard.BoardColumns +1; i++)
        {
            Console.Write( i + buffer );
        }
        Console.WriteLine();
        Console.WriteLine(buffer + boarder);
       
        
        for (int i = 0; i < _gameBoard.CellArray.GetLength(0); i++)
        {
            Console.Write( letter + "  " );
            letter++;
            
            for (int j = 0; j < _gameBoard.CellArray.GetLength(1); j++)
            {
                Cell currentCell = _gameBoard.CellArray[i, j];
                DrawCell(currentCell);
            }
            Console.Write("|");
            Console.WriteLine();
            Console.WriteLine(buffer + boarder);
        }
    }

    private void DrawCell(Cell currentCell)
    {
        if (currentCell.IsCovered)
        {
            string cover = "\u2592";
            Console.Write(" " + cover+cover+ " ");
        }
        
        if (!currentCell.IsCovered && !currentCell.IsMine)
        {
            Console.Write("| ");
            if (currentCell.AdjacentMines == 0)
            {
                Console.Write(currentCell.AdjacentMines + " ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(currentCell.AdjacentMines + " ");
                Console.ForegroundColor = ConsoleColor.White; 
            }
        }
        
        if (!currentCell.IsCovered && currentCell.IsMine)
        {
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" M ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}