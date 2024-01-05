namespace TicTacToe;

public class Game
{
    private Player Player1 { get; set; }
    private Player Player2 { get; set; }
    private Board GameBoard { get; set; }
    public bool GameIsWon { get; set; }
    private bool GameEnded { get; set; }
    public Player WinningPlayer { get; set; }
    
    
    // constructor and methods -------------------------------------------------------------------------
    public Game()
    {
        DisplayRules();
        CreatePlayers();
        CreateBoard();
    }
    
    private void DisplayRules()
    {
        Console.WriteLine("welcome to TicTacToe");
        Console.WriteLine("each player picks a number on the num pad in turns");
        Console.WriteLine("you win if you have a line.");
        Console.WriteLine("well, you know how tic tac toe works.");
        Console.WriteLine();
    }

    private void CreatePlayers()
    {
        Player1 = new Player(1);
        Console.WriteLine($"{Player1.PlayerName} your symbol is {Player1.PlayerSymbol}" );
        Console.WriteLine();
        Player2 = new Player(2);
        Console.WriteLine($"{Player2.PlayerName} your symbol is {Player2.PlayerSymbol}" );
        Console.WriteLine();
    }

    private void CreateBoard()
    {
        GameBoard = new Board();
        Console.Clear();
        GameBoard.DisplayBoard();
        Console.WriteLine();
    }
    // game methods ----------------------------------------------------------------------------

    public void RunGame()
    {
        while (true)
        {
            RunTurn(Player1);
            if (GameIsWon)
                break;
            if (GameEnded)
                break;
            
            RunTurn(Player2);
            if (GameIsWon)
                break;
            if (GameEnded)
                break;
        }
        HandleGameEnd();
    }

    private void RunTurn(Player player)
    {
        player.AskField(this);
        Console.Clear();
        GameBoard.DisplayBoard();
        Console.WriteLine();
        GameIsWon = GameBoard.CheckIfWon(player, this);
        GameEnded = GameBoard.CheckIfEnd();
    }
    
    // game end methods ----------------------------------------------------------------------------
    
    private void HandleGameEnd()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Clear();
        GameBoard.DisplayBoard();
        Console.WriteLine();
        Console.WriteLine("the game is over.");
        Console.WriteLine();
        
        if (GameIsWon)
        {
            Console.WriteLine($"{WinningPlayer.PlayerName} with symbol {WinningPlayer.PlayerSymbol} won the game");
        }
        else if (GameEnded)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("It was a draw. Nobody won.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine();
        Console.WriteLine("press any key to exit.");
        Console.ReadKey(true);
    }
    
}