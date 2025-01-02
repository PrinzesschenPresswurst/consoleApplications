using System.Text;
namespace MapGame;

public class Map
{
    private Player Player { get; set; }
    public char[,] SomeMapArray { get; private set; } 

    public Map(Player player)
    {
        Player = player;
        InitializeMapFromObject(new MapForest());
    }
    
    public void InitializeMapFromObject (BaseMap map)
    {
        SomeMapArray = new char[map.MapLineCount, map.MapCharCount];
        string[] someMapSplit = map.MapString.Split("\n");
        
        if (someMapSplit.Length != map.MapLineCount)
        {
            throw new InvalidOperationException($"Map rows mismatch. Expected {map.MapLineCount}, but got {someMapSplit.Length}.");
        }
        
        for (int i = 0; i < SomeMapArray.GetLength(0); i++)
        {
            char[] subSplit = new char[map.MapCharCount];
            subSplit =  someMapSplit[i].ToCharArray();
            
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
                    Console.ForegroundColor = ConsoleColor.Red;
                if (SomeMapArray[i, j] == 'X')
                    Console.ForegroundColor = ConsoleColor.Blue;
                
                Console.Write(SomeMapArray[i,j]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }
    }
}