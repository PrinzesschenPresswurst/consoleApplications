namespace FountainOfObjects;

public class MapCommand : IPlayerCommand
{
    public void Execute(Player player)
    {
        if (Game.GamePlayer.CurrentRoom.CheckIfEntrance())
        {
            Game.GameMap.DisplayMap();
        }
        else
            Console.WriteLine("It is too dark to see anything.");
    }
}