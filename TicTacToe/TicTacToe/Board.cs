namespace TicTacToe;

public class Board
{
    public static Symbols [] _inputFieldSymbols { get; private set; }
    private int Fields { get; set; } = 10;
    
    // constructor ----------------------------------------------------------
    
    public Board()
    {
        _inputFieldSymbols = new Symbols[Fields];
        for (int i = 0; i < Fields; i++)
        {
            _inputFieldSymbols[i] = Symbols._;
        }
        _inputFieldSymbols[0] = Symbols.O;
    }
    
    // methods --------------------------------------------------------------
    
    public void DisplayBoard()
    {
        Console.WriteLine($"  {_inputFieldSymbols[7]}  |  {_inputFieldSymbols[8]}  |  {_inputFieldSymbols[9]}");
        Console.WriteLine("-----+-----+-----");
        Console.WriteLine($"  {_inputFieldSymbols[4]}  |  {_inputFieldSymbols[5]}  |  {_inputFieldSymbols[6]}");
        Console.WriteLine("-----+-----+-----");
        Console.WriteLine($"  {_inputFieldSymbols[1]}  |  {_inputFieldSymbols[2]}  |  {_inputFieldSymbols[3]}");
    }
    
    public bool CheckIfWon(Player player, Game game)
    {
        Symbols symbol = player.PlayerSymbol;

        if (
            // horizontals
            _inputFieldSymbols[1] == symbol && _inputFieldSymbols[2] == symbol && _inputFieldSymbols[3] == symbol ||
            _inputFieldSymbols[4] == symbol && _inputFieldSymbols[5] == symbol && _inputFieldSymbols[6] == symbol ||
            _inputFieldSymbols[7] == symbol && _inputFieldSymbols[8] == symbol && _inputFieldSymbols[9] == symbol ||
            //verticals
            _inputFieldSymbols[1] == symbol && _inputFieldSymbols[4] == symbol && _inputFieldSymbols[7] == symbol ||
            _inputFieldSymbols[2] == symbol && _inputFieldSymbols[5] == symbol && _inputFieldSymbols[8] == symbol ||
            _inputFieldSymbols[3] == symbol && _inputFieldSymbols[6] == symbol && _inputFieldSymbols[9] == symbol ||
            //diagonals
            _inputFieldSymbols[1] == symbol && _inputFieldSymbols[5] == symbol && _inputFieldSymbols[9] == symbol ||
            _inputFieldSymbols[3] == symbol && _inputFieldSymbols[5] == symbol && _inputFieldSymbols[7] == symbol)
        {
            game.GameIsWon = true;
            game.WinningPlayer = player; 
        }
        return game.GameIsWon;
    }
    
    public bool CheckIfEnd()
    {
        foreach (Symbols symbol in _inputFieldSymbols)
        {
            
            if (symbol == Symbols._)
                return false;
        }
        return true;
    }
    
    // enums --------------------------------------------------------------
    
    public enum Symbols
    {
        X, 
        O, 
        _
    };
}