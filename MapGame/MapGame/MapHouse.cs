namespace MapGame;

public class MapHouse : BaseMap
{
    public MapHouse()
    {
        PlayerStartPos  = new int[,] { {1, 1} };
        MapString = """
                    ####################
                    #      [   ]       #
                    #                  #
                    #  +----+  +----+  #
                    #  |    |  |    |  #
                    #  |____|  |____|  #
                    #                  #
                    #   ____    ____   #
                    #  |____|  |____|  #
                    #####################
                    """;
        string[] test = MapString.Split("\n");
        foreach (string s in test)
            Console.WriteLine(s.Length);
        MapCharCount = test[0].Length;
        MapLineCount = test.Length;
    }
}