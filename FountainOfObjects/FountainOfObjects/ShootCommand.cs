namespace FountainOfObjects;

public class ShootCommand : IPlayerCommand
{
    private Room RoomToShootAt { get; set; } 

    public void Execute()
    {
        if (!PlayerHasArrows())
        {
            Console.WriteLine("You dont have any arrows left.");
            return;
        }

        if (!Game.GamePlayer.CurrentRoom.CheckIfHasAdjacentMonster())
        {
            Console.WriteLine("There is no monster close. Better save arrows.");
        }

        else if (Game.GamePlayer.CurrentRoom.CheckIfHasAdjacentMonster())
        {
            Game.GamePlayer.ArrowAmount--;
            GetArrowDirection();
            EvaluateShot();
        }
    }

    private void GetArrowDirection()
    {
        int row = 0;
        int column = 0;
        string? arrowDirection;
        Console.WriteLine("You cant see so you have to shoot in the dark - which direction do you want to shoot the arrow?");
        do
        {
            arrowDirection = Console.ReadLine();
        } while (arrowDirection != "east" && arrowDirection != "north" && arrowDirection != "south" &&
                 arrowDirection != "west");

        if (arrowDirection == "east")
        {
            row = Game.GamePlayer.CurrentRoom.RoomRow ;
            column = Game.GamePlayer.CurrentRoom.RoomColumn+1;
        }
        
        else if (arrowDirection == "west")
        {
            row = Game.GamePlayer.CurrentRoom.RoomRow;
            column = Game.GamePlayer.CurrentRoom.RoomColumn-1;
        }
            
        else if (arrowDirection == "north")
        {
            column = Game.GamePlayer.CurrentRoom.RoomColumn;
            row = Game.GamePlayer.CurrentRoom.RoomRow -1;
            
        }
        else if (arrowDirection == "south")
        {
            column = Game.GamePlayer.CurrentRoom.RoomColumn;
            row = Game.GamePlayer.CurrentRoom.RoomRow+1;
        }
        
        RoomToShootAt = new Room(row, column);
    }

    private void EvaluateShot()
    {
        if (RoomToShootAt.RoomColumn == Game.GameMonster.MonsterLocation.RoomColumn &&
            RoomToShootAt.RoomRow == Game.GameMonster.MonsterLocation.RoomRow)
        {
            Console.WriteLine("You hit the monster and hear it die.");
            Game.GameMonster.IsAlive = false;
        }
        else Console.WriteLine("You miss the monster.");
    }

    private bool PlayerHasArrows()
    {
        if (Game.GamePlayer.ArrowAmount > 0)
            return true;
        else return false;
    }
}