namespace FountainOfObjects;

public class Map
{
    public int MapRows { get; set; } 
    public int MapColumns { get; set; } 
    public Room StartRoom { get; set; } = new Room(0, 0);
    public Room FountainRoom { get; set; } = new Room(0, 0);
    public Monster Monster { get; set; } = new Monster(0, 0);
    private int[,]? RoomGrid { get; set; }
    private Room[]? RoomArray { get; set; }
    public string MapDisplayString { get; set; } = "";
    private IMapSizeHandler MapSizeHandler { get; set; }
    
    public Map()
    {
       int mapSize = AskMapSize( );
       MapSizeHandler = new FixedMapSizeHandler();
       MapSizeHandler.SetupMap(this, mapSize);
       
       CreateMap();
       
    }
    
    private int AskMapSize()
    {
        Console.WriteLine($"{Game.GamePlayer.PlayerName}, how big should the cave be?");
        Console.WriteLine("small, normal, big?");
        int size;
        
        do
        {
            string? input = Console.ReadLine();
            size = input switch
            {
                "small" => 1,
                "normal" => 2,
                "big" => 3,
                _ => 0
            }; 
        } while (size == 0);
        return size;
    }
    
    private void CreateMap()
    {
        RoomGrid = new int [MapRows, MapColumns];
        RoomArray = new Room[MapRows * MapColumns];
        
        int i = 0;
        for ( int row = 0; row < RoomGrid.GetLength(0); row ++)
        {
            for ( int column = 0; column < RoomGrid.GetLength(1); column++)
            {
                RoomArray[i] = new Room(row,column);
                //Console.WriteLine($"{RoomArray[i].RoomColumn}, {RoomArray[i].RoomRow}");
                i++;
            }
        }
    }

    public void DisplayMap()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(MapDisplayString);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any key to close the map.");
        Console.ReadKey(true);
        Console.Clear();
    }
}