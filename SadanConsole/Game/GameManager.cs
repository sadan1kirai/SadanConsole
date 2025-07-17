using System;
using System.Collections.Generic;
using System.Linq;
using SadanConsole.Core;
using SadanConsole.Map;
using SadanConsole.Movement;

namespace SadanConsole.Game
{
    public class GameManager
    {
        private SadanConsole.Map.Map map;
        private Player player;
        private List<Enemy> enemies;
        private IRenderer renderer = new ConsoleRenderer();

        public void Run()
        {
            Console.CursorVisible = false;
            map = new Map.Map();
            map.Label();

            player = new Player(new Position(40, 10), '@', renderer);

            enemies = new List<Enemy>
            {
                new Enemy(new Position(45, 3), 'X', 1, renderer, new RandomMove()),
                new Enemy(new Position(53, 17), 'X', 1, renderer, new RandomMove()),
                new Enemy(new Position(68, 12), 'X', 1, renderer, new RandomMove())
            };


            player.Draw();
            enemies.ForEach(e => e.Draw());

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    player.Move(key, map);
                    enemies.ForEach(e => e.Move(key, map));
                    map.Location(player);

                    if (CheckCollision())
                    {
                        Console.Clear();
                        Console.WriteLine("Çarpışma! Oyun bitti."); //sonradan spectre console ile figlet yazisi
                                                                    //belki menü ya da play again label gibi
                        break;
                    }
                }
            }
        }

        private bool CheckCollision()
        {
            return enemies.Any(e => e.Position.X == player.Position.X &&
                                    e.Position.Y == player.Position.Y);
        }
    }
}
    