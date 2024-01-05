using System.Runtime.InteropServices.ComTypes;

namespace TicTacToe;

public class Player
{
    // properties
    public string PlayerName { get; set; }
    public Game.Symbols PlayerSymbol { get; set; }

    // constructor
    public Player(int playerNumber)
    {
        PlayerName = GetPlayerName(playerNumber);
        PlayerSymbol = GetPlayerSymbol(playerNumber);
    }

    // methods needed by constructor -----------------------------------
    private string GetPlayerName(int number)
    {
        Console.Write($"Player {number} name: ");
        return Console.ReadLine();
    }

    private Game.Symbols GetPlayerSymbol(int number)
    {
        if (number == 1)
        {
            return Game.Symbols.X;
        }
        else return Game.Symbols.O;
    }
    
    // methods -------------------------------------------------------------

    public void AskField(Game game)
    {
        int i;
        string inputString;
        Console.WriteLine($"{PlayerName}, pick a field on the num pad.");
        do
        {
            do
            {
                do
                {
                    inputString = Console.ReadLine();
                    if (!UInt32.TryParse(inputString, out var res))
                        Console.WriteLine("must input a whole positive number.");
                } while (!UInt32.TryParse(inputString, out var result));

                i = Convert.ToInt32(inputString);
                if (i < 1 || i > 9)
                    Console.WriteLine("must be between 1 and 9");

            } while (i < 1 || i > 9);
            
            if ((game._inputFieldSymbols[i] != Game.Symbols._))
                Console.WriteLine("field already taken.");
        } while (game._inputFieldSymbols[i] != Game.Symbols._);
        
        game._inputFieldSymbols[i] = PlayerSymbol;
    }
}