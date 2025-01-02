namespace MapGame;

public class Player
{
    public char PlayerChar { get; set; } 
    public int[,] PlayerPosition { get; set; } 
    

    public Player()
    {
        PlayerChar = 'i';
        PlayerPosition = new int[,] {
            {2, 4}
        };
    }
}