namespace MapGame;

public  class MapForest : BaseMap
{
    public MapForest()
    {
       PlayerStartPos  = new int[,] { {2, 2} };
       MapString = """
                   ########################################
                   #                                      #
                   #     ^       ^       ^       ^        #
                   #    ^^^     ^^^     ^^^     ^^^       #
                   #     |       |       |       |        #
                   #                                      #
                   #    E                      E          #
                   #          _______                     #
                   #         /       \                    #
                   #        /         \                   #
                   #       +-----------+      ^       ^   #
                   #       |   [  ]    |     ^^^     ^^^  #
                   #       |    __     |      |       |   #
                   #       |   |  |    |                  #
                   #       |___|XX|____|                  #
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
    }
    
}