namespace Puzzle;

public class Board
{
    // properties -------------------------------------------------------------

    private static int _fieldSize = 9;
    private int[] NumberFields { get; set; } = new int [_fieldSize]; 
    private int _fieldDistance = (int)Math.Sqrt(_fieldSize);
    private int IndexOfPlayerNumber { get; set; }
    private int IndexOfEmptyTile { get; set; }

    // constructor -------------------------------------------------------------

    public Board()
    {
        CreateBoard();
        ShuffleBoard();
    }

    // constructor methods--------------------------------------------------------

    private void CreateBoard()
    {
        for (int i = 0; i < NumberFields.Length; i++)
        {
            NumberFields[i] = i;

            Console.WriteLine($"{NumberFields[i]} = {i}");
        }
    }

    private void ShuffleBoard()
    {
        Random random = new Random();
        for (int i = 0; i < NumberFields.Length - 1; ++i)
        {
            int r = random.Next(i, NumberFields.Length);
            (NumberFields[r], NumberFields[i]) = (NumberFields[i], NumberFields[r]);
        }
    }

    // methods -------------------------------------------------------------

    public void DisplayBoard()
    {
        Console.WriteLine($"{NumberFields[0]}   {NumberFields[1]}   {NumberFields[2]}");
        Console.WriteLine($"{NumberFields[3]}   {NumberFields[4]}   {NumberFields[5]}");
        Console.WriteLine($"{NumberFields[6]}   {NumberFields[7]}   {NumberFields[8]}");
    }
    
    // move numbers around ------------------------------------------------------

    public void ExecutePlayerMove(int playerNumber, Game game)
    {
       GetLocations(playerNumber);
       HandleResult(game);
    }

    public void GetLocations(int playerNumber)
    {
        foreach (var numberField in NumberFields)
        {
            if (NumberFields[numberField] == playerNumber)
            {
               IndexOfPlayerNumber = numberField;
            }

            if (NumberFields[numberField] == 0)
            {
                IndexOfEmptyTile = numberField;
            }
        }
    }
    
    public bool CheckIfValidMove()
    {
        if ((IndexOfEmptyTile !=2 && IndexOfEmptyTile !=5 &&IndexOfEmptyTile == IndexOfPlayerNumber - 1) ||
            (IndexOfEmptyTile !=3 && IndexOfEmptyTile !=6 && IndexOfEmptyTile == IndexOfPlayerNumber + 1) ||
            (IndexOfEmptyTile == IndexOfPlayerNumber + _fieldDistance) ||
            (IndexOfEmptyTile == IndexOfPlayerNumber - _fieldDistance))
            return true;
        return false;
    }

    private void HandleResult(Game game)
    {
        if (CheckIfValidMove())
        {
            Swap(IndexOfEmptyTile, IndexOfPlayerNumber);
            game.ValidMove = true;
        }
        else game.ValidMove = false;
    }
    
    private void Swap(int a, int b)
    {
        int contentOfTileA = NumberFields[a];
        int contentOfTileB = NumberFields[b];

        NumberFields[a] = contentOfTileB;
        NumberFields[b] = contentOfTileA;
    }
    
    // ---------------------method end game
    
    public bool CheckForGameEnd()
    {
        int compareAgainst = 0;
        foreach (var numberField in  NumberFields)
        {
            if (NumberFields[numberField] != compareAgainst)
                return false;
            compareAgainst = numberField+1;
        }
        return true;
    }
}