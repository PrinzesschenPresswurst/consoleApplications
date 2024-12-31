using Console_Minesweeper;

Console.Title = "Minesweeper" ;

StartNewGame();
return;

void StartNewGame()
{
    Console.Clear();
    Board board = new Board(10,9, 10);
    Game game = new Game(board);
    game.RunGame();
    PlayerInputHandler playerInputHandler = new PlayerInputHandler(board);
    bool wantsToPlayAgain = playerInputHandler.AskIfPlayerWantsToPlayAgain();
    
    if (!wantsToPlayAgain)
    {
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    if (wantsToPlayAgain)
    {
        StartNewGame();
    }
}
