namespace FountainOfObjects;

public class CheatCommand: IPlayerCommand
{
    public void Execute()
    {
        string cheat = $"""
                        The map is {Game.GameMap.MapRows} times {Game.GameMap.MapColumns}
                        You are at {Game.GamePlayer.CurrentRoom.RoomRow}, {Game.GamePlayer.CurrentRoom.RoomColumn}
                        The monster is {Game.GameMap.Monster.MonsterLocation.RoomRow}, {Game.GameMap.Monster.MonsterLocation.RoomColumn}
                        The fountain is {Game.GameMap.FountainRoom.RoomRow}, {Game.GameMap.FountainRoom.RoomColumn}
                        """;
        Console.WriteLine(cheat);
    }
}