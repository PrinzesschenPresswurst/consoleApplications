namespace FountainOfObjects;

public class MoveCommand : IPlayerMoveCommand
{
    public void Execute(string direction)
    {
        if (direction == "east" )
        {
            if (Game.GamePlayer.CurrentRoom.RoomColumn < 3)
                Game.GamePlayer.CurrentRoom.RoomColumn += 1;
            else HandleWalls();
        }

        if (direction == "west")
        {
            if (Game.GamePlayer.CurrentRoom.RoomColumn > 0)
                Game.GamePlayer.CurrentRoom.RoomColumn -= 1;
            else HandleWalls();
        }
        
        if (direction == "south")
        {
            if (Game.GamePlayer.CurrentRoom.RoomRow < 3)
                Game.GamePlayer.CurrentRoom.RoomRow += 1;
            else HandleWalls();
        }
        
        if (direction == "north")
        {
            if (Game.GamePlayer.CurrentRoom.CheckIfEntrance() && !Game.GamePlayer.HasEnabledFountain)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You cant abandon your quest yet.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            if (Game.GamePlayer.CurrentRoom.CheckIfEntrance() && Game.GamePlayer.HasEnabledFountain)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You made it.");
                Game.GamePlayer.HasWonGame = true;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (Game.GamePlayer.CurrentRoom.RoomRow > 0)
                Game.GamePlayer.CurrentRoom.RoomRow -= 1;
            else HandleWalls();
        }
    }
    private void HandleWalls()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You bump into a cave wall.");
        Console.ForegroundColor = ConsoleColor.White;
    }
}