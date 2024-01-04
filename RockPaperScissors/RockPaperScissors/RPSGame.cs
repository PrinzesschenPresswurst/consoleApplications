namespace RockPaperScissors;

public class RPSGame
{
    public Player Player1 { get; set; } = new Player("Player 1");
    public Player Player2 { get; set; } = new Player("Player 2");
    public int Player1Wins { get; set; } = 0;
    public int Player2Wins { get; set; }= 0;
    public int Round { get; private set; } = 1;
    
    //---------------------------------------------------------------
    public void RunGame()
    {
        StartGame();
        
        while (true)
        {
            GameRound gameRound = new GameRound(this);
            gameRound.RunRound();
            Round++;
        }
    }
    
    private void StartGame()
    {
        Console.WriteLine("This is a 2 player game of rock paper scissors. Who are our contestants?");
        Console.WriteLine();
        Console.Write("Player 1 what is your name? ");
        Player1.PlayerName = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Player 2 what is your name? ");
        Player2.PlayerName = Console.ReadLine(); 
        Console.WriteLine();
        Console.WriteLine("Well done. If you are ready we can start the game. Press any key");
        Console.ReadKey(true);
    }
}