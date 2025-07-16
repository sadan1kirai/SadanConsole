using System;
using System.Collections.Generic;

namespace SadanConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            Player player = new Player(map, 40, 10, '@');

            Enemy enemy1 = new Enemy(map, 45, 3, 'X', 1, new RandomMove());
            Enemy enemy2 = new Enemy(map, 53, 17, 'X', 1, new RandomMove());
            Enemy enemy3 = new Enemy(map, 68, 12, 'X', 1, new RandomMove());

            List<Enemy> enemies = new List<Enemy> { enemy1, enemy2, enemy3 };

            player.Draw();
            map.Label();
            enemy1.Draw();
            enemy2.Draw();
            enemy3.Draw();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey(true);
                    player.Move(keyInfo.Key);

                    map.Location(player);

                    foreach (var enemy in enemies)
                    {
                        enemy.Move(keyInfo.Key); //belki otomatik hareket yaptirabiliriz bu kısımdan
                    }

                    if (CheckCollision(player, enemies))
                    {
                        Console.Clear();
                        Console.WriteLine("Oyuncu düşmana çarptı! Oyun bitti.");
                        break;
                    }
                }
            }
        }

        static bool CheckCollision(Player player, List<Enemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (player.X == enemy.X && player.Y == enemy.Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
