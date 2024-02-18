namespace FountainOfObjects;

public class Monster
{
    public Room MonsterLocation { get; set; }

    public Monster()
    {
        MonsterLocation = new Room(0,3);
    }
}