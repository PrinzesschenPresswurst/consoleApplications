namespace FountainOfObjects;

public class Room
{
    public int RoomRow { get; set; }
    public int RoomColumn { get; set; }

    public Room(int roomRow, int roomColumn)
    {
        RoomRow = roomRow;
        RoomColumn = roomColumn;
    }

    public bool CheckIfEntrance()
    {
        if (RoomRow == 0 && RoomColumn == 0)
            return true;
        else return false;
    }
    public bool CheckIfFountain()
    {
        if (RoomRow == 0 && RoomColumn == 2)
            return true;
        else return false;
    }
    
    public string GetRoomText()
    {
        if (CheckIfEntrance())
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return "You can see the light. This must be the Cave Entrance.";
        }

        if (CheckIfFountain() && !Game.GamePlayer.HasEnabledFountain)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return "You sense something strange. This must be the Fountain."; 
        }
        
        if (CheckIfFountain() && Game.GamePlayer.HasEnabledFountain)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            return "The fountain is gushing. It is enabled. Time to get out of here."; 
        }
            
        else return "You sense absolutely nothing. A normal room.";
    }
}