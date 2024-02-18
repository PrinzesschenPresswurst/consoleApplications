﻿namespace FountainOfObjects;

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

    public bool CheckIfHasMonster()
    {
        if (RoomColumn == Game.GameMonster.MonsterLocation.RoomColumn &&
            RoomRow == Game.GameMonster.MonsterLocation.RoomRow)
            return true;
        else return false;
    }

    private bool CheckIfHasAdjacentMonster()
    {
        if (Game.GamePlayer.CurrentRoom.RoomRow == Game.GameMonster.MonsterLocation.RoomRow &&
            Math.Abs(Game.GamePlayer.CurrentRoom.RoomColumn - Game.GameMonster.MonsterLocation.RoomColumn) == 1)
            return true;
        
        if (Game.GamePlayer.CurrentRoom.RoomColumn == Game.GameMonster.MonsterLocation.RoomColumn &&
            Math.Abs(Game.GamePlayer.CurrentRoom.RoomRow - Game.GameMonster.MonsterLocation.RoomRow) == 1)
            return true;
        
        return false;
    }
    
    public string GetRoomText()
    {
        string response = null;
        
        if (CheckIfHasAdjacentMonster())
        {
            response = "!!You sense a monster in an adjacent room!!";
        }
        
        if (CheckIfHasMonster())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "You ran into an unspeakable monster. You are thrown out of the cavern." + "\n"+ response;
        }
        
        Console.ForegroundColor = ConsoleColor.Magenta;
        
        if (CheckIfEntrance())
        {
            return "You can see the light. This must be the Cave Entrance." + "\n" + response;
        }

        if (CheckIfFountain() && !Game.GamePlayer.HasEnabledFountain)
        {
            //Console.ForegroundColor = ConsoleColor.Magenta;
            return "You sense something strange. This must be the Fountain." + "\n"+ response; 
        }
        
        if (CheckIfFountain() && Game.GamePlayer.HasEnabledFountain)
        {
            //Console.ForegroundColor = ConsoleColor.Magenta;
            return "The fountain is gushing. It is enabled. Time to get out of here."  + "\n"+ response; 
        }

        else
        {
            if (response != null)
                return response;
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                return "You sense nothing.";
            }
               
        }
    }
}