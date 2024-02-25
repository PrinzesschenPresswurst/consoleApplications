namespace FountainOfObjects;

public class Monster
{
    public bool IsAlive { get; set; } = true;
    public Room MonsterLocation { get; set; }
    
    public Monster(int row, int column)
    {
        MonsterLocation = new Room(row, column);
    }
}