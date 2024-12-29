namespace Console_Minesweeper;

public class SoundHandler
{
    private Game Game { get; set; }
    
    public SoundHandler(Game game)
    {
        Game = game;
        Game.OnMineUncovered += GameOnOnMineUncovered;
        Game.OnGameWon += GameOnOnGameWon;
    }

    private static void GameOnOnGameWon(object? sender, EventArgs e)
    {
        int[] frequencies = [523, 523, 523, 659, 523, 659]; 
        int[] durations = [200, 200, 200, 300, 200, 500];   

        for (int i = 0; i < frequencies.Length; i++)
        {
            Console.Beep(frequencies[i], durations[i]);
        }
    }

    private static void GameOnOnMineUncovered(object? sender, EventArgs e)
    {
        for (int freq = 1000; freq >= 200; freq -= 50)
        {
            Console.Beep(freq, 50); 
        }
        Console.Beep(100, 300);
    }
    
}