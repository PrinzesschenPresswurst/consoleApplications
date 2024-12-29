namespace Console_Minesweeper;

public class PlayAgainHandler
{
    public bool WantsToPlayAgain { get; private set; }
    
    public PlayAgainHandler()
    {
        PlayAgain();
        HandleOutcome();
    }

    private void HandleOutcome()
    {
        if (!WantsToPlayAgain)
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        if (WantsToPlayAgain)
        {
            //start new game
        }
    }
    
    private void PlayAgain()
    {
        string? answer = "bla";
        Console.WriteLine("Do you want to play again? y/n");
        while (answer != null && !CheckIfAnswerIsValid(answer))
            answer = Console.ReadLine();
    }

    private bool CheckIfAnswerIsValid(string input)
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