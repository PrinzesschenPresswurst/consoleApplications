using System.Text;
namespace MapGame;

public class MapHandler
{
    private Player Player { get; set; }
    public char[,] SomeMapArray { get; private set; } = null;
    public BaseMap CurrentMap = new BaseMap();
    
    public MapHandler(Player player)
    {
        Player = player;
        MapLinker.LinkUpMaps();
        InitializeMapFromObject(MapLinker.Forest);
    }
    
    public void InitializeMapFromObject (BaseMap map)
    {
        CurrentMap = map;
        SomeMapArray = new char[map.MapLineCount, map.MapCharCount];
        string[] someMapSplit = map.MapString.Split("\n");
        
        if (someMapSplit.Length != map.MapLineCount)
        {
            throw new InvalidOperationException($"Map rows mismatch. Expected {map.MapLineCount}, but got {someMapSplit.Length}.");
        }
        
        for (int i = 0; i < SomeMapArray.GetLength(0); i++)
        {
            char[] subSplit =  someMapSplit[i].ToCharArray();
            
            for (int j = 0; j < SomeMapArray.GetLength(1); j++)
            {
                SomeMapArray[i, j] = subSplit[j];
            }
        }
        Player.PlayerPosition = map.PlayerStartPos;
    }
    
    private void PlacePlayer()
    {
        SomeMapArray[Player.PlayerPosition[0,0],Player.PlayerPosition[0,1]] = Player.PlayerChar;
    }

    public void DisplayMap()
    {
       PlacePlayer();
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();
    
        for (int i = 0; i < SomeMapArray.GetLength(0); i++)
        {
        
            for (int j = 0; j < SomeMapArray.GetLength(1); j++)
            {
                if (SomeMapArray[i, j] == 'E')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(SomeMapArray[i,j]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                    
                else if (SomeMapArray[i, j] == '1'|| SomeMapArray[i, j] == '2')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('X');
                    Console.ForegroundColor = ConsoleColor.White;
                }

                else
                {
                    Console.Write(SomeMapArray[i,j]);
                }
                
            }
            Console.WriteLine();
        }
        DisplayNarrativeText();
    }

    private void DisplayNarrativeText()
    {
        Console.WriteLine();
        Console.WriteLine(CurrentMap.MapStoryText);
    }
}