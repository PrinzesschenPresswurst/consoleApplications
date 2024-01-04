namespace RockPaperScissors;

public class GameRound
{ 
    private RPSGame Game { get; set; }
    
    // constructor
    public GameRound(RPSGame game)
    {
        Game = game;
    }

    public void RunRound()
    {
       DisplayRoundStatus();
       GetChoices();
       DisplayResult();
    }
    
    private void DisplayRoundStatus()
    {
        Console.Clear();
        Console.WriteLine($"Start of Round {Game.Round}");
        Console.WriteLine();
        Console.WriteLine("Current score: ");
        Console.WriteLine($"{Game.Player1.PlayerName} {Game.Player1Wins}");
        Console.WriteLine($"{Game.Player2.PlayerName} {Game.Player2Wins}");
        Console.ReadKey(true);
    }

    private void GetChoices()
    {
        Console.Clear();
        Game.Player1.GetChoice();
        Console.Clear();
        Game.Player2.GetChoice();
    }
    
    private void DisplayResult()
    {
        Console.Clear();
        Console.WriteLine($"Result of round {Game.Round}:");
        Console.WriteLine();
        
        Game.Player1.HandleOutcome(Game.Player1.CurrentChoice, Game.Player2.CurrentChoice);
        if (Game.Player1.IsDraw)
        {
            Console.WriteLine("Its a Draw. Nobody won.");
        }
        
        else if (Game.Player1.HasWon)
        {
            Game.Player1Wins++;
            Console.WriteLine($"{Game.Player1.PlayerName} wins");
        }
            
        else if (Game.Player1.HasWon == false)
        {
            Game.Player2Wins++;
            Console.WriteLine($"{Game.Player2.PlayerName} wins");
        }
        Console.WriteLine();
        
        Console.WriteLine($"----> {Game.Player1.PlayerName} chose {Game.Player1.CurrentChoice}");
        if (Game.Player1.HasWon && !Game.Player1.IsDraw)
            Console.ForegroundColor = ConsoleColor.Green;
        Game.Player1.DisplayChoice(Game.Player1.CurrentChoice);
        Console.ForegroundColor = ConsoleColor.White;
        
        Console.WriteLine($"----> {Game.Player2.PlayerName} chose {Game.Player2.CurrentChoice}");
        if (Game.Player1.HasLost && ! Game.Player1.IsDraw)
            Console.ForegroundColor = ConsoleColor.Green;
        Game.Player2.DisplayChoice(Game.Player2.CurrentChoice);
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}