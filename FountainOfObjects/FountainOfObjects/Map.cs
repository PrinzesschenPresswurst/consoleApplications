namespace FountainOfObjects;

public class Map
{
    private static int mapRows = 4;
    private static int mapColumns = 4;
    private int[,] RoomGrid = new int [mapRows, mapColumns];
    
    public Room[] RoomArray { get; set; } = new Room[16];
    public Room StartRoom { get; set; }
    
    public Map(Game game)
    {
        CreateMap();
        StartRoom = RoomArray[0];
    }
    public void CreateMap()
    {
        int i = 0;
        for (int row = 0; row < RoomGrid.GetLength(0); row ++)
        {
            for (int column = 0; column < RoomGrid.GetLength(1); column++)
            {
                RoomArray[i] = new Room(row,column);
                //Console.WriteLine($"room {i}: row:{RoomArray[i].RoomRow}, column:{RoomArray[i].RoomColumn}");
                i++;
            }
        }
    }

    public void DisplayMap(Game game)
    {
        string map = """
            
             * FOUNTAIN CAVE MAP *
             
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
              
            """;
        
        Console.WriteLine("You open the map the mysterious man gave you:");
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine(map);
        Console.WriteLine("-----------------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        
        Console.WriteLine("You take in all information as it is dark in the cave.");
        Console.WriteLine("Press any key to enter the cave on your quest to find the fountain.");
        Console.WriteLine($"Good luck, {Game.GamePlayer.Playername}");
        Console.ReadKey(true);
        Console.Clear();
    }
}