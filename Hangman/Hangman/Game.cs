namespace Hangman;

public class Game
{
    private string Word { get; set; }
    private Player Player { get; set; }
    private int AmountGuessesLeft { get; set; } = 10;
    private char[] _letterChars;
    private bool[] _letterBools;
    private bool _gameIsLost;
    private bool _gameIsWon;

    // -----------------construct a new game -------------------------------------------------------
    public Game()
    {
        DisplayRules();
        Player = CreatePlayer();
        Word = GetWord();
        Console.Clear();
        CreateStatus();
        Console.WriteLine();
    }

    void DisplayRules()
    {
        Console.WriteLine("This is a game of hangman.");
        Console.WriteLine("Guess a secret word by guessing one single letter at a time.");
        Console.WriteLine($"Can you guess the word without guessing wrong {AmountGuessesLeft} times?");
        Console.WriteLine();
    }

    private Player CreatePlayer()
    {
        Player player = new Player();
        return player;
    }

    private string GetWord()
    {
        Hangman.Word word = new Word();
        return word.WordForGame;
    }

    private void CreateStatus()
    {
        Console.WriteLine();
        Console.WriteLine("The word to guess is:  ");
        _letterChars = new char[Word.Length];
        _letterBools = new bool[Word.Length];
        
        int i = 0;
        foreach (char letter in Word)
        {
            Console.Write(" - ");
            _letterChars[i] = letter;
            _letterBools[i] = false;
            i++;
        }
    }

    // --------------------- Rounds -------------------------------------------------------

    public void RunGame()
    {
        do
        {
            Console.WriteLine();
            Console.WriteLine($"You have {AmountGuessesLeft} wrong guesses left.");
            Player.GetCurrentGuess(this);
            UpdateStatus();
            _gameIsWon = CheckIfGameWon();
            CheckIfGameLost();
        } while ((_gameIsLost == false) && (_gameIsWon == false));

        HandleGameEnd();
    }

    private void UpdateStatus()
    {
        bool guessedWrong = true;
        bool guessedCorrect = false;
        Console.WriteLine();
        Console.Write("Word: ");
        int i = 0;
        foreach (char character in _letterChars)
        {
            if (_letterChars[i] == Player.CurrentGuess)
            {
                Console.Write($" {_letterChars[i]} ");
                _letterBools[i] = true;
                guessedWrong = false;
                guessedCorrect = true;
            }

            else if (_letterBools[i] == true)
            {
                Console.Write($" {_letterChars[i]} ");
            }

            else
                Console.Write(" - ");

            i++;
        }

        DisplayInput(guessedWrong, guessedCorrect);
    }

    private void DisplayInput(bool wrong, bool correct)
    {
        if (wrong)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"There is no {Player.CurrentGuess} in the word.");
            Console.ForegroundColor = ConsoleColor.White;

            AmountGuessesLeft--;
        }
        else if (correct)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Player.CurrentGuess} guessed correct.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    // -------------------------game end handling -------------------------------------

    private bool CheckIfGameWon()
    {
        foreach (bool b in _letterBools)
        {
            if (b == false)
                return false;
        }

        return true;
    }

    private void CheckIfGameLost()
    {
        if (AmountGuessesLeft < 1)
        {
            _gameIsLost = true;
        }
        else if (AmountGuessesLeft > 1)
            _gameIsLost = false;
    }

    private void HandleGameEnd()
    {
        Console.WriteLine();

        if (_gameIsWon)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine($"You won!");
            Console.WriteLine($"You guessed the word {Word}");
        }

        if (_gameIsLost)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("You lost.");
            Console.WriteLine("You will never know the word.");
        }
        
        Console.ReadKey();
    }
}