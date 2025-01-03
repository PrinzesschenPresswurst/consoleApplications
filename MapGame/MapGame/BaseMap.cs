namespace MapGame;

public class BaseMap
{
    public  int[,] PlayerStartPos { get; init; } = new int[,] { {5, 5} };
    public int MapLineCount { get; init; } = 5;
    public int MapCharCount { get; init; } = 5;
    public string MapString { get; init; } = "";
    public string MapStoryText = "";
}