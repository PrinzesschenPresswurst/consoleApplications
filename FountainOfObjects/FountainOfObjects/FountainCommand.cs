namespace FountainOfObjects;

public class FountainCommand : IPlayerCommand
{
    public void Execute(Player player)
    {
        if (Game.GamePlayer.CurrentRoom.CheckIfFountain() && !Game.GamePlayer.HasEnabledFountain)
        {
            Game.GamePlayer.HasEnabledFountain = true;
            Console.WriteLine("You hear a loud click");
        }
        else if (Game.GamePlayer.CurrentRoom.CheckIfFountain() && Game.GamePlayer.HasEnabledFountain)
            Console.WriteLine("The fountain is already enabled");
    }
}