using SadanConsole.Game;
using SadanConsole.Menus;

public static class GameLoop
{
    public static void Start()
    {

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool isRunning = true;

        while (isRunning)
        {
            int startChoice = StartMenu.Show();

            if (startChoice == 0)
            {
                bool gameOver = false;

                while (!gameOver)
                {
                    var gameManager = new GameManager();
                    var result = gameManager.Run();

                    if (result == GameResult.GameOver)
                    {
                        int gameOverChoice = GameOverMenu.Show();

                        if (gameOverChoice == 0)
                            continue;
                        else if (gameOverChoice == 1)
                            break;
                    }
                    else
                    {
                        gameOver = true;
                    }
                }
            }
            else
            {
                isRunning = false;
            }
        }
    }
}
