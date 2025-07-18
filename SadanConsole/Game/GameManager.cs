using SadanConsole.Menus;
using SadanConsole.Map;
using SadanConsole.Movement;
using SadanConsole.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using SadanConsole.Game;

namespace SadanConsole.Game
{
    public class GameManager
    {

        private PlayerMove playerMover;
        private Map.Map map;
        private Player player;
        private List<Enemy> enemies;
        private IRenderer renderer = new ConsoleRenderer();
        private GameUI ui = new GameUI();

        public GameResult Run()
        {
            SetupGame();

            while (true)
            {
                if (!Console.KeyAvailable)
                    continue;

                var key = Console.ReadKey(true).Key;

                playerMover.Move(key, map);
                enemies.ForEach(e => e.Move(key, map));

                ui.ShowHealth(player.Health);
                CheckCoinCollision();

                if (coinManager.IsGameFinished())
                {
                    ShowWinMessage();
                    return GameResult.Menu;
                }

                if (CheckCollision())
                {
                    player.TakeDamage(1);
                    ui.ShowHealth(player.Health);
                    Console.Beep(400, 150);

                    if (player.Health <= 0)
                    {
                        var result = GameOverMenu.Show();

                        return result switch
                        {
                            0 => GameResult.Restart,
                            1 => GameResult.Menu,
                            _ => GameResult.Exit,
                        };
                    }
                }
            }
        }

        private CoinManager coinManager;

        private void SetupGame()
        {
            Console.Clear();
            Console.Title = "Coin Hunt! Sadan Console";
            Console.CursorVisible = false;

            map = new Map.Map();
            ui.Label();

            player = new Player(new Position(40, 10), '@', renderer);
            playerMover = new PlayerMove(player);

            coinManager = new CoinManager(map);
            ui.ShowCoinInfo(coinManager.CollectedCoins, 10);

            coinManager.CoinCollected += () =>
            {
                ui.ShowCoinInfo(coinManager.CollectedCoins, 10);
                player.Draw();
                Console.Beep();
            };

            enemies = new List<Enemy>
            {
                new Enemy(new Position(18, 3), 'X', 1, renderer, new RandomMove()),
                new Enemy(new Position(30, 17), 'X', 1, renderer, new RandomMove()),
                new Enemy(new Position(50, 12), 'X', 1, renderer, new RandomMove())
            };

            player.Draw();
            enemies.ForEach(e => e.Draw());
            ui.ShowHealth(player.Health);
        }

        private void CheckCoinCollision()
        {
            coinManager.CheckCollision(player);
        }

        private void ShowWinMessage()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("TEBRİKLER! Tüm coinleri topladınız.");
            Console.ReadKey();
        }

        private bool CheckCollision()
        {
            return enemies.Any(e => e.Position.X == player.Position.X &&
                                    e.Position.Y == player.Position.Y);
        }
    }
}
