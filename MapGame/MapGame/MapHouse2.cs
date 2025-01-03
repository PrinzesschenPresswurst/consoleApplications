namespace MapGame;

public class MapHouse2 : BaseMap
{
    public MapHouse2()
    {
        PlayerStartPos  = new int[,] { {8, 9} };
        MapStoryText = " On first glance you can see only two beds, nothing special...";
        MapString = """
                    ####################
                    #      [   ]       #
                    #                  #
                    #  +----+          #
                    #  |    |          #
                    #  |____|          #
                    #                  #
                    #           ____   #
                    #          |____|  #
                    #########11##########
                    """;
        string[] test = MapString.Split("\n");
        foreach (string s in test)
            Console.WriteLine(s.Length);
        MapCharCount = test[0].Length;
        MapLineCount = test.Length;
        MapToGoTo1 = null;
        MapToGoTo2 = null;
    }
}