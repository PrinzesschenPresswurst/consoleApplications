namespace TicTacToe;

public class Game
{
    private Player Player1 { get; set; }
    private Player Player2 { get; set; }
    
    private static readonly int Fields = 10;
    private bool _gameIsWon;
    private bool _gameEnded;
    private Player _winningPlayer;
    public Symbols [] _inputFieldSymbols { get; private set; }
    
    // constructor and methods -------------------------------------------------------------------------
    public Game()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        DisplayRules();
        Player1 = new Player(1);
        Console.WriteLine($"{Player1.PlayerName} your symbol is {Player1.PlayerSymbol}" );
        Console.WriteLine();
        Player2 = new Player(2);
        Console.WriteLine($"{Player2.PlayerName} your symbol is {Player2.PlayerSymbol}" );
        Console.WriteLine();
        
        CreateBoard();
        Console.Clear();
        DisplayBoard();
        Console.WriteLine();
    }

    private void DisplayRules()
    {
        Console.WriteLine("welcome to TicTacToe");
        Console.WriteLine("each player picks a number on the num pad in turns");
        Console.WriteLine("you win if you have a line.");
        Console.WriteLine("well, you know how tic tac toe works.");
        Console.WriteLine();
    }
    private void CreateBoard()
    {
        _inputFieldSymbols = new Symbols[Fields];
        for (int i = 0; i < Fields; i++)
        {
            _inputFieldSymbols[i] = Symbols._;
        }
        _inputFieldSymbols[0] = Symbols.O;
    }
    
    // Round methods ----------------------------------------------------------------------------

    public void RunGame()
    {
        while (true)
        {
            Player1.AskField(this);
            Console.Clear();
            DisplayBoard();
            Console.WriteLine();
            if (CheckIfWon(Player1))
                break;
            _gameEnded = CheckIfEnd();
            if (CheckIfEnd())
                break;
            
            Player2.AskField(this);
            Console.Clear();
            DisplayBoard();
            Console.WriteLine();
            if (CheckIfWon(Player2))
                break;
            _gameEnded = CheckIfEnd();
            if (_gameEnded)
                break;
        }

        HandleGameEnd();
    }
    
    public void DisplayBoard()
    {
        Console.WriteLine($"  {_inputFieldSymbols[7]}  |  {_inputFieldSymbols[8]}  |  {_inputFieldSymbols[9]}");
        Console.WriteLine("-----+-----+-----");
        Console.WriteLine($"  {_inputFieldSymbols[4]}  |  {_inputFieldSymbols[5]}  |  {_inputFieldSymbols[6]}");
        Console.WriteLine("-----+-----+-----");
        Console.WriteLine($"  {_inputFieldSymbols[1]}  |  {_inputFieldSymbols[2]}  |  {_inputFieldSymbols[3]}");
    }

    public bool CheckIfWon(Player player)
    {
        Symbols symbol = player.PlayerSymbol;
        // horizontals
        if (_inputFieldSymbols[1] == symbol && _inputFieldSymbols[2] == symbol && _inputFieldSymbols[3] == symbol)
            _gameIsWon = true;
        else if (_inputFieldSymbols[4] == symbol && _inputFieldSymbols[5] == symbol && _inputFieldSymbols[6] == symbol)
            _gameIsWon = true;
        else if (_inputFieldSymbols[7] == symbol && _inputFieldSymbols[8] == symbol && _inputFieldSymbols[9] == symbol)
            _gameIsWon = true;
        //verticals
        else if (_inputFieldSymbols[1] == symbol && _inputFieldSymbols[4] == symbol && _inputFieldSymbols[7] == symbol)
            _gameIsWon = true;
        else if (_inputFieldSymbols[2] == symbol && _inputFieldSymbols[5] == symbol && _inputFieldSymbols[8] == symbol)
            _gameIsWon = true;
        else if (_inputFieldSymbols[3] == symbol && _inputFieldSymbols[6] == symbol && _inputFieldSymbols[9] == symbol)
            _gameIsWon = true;
        //diagonals
        else if (_inputFieldSymbols[1] == symbol && _inputFieldSymbols[5] == symbol && _inputFieldSymbols[9] == symbol)
            _gameIsWon = true;
        else if (_inputFieldSymbols[3] == symbol && _inputFieldSymbols[5] == symbol && _inputFieldSymbols[7] == symbol)
            _gameIsWon = true;
        
        if (_gameIsWon)
            _winningPlayer = player;
        return _gameIsWon;
    }

    private bool CheckIfEnd()
    {
        foreach (Symbols symbol in _inputFieldSymbols)
        {
            
            if (symbol == Symbols._)
                return false;
        }
        return true;
    }

    private void HandleGameEnd()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Clear();
        Console.WriteLine("the game is over.");
        Console.WriteLine();
        DisplayBoard();
        Console.WriteLine();
        
        if (_gameIsWon)
        {
            Console.WriteLine($"{_winningPlayer.PlayerName} with symbol {_winningPlayer.PlayerSymbol} won the game");
        }
        else if (_gameEnded)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("It was a draw. Nobody won.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine();
        Console.WriteLine("press any key to exit.");
        Console.ReadKey(true);
    }
    
    // enums ----------------------------------------------------------------------------------

    public enum Symbols
    {
        X, 
        O, 
        _
    };
}