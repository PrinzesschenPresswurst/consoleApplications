namespace RockPaperScissors;

public class Player
{
    public string PlayerName { get; set; }
    public Choice CurrentChoice { get; private set; }
    public bool HasWon { get; private set; }
    public bool HasLost { get; set; }
    public bool IsDraw { get; private set; }

    public Player(string name)
    {
        PlayerName = name;
    }

    // Methods ------------------------------------------
    public void GetChoice()
    {
        Console.WriteLine($"{PlayerName} make your choice:");
        bool choiceIsValid = false;
        do
        {
            string inputString = Console.ReadLine();
            if (inputString == "rock")
            {
                CurrentChoice = Choice.Rock;
                choiceIsValid = true;
            }

            else if (inputString == "paper")
            {
                CurrentChoice = Choice.Paper;
                choiceIsValid = true;
            }

            else if (inputString == "scissors")
            {
                CurrentChoice = Choice.Scissors;
                choiceIsValid = true;
            }
        } while (choiceIsValid == false);
        
        Console.WriteLine($"You choose {CurrentChoice}");
        DisplayChoice(CurrentChoice);
        Console.ReadKey();
    }

    public void DisplayChoice(Choice choiceToDisplay)
    {
        switch (choiceToDisplay)
        {
            case Choice.Rock:
                DisplayRock();
                break;
            case Choice.Paper:
                DisplayPaper();
                break;
            case Choice.Scissors:
                DisplayScissors();
                break;
        }
    }

    private void DisplayRock()
    {
        Console.WriteLine();
        Console.WriteLine("    _______");
        Console.WriteLine("---'   ____)");
        Console.WriteLine("      (_____)");
        Console.WriteLine("      (_____)");
        Console.WriteLine("      (____)");
        Console.WriteLine("---.__(___)");
        Console.WriteLine();
    }

    private void DisplayScissors()
    {
        Console.WriteLine();
        Console.WriteLine("    ______");
        Console.WriteLine("---'   ____)____");
        Console.WriteLine("           ______)");
        Console.WriteLine("        __________)");
        Console.WriteLine("      (____)");
        Console.WriteLine("---.__(___)");
        Console.WriteLine();  
    }

    private void DisplayPaper()
    {
        Console.WriteLine();
        Console.WriteLine("     _______");
        Console.WriteLine("---'     ____)___");
        Console.WriteLine("           ______)");
        Console.WriteLine("          _______)");
        Console.WriteLine("        _______)");
        Console.WriteLine("---.__________)");
        Console.WriteLine(); 
    }

    // ----------------------------------------------------------
    
    public void HandleOutcome(Choice choiceA, Choice choiceB)
    {
        IsDraw = CheckForDraw(choiceA, choiceB);
        if (IsDraw)
            return;
        HasWon = CheckIfWon(choiceA, choiceB);
        HasLost = CheckIfLost(choiceA, choiceB);
    }

    private bool CheckForDraw(Choice choiceA, Choice choiceB)
    {
        if (choiceA == choiceB)
            return true;
        
        else return false;
    }

    private bool CheckIfWon(Choice choicePlayer1, Choice choicePlayer2)
    {
        return (choicePlayer1, choicePlayer2) switch
        {
            (Choice.Paper, Choice.Rock) => true,
            (Choice.Rock, Choice.Scissors) => true,
            (Choice.Scissors, Choice.Paper) => true,
            _ => false
        };
    }

    private bool CheckIfLost(Choice choicePlayer1, Choice choicePlayer2)
    {
        return (choicePlayer1, choicePlayer2) switch
        {
            (Choice.Rock, Choice.Paper) => true,
            (Choice.Scissors, Choice.Rock) => true,
            (Choice.Paper, Choice.Scissors) => true,
            _ => false
        };
    }

    // Enums -----------------------------------

    public enum Choice
    {
        Rock,
        Paper,
        Scissors
    };
}