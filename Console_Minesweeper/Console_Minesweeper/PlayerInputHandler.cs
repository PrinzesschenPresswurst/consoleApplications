namespace Console_Minesweeper;
using System.Text.RegularExpressions;

public class PlayerInputHandler
{
    private Board GameBoard { get; set; } 
    private readonly List<char> _validChars = new List<char>();
    private int PickedRowIndex { get; set; }
    private int PickedColumnIndex { get; set; }
    public bool WantsToPlayAgain { get; private set; }

    public PlayerInputHandler(Board board)
    {
        GameBoard = board;
        InitializeValidChars();
    }
    
    public Cell GetCellFromPlayerInput()
    {
        Regex letterRe = new Regex(@"([a-zA-Z]+)");
        Regex numberRe = new Regex("([0-9]+)");

        while (true)
        {
            Console.WriteLine("Where do you want to dig? (e.g. a2)");
            string? playerInput = Console.ReadLine();
            
            if (playerInput == null)
                return null;
        
            Match resultLetter = letterRe.Match(playerInput);
            Match resultNumber = numberRe.Match(playerInput);

            if (CheckIfNumberIsValid(resultNumber) && CheckIfCharIsValid(resultLetter))
            {
                break;  
            }
        } 
        Cell pickedCell = GameBoard.CellArray[PickedRowIndex, PickedColumnIndex];
        return pickedCell;
    }
    
    private bool CheckIfNumberIsValid(Match resultNumber)
    {
        if (Int32.TryParse(resultNumber.Value, out int i))
        {
            if (i < GameBoard.BoardRows && i > 0)
            {
                PickedColumnIndex = i-1;
                return true;
            }
        }
        return false;
    }

    private bool CheckIfCharIsValid(Match resultNumber )
    {
        if (!char.TryParse(resultNumber.Value, out char b))
            return false;
        
        foreach (var character in _validChars)
        {
            if (char.TryParse(resultNumber.Value, out char c))
                if (c == character)
                {
                    PickedRowIndex = (char.ToUpper(c) - 64)-1;
                    return true;
                }
        }
        return false;
    }

    private void InitializeValidChars()
    {
        char start = 'a';
        for (int j = 0; j < GameBoard.BoardColumns+1; j++)
        {
            _validChars.Add(start);
            _validChars.Add(char.ToUpper(start));
            start++;
        }
    }
    
    public bool AskIfPlayerWantsToPlayAgain()
    {
        string? answer = "bla";
        Console.WriteLine("Do you want to play again? y/n");
        while (answer != null && !EvaluateAnswer(answer))
            answer = Console.ReadLine();
        
        return WantsToPlayAgain;
    }

    private bool EvaluateAnswer(string input)
    {
        string[] validYesAnswers = ["y", "Y", "yes", "Yes"];
        string[] validNoAnswers = ["n", "N", "no", "No"];
        
        foreach (var answer in validYesAnswers)
        {
            if (input == answer)
            {
                WantsToPlayAgain = true;
                return true;
            }
        }
        foreach (var answer in validNoAnswers)
        {
            if (input == answer)
            {
                WantsToPlayAgain = false;
                return true;
            }
        }
        return false;
    }
}