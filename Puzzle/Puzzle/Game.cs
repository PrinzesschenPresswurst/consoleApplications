namespace Puzzle;

public class Game
{
    // properties --------------------------------------------------------------------------
    private Player Player { get; set; }
    private Board Board { get; set; }
    public bool GameHasEnded { get; set; }
    private int TurnAmount { get; set; }= 0;
    public bool ValidMove = true;

    // constructor --------------------------------------------------------------------------
    public Game()
    {
        DisplayWelcome();
        Player = new Player();
        Board = new Board();
        Console.Clear();
    }

    private void DisplayWelcome()
    {
        Console.WriteLine("This is a puzzle game.");
        Console.WriteLine("Bring the numbers into correct order from 0-1.");
        Console.WriteLine("You can swap everything with the 0.");
        Console.WriteLine();
    }

    // run game --------------------------------------------------------------------------
    public void RunGame()
    {
        while (true)
        {
            DisplayState();
            MakeMove();

            GameHasEnded = Board.CheckForGameEnd();
            if (GameHasEnded)
                break;
            
            if (ValidMove) 
                TurnAmount++;   
            
            Console.Clear();
        }

        HandleEnd();
    }

    private void DisplayState()
    {
        Board.DisplayBoard();
        Console.WriteLine();
        Console.WriteLine($"Moves taken: {TurnAmount}");
    }

    private void MakeMove()
    {
        if (!ValidMove)
            Console.WriteLine("You can only swap positions with the 0");
            
        int currentMove = Player.AskNumber(this,  Board);
        Board.ExecutePlayerMove(currentMove, this);
    }

    private void HandleEnd()
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine("You win!");
        Console.ReadKey();
    }
}