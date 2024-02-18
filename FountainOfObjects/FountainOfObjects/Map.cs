namespace FountainOfObjects;

public class Map
{
    private static readonly int MapRows = 4;
    private static readonly int MapColumns = 4;
    private int[,] RoomGrid { get; set; }= new int [MapRows, MapColumns];
    private Room[] RoomArray { get; set; } = new Room[16];
    
    public Map()
    {
        CreateMap();
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
        string map = """
            
            -----------------------------------------
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
            
            ----------------------------------------- 
            
            """;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(map);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any key to close the map.");
        Console.ReadKey(true);
        Console.Clear();
    }
}