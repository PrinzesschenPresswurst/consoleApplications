namespace Puzzle;

public class Player
{
    // properties -----------------------------------------------------------------------
    
    public string PlayerName { get; set; }
    public int CurrentMove { get; set; }
    public bool IsValidMove { get; set; }
    
    // constructor -----------------------------------------------------------------------

    public Player()
    {
        PlayerName = AskName();
    }
    
    // methods for constructor ----------------------------------------------------------------

    private string AskName()
    {
        Console.Write("Player name: ");
        return Console.ReadLine();
    }
    
    // methods  -----------------------------------------------------------------------

    public int AskNumber(Game game, Board board)
    {
        string inputString;
        int inputNumber;
        bool isValid;
        Console.Write("Input the number you want to move: ");
        do
        {
            do
            {
                do
                {
                    inputString = Console.ReadLine();
                    if (!Int32.TryParse(inputString, out var res))
                        Console.WriteLine("must be a whole number");
                } while (!Int32.TryParse(inputString, out var result));

                inputNumber = Convert.ToInt32(inputString);
                if (inputNumber < 1 || inputNumber > 8)
                    Console.WriteLine("must be between 1 and 8");
            } while (inputNumber < 1 || inputNumber > 8 );

            board.GetLocations(inputNumber);
            isValid = board.CheckIfValidMove();
            if (!isValid)
                Console.WriteLine("need to pick a number next to the 0");
        } while (!isValid);
        

        return inputNumber;
    }
}