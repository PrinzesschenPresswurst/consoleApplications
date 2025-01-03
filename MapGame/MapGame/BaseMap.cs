namespace MapGame;

public class BaseMap
{
    public  int[,] PlayerStartPos { get; protected init; } = new int[,] { {5, 5} };
    public int MapLineCount { get; protected init; } = 5;
    public int MapCharCount { get; protected init; } = 5;
    public string MapString { get; protected init; } = "";
    public string MapStoryText = "";
    public BaseMap? MapToGoTo1 { get; set; } = null;
    public BaseMap? MapToGoTo2 { get; set; } = null;
}