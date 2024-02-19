namespace FountainOfObjects;

public class Monster
{
    public bool IsAlive { get; set; } = true;
    public Room MonsterLocation { get; set; } = new Room(0,3);

    /*public Monster()
    {
        
    }*/
}