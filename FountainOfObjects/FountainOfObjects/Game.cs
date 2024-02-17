namespace FountainOfObjects;

public class Game
{
    public static Player GamePlayer { get; set; }
    public static Map GameMap { get; set; }
    
    public Game()
    {
        GameMap = new Map(this);
        GamePlayer = new Player(this);
        GameMap.DisplayMap(this);
    }

    public void RunRound()
    {
        GivePlayerInfo();
        GamePlayer.GetAction();
    }
    public void GivePlayerInfo()
    {
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine($"You are in a room at (row = {GamePlayer.CurrentRoom.RoomRow}, column = {GamePlayer.CurrentRoom.RoomColumn})");
        Console.WriteLine(GamePlayer.CurrentRoom.GetRoomText());
        Console.ForegroundColor = ConsoleColor.White;
    }
}