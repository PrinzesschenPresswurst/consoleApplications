using System.Text;
namespace MapGame;

public class MapHandler
{
    private Player Player { get; set; }
    public BaseMap CurrentMap = new BaseMap();
    
    public MapHandler(Player player)
    {
        Player = player;
        MapLinker.LinkUpMaps();
        InitializeMap(MapLinker.Forest);
    }
    
    public void InitializeMap (BaseMap map)
    {
        CurrentMap = map;
        Player.PlayerPosition = map.PlayerStartPos;
    }
    
    private void PlacePlayer()
    {
        CurrentMap.MapArray[Player.PlayerPosition[0,0],Player.PlayerPosition[0,1]] = Player.PlayerChar;
    }

    public void DisplayMap()
    {
       PlacePlayer();
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();
    
        for (int i = 0; i < CurrentMap.MapArray.GetLength(0); i++)
        {
        
            for (int j = 0; j < CurrentMap.MapArray.GetLength(1); j++)
            {
                if (CurrentMap.MapArray[i, j] == 'E')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(CurrentMap.MapArray[i,j]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                    
                else if (CurrentMap.MapArray[i, j] == '1'|| CurrentMap.MapArray[i, j] == '2')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('X');
                    Console.ForegroundColor = ConsoleColor.White;
                }

                else
                {
                    Console.Write(CurrentMap.MapArray[i,j]);
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