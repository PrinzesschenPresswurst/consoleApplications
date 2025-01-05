namespace MapGame;

public static class CombatDisplay
{
    private static string _r = """
                                  _______          .
                              ---'   ____)         .
                                    (_____)        .
                                    (_____)        .
                                    (____)         .
                              ---.__(___)          .
                              """;
    
    private static string _p = """
                                   _______          .
                               ---'   ____)____     .
                                         ______)    .
                                         _______)   .
                                        _______)    .
                               ---.__________)      .
                               """;

    private static string _s = """
                                  _______          .
                              ---'   ____)____     .
                                        ______)    .
                                     __________)   .
                                    (____)         .
                              ---.__(___)          .
                              """;

    public static void DisplayBothHands(Combat.RpsHand playerHand, Combat.RpsHand enemyHand)
    {
        string playerHandString = GetString(playerHand);
        List<string> playerHandList = playerHandString.Split(['\n', '\r'],StringSplitOptions.RemoveEmptyEntries).ToList();
        
        string enemyHandString = GetString(enemyHand);
        List<string> enemyHandList = enemyHandString.Split(['\n', '\r'],StringSplitOptions.RemoveEmptyEntries).ToList();
        enemyHandList = FlipList(enemyHandList);
        
        Console.WriteLine();
        Console.WriteLine("       Your hand       --       Enemy hand       ");
        Console.WriteLine();
        for (int i = 0; i < playerHandList.Count; i++)
        {
            Console.WriteLine(playerHandList[i] + "   " + enemyHandList[i]);
        }
        Console.WriteLine();
    }
    
    private static string GetString(Combat.RpsHand hand)
    {
        string s = "";
        switch (hand)
        {
            case Combat.RpsHand.Paper:
                 s = _p;
                break;
            case Combat.RpsHand.Rock:
                s = _r;
                break;
            case Combat.RpsHand.Scissor:
                s = _s;
                break;
        }
        return s;
    }
    
    private static List<string> FlipList(List<string> list)
    {
        List<string> enemyHandListFlip = list.Select(line => new string(line.Reverse().ToArray())).ToList();
        for (int i = 0; i < enemyHandListFlip.Count; i++)
        {
            enemyHandListFlip[i] = enemyHandListFlip[i].Replace('(', '#'); 
            enemyHandListFlip[i] = enemyHandListFlip[i].Replace(')', '('); 
            enemyHandListFlip[i] = enemyHandListFlip[i].Replace('#', ')');; 
        }
        return enemyHandListFlip;
    }
}