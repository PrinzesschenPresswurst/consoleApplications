namespace MapGame;

public class BaseMap
{
    public  int[,] PlayerStartPos { get; set; } = new int[,] { {5, 15} };
    public  int MapLineCount { get;  set; }
    public  int MapCharCount { get;  set; }

    public string MapString { get; set; } = """
                                            
                                            """;
}