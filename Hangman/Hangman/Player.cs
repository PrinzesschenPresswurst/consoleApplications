namespace Hangman;

public class Player
{
    // properties
    public string PlayerName { get; set; }
    public char CurrentGuess { get; set; }

    // constructor
    public Player()
    {
        PlayerName = GetPlayerName();
    }
    
    // methods -----------------------------------------------------
    public string GetPlayerName()
    {
        Console.Write("Input a name to start the game:  ");
        return Console.ReadLine();
    }
    public char GetCurrentGuess(Game game)
    {
        Console.Write($"{PlayerName}, guess a letter: ");
        string inputString;
        
        do
        {
            inputString = Console.ReadLine();
            if (inputString.Length != 1)
                Console.WriteLine("You can guess only a single character.");
            
        } while (inputString.Length != 1);
        
        CurrentGuess = Convert.ToChar(inputString);
        return CurrentGuess;
    }
}