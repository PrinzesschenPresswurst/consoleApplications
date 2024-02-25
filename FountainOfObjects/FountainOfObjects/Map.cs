namespace FountainOfObjects;

public class Map
{
    public int MapRows { get; set; } 
    public int MapColumns { get; set; } 
    public Room StartRoom { get; set; } = new Room(0, 0);
    public Room FountainRoom { get; set; } 
    public Monster Monster { get; set; }
    private int[,] RoomGrid { get; set; }
    private Room[] RoomArray { get; set; }
    
    public string MapDisplayString { get; set; }
    
    public Map()
    {
       string mapSize = AskMapSize();
       
       if (mapSize == "small")
       {
            FountainRoom = new Room(0, 2);
            Monster = new Monster(0,3);
            MapRows = 4;
            MapColumns = 4;
       }
       if (mapSize == "normal")
       {
            FountainRoom = new Room(2, 5);
            Monster = new Monster(0, 4);
            MapRows = 6;
            MapColumns = 6;
       } 
       if (mapSize == "big") 
       {
            FountainRoom = new Room(6, 6);
            Monster = new Monster(1, 2);
            MapRows = 8;
            MapColumns = 8; 
       }
       RoomGrid = new int [MapRows, MapColumns];
       RoomArray = new Room[MapRows * MapColumns];
       CreateMap();
       Game.GamePlayer.BackToStart();
    }
    
    private string AskMapSize()
    {
        Console.WriteLine($"{Game.GamePlayer.PlayerName}, how big should the cave be?");
        Console.WriteLine("small, normal, big?");
        int size;
        string input;
        do
        {
            input = Console.ReadLine();
            size = input switch
            {
                "small" => 4,
                "normal" => 6,
                "big" => 8,
                _ => 0
            }; 
        } while (size == 0);
        return input;
    }
    
    private void CreateMap()
    {
        int i = 0;
        for (int row = 0; row < RoomGrid.GetLength(0); row ++)
        {
            for (int column = 0; column < RoomGrid.GetLength(1); column++)
            {
                RoomArray[i] = new Room(row,column);
                //Console.WriteLine($"{RoomArray[i].RoomColumn}, {RoomArray[i].RoomRow}");
                i++;
            }
        }
    }

    public void DisplayMap()
    {
        string mapSmall = """
            
            -----------------------------------------
             * SMALL FOUNTAIN CAVE MAP *
             
            |     |__________________
            |     |     |     |     |  0
            |-----+-----+-----+-----|          COMPASS
            |     |     |     |     |  1          N
            |-----+-----+-----+-----|          W  +  E
            |     |     |     |     |  2          S
            |-----+-----+-----+-----|
            |     |     |     |     |  3
            -------------------------
               0     1     2     3
            
            Magic Word - Oklahoma !!!
            
            ----------------------------------------- 
            
            """;
        string mapNormal = """
            
            -----------------------------------------
             * NORMAL FOUNTAIN CAVE MAP *
             
            |     |______________________________
            |     |     |     |     |     |     |  0
            |-----+-----+-----+-----+-----+-----|          COMPASS
            |     |     |     |     |     |     |  1          N
            |-----+-----+-----+-----+-----+-----|          W  +  E
            |     |     |     |     |     |     |  2          S
            |-----+-----+-----+-----+-----+-----|
            |     |     |     |     |     |     |  3
            |-----+-----+-----+-----+-----+-----|
            |     |     |     |     |     |     |  4
            |-----+-----+-----+-----+-----+-----|
            |     |     |     |     |     |     |  5
            --------------------------------------
               0     1     2     3     4     5
            
            Magic Word - Oklahoma !!!
            
            ----------------------------------------- 
            
            """;
        string mapBig = """
            
            -----------------------------------------
             * BIG FOUNTAIN CAVE MAP *
             
            |     |__________________________________________
            |     |     |     |     |     |     |     |     |  0
            |-----+-----+-----+-----+-----+-----+-----+-----|          COMPASS
            |     |     |     |     |     |     |     |     |  1          N
            |-----+-----+-----+-----+-----+-----+-----+-----|          W  +  E
            |     |     |     |     |     |     |     |     |  2          S
            |-----+-----+-----+-----+-----+-----+-----+-----|
            |     |     |     |     |     |     |     |     |  3
            |-----+-----+-----+-----+-----+-----+-----+-----|
            |     |     |     |     |     |     |     |     |  4
            |-----+-----+-----+-----+-----+-----+-----+-----|
            |     |     |     |     |     |     |     |     |  5
            |-----+-----+-----+-----+-----+-----+-----+-----|
            |     |     |     |     |     |     |     |     |  6
            |-----+-----+-----+-----+-----+-----+-----+-----|
            |     |     |     |     |     |     |     |     |  7
            --------------------------------------------------
               0     1     2     3     4     5     6     7
            
            Magic Word - Oklahoma !!!
            
            ----------------------------------------- 
            
            """;
        Console.ForegroundColor = ConsoleColor.Cyan;
        if (MapRows == 4)
            Console.WriteLine(mapSmall);
        else if (MapRows == 6)
            Console.WriteLine(mapNormal);
        else if (MapRows == 8)
            Console.WriteLine(mapBig);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any key to close the map.");
        Console.ReadKey(true);
        Console.Clear();
    }
}