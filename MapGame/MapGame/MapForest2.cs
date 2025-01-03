namespace MapGame;

public class MapForest2 : BaseMap
{
    public MapForest2()
    {
        PlayerStartPos  = new int[,] { {2, 2} };
        MapStoryText = "that is odd, you feel like you have already been here...";
        MapString = """
                    ########################################
                    #                                      #
                    #     ^       ^       ^       ^        #
                    #    ^^^     ^^^     ^^^     ^^^       #
                    #     |       |       |       |        #
                    #                                      #
                    #    E                      E          #
                    2          _______                     #
                    2         /       \                    #
                    #        /         \                   #
                    #       +-----------+      ^       ^   #
                    #       |   [  ]    |     ^^^     ^^^  #
                    #       |    __     |      |       |   #
                    #       |   |  |    |                  #
                    #       |___|11|____|                  #
                    #                                      #
                    #     ^       ^                        #
                    #    ^^^     ^^^                       #
                    #     |       |                E       #
                    #                                      #
                    #########################################
                    """;
        string[] test = MapString.Split("\n");
        MapCharCount = test[0].Length;
        MapLineCount = test.Length;
        MapToGoTo1 = null;
        MapToGoTo2 = null;
    }
}