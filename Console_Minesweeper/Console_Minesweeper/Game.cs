namespace Console_Minesweeper;

public class Game
{
    private bool GameWasWon { get; set; }

    public event EventHandler OnMineUncovered;
    public event EventHandler OnGameWon;
    private bool GameIsOver { get; set; }
    private Board Board{ get; set; }
    private BoardDrawer BoardDrawer { get; set; }
    private PlayerInputHandler PlayerInputHandler { get; set; }
    private SoundHandler SoundHandler { get; set; }
    

    public Game(Board board)
    {
        GameWasWon = false;
        GameIsOver = false;
        Board = board;
        BoardDrawer = new BoardDrawer(Board);
        PlayerInputHandler = new PlayerInputHandler(board);
        SoundHandler = new SoundHandler(this);
        RunTurn();
    }
    
    private void RunTurn()
    {
        while (!GameIsOver)
        {
            BoardDrawer.DrawBoard();
            PlayerInputHandler.AskForPlayerInput();
            ExecuteResult();
        }
        HandleGameEnd();
    }

    private void HandleGameEnd()
    {
        BoardDrawer.DrawBoard();
        if (GameWasWon)
        {
            Console.WriteLine("you won so cool");
            OnGameWon?.Invoke(this, EventArgs.Empty);
        }
            
        else
        {
            Console.WriteLine("booo.");
            OnMineUncovered?.Invoke(this, EventArgs.Empty);
        }
    }

    private void ExecuteResult()
    {
        Console.Beep(440, 400);
        Cell pickedCell = PlayerInputHandler.GetPickedCell();
        pickedCell.IsCovered = false;
        
        CheckForMine(pickedCell);
        CheckForZeroField(pickedCell);
        Console.WriteLine(pickedCell.AdjacentMines);
        CheckForGameWon();
        
        Console.Clear(); 
    }

    private void CheckForMine(Cell pickedCell)
    {
        if (pickedCell.IsMine)
            GameIsOver = true;
    }
    

    private void CheckForZeroField(Cell pickedCell)
    {
        if (pickedCell.AdjacentMines != 0)
            return;
        
        int[,] neighborPositions = new int[8,2]
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
        
        for (int i = 0; i < neighborPositions.GetLength(0); i++)
        {
            int rowToCheck = pickedCell.Row + neighborPositions[i, 0];
            int columnToCheck = pickedCell.Column + neighborPositions[i, 1];

            if (rowToCheck >= 0 && rowToCheck < Board.BoardRows && columnToCheck >= 0 && columnToCheck < Board.BoardColumns)
            {
                if (Board.CellArray[rowToCheck, columnToCheck].AdjacentMines == 0)
                {
                    if (Board.CellArray[rowToCheck, columnToCheck].IsCovered == true)
                    {
                        Board.CellArray[rowToCheck, columnToCheck].IsCovered = false;
                        CheckForZeroField(Board.CellArray[rowToCheck, columnToCheck]);
                    }
                }
                
                if (Board.CellArray[rowToCheck, columnToCheck].AdjacentMines != 0)
                    Board.CellArray[rowToCheck, columnToCheck].IsCovered = false;
            }
        }
    }

    private void CheckForGameWon()
    {
        foreach (Cell cell in Board.CellArray)
        {
            if (cell.IsCovered && !cell.IsMine)
                return;
        }
        GameIsOver = true;
        GameWasWon = true;
    }
}