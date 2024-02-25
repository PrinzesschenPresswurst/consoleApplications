namespace FountainOfObjects;

public class RandomMapSizeHandler : IMapSizeHandler
{
    public void SetupMap(Map map, int mapSize)
    {
        Random randomRow = new Random();
        map.MapRows = randomRow.Next(2, 11);

        Random randomColumn = new Random();
        map.MapColumns = randomColumn.Next(2, 11);
        
        SetFountainRoom(map);
        SetMonster(map);
        
        map.MapDisplayString = $"""

                                -----------------------------------------
                                 * SMALL FOUNTAIN CAVE MAP *
                                 
                                There is no map on the parchment.
                                           N
                                        W  +  E
                                           S
                                Magic Word - Oklahoma !!!

                                -----------------------------------------

                                """;
    }

    public void SetFountainRoom(Map map)
    {
        do
        {
            Random randomFountainRow = new Random();
            map.FountainRoom.RoomRow = randomFountainRow.Next(0, map.MapRows);
            Random randomFountainColumn = new Random();
            map.FountainRoom.RoomColumn = randomFountainColumn.Next(0, map.MapColumns);
        } while (map.FountainRoom.RoomRow == 0 && map.FountainRoom.RoomColumn == 0);
    }

    public void SetMonster(Map map)
    {
        int row;
        int column;
        do
        {
            Random monsterRoomRow = new Random();
            row = monsterRoomRow.Next(0, map.MapRows);
            Random monsterRoomColumn = new Random();
            column = monsterRoomColumn.Next(0, map.MapColumns);
        } while (row == 0 && column == 0);

        map.Monster = new Monster(row, column);
    }
}