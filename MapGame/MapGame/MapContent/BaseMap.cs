namespace MapGame;

public class BaseMap
{
    public  int[,] PlayerStartPos { get; protected init; } = new int[,] { {5, 5} };
    public char[,] MapArray { get;  private set; } = new char[2,2];
    private int MapLineCount { get; set; } = 5;
    private int MapCharCount { get; set; } = 5;
    protected string MapString { get; init; } = "";
    public string MapStoryText = "";
    public BaseMap? MapToGoTo1 { get; protected set; } = null;
    public BaseMap? MapToGoTo2 { get; protected set; } = null;
    
    public virtual void LinkMaps() { }

    public virtual void Interaction() { }

    protected void InitializeMapArray()
    {
        InitializeArraySize();
        MapArray = new char[MapLineCount, MapCharCount];
        string[] mapStringSplitArray = MapString.Split("\n");
        for (int i = 0; i < MapArray.GetLength(0); i++)
        {
            char[] subSplit =  mapStringSplitArray[i].ToCharArray();
            
            for (int j = 0; j < MapArray.GetLength(1); j++)
            {
                MapArray[i, j] = subSplit[j];
            }
        }
    }

    private void InitializeArraySize()
    {
        string[] test = MapString.Split("\n");
        MapCharCount = test[0].Length;
        MapLineCount = test.Length;
    }
}