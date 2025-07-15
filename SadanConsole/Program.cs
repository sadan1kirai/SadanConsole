using System;
namespace SadanConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Map map = new Map();

            Player player = new Player(map, 40,10);
            Enemy enemy = new Enemy(map, 35,20);

            player.PlayerDraw();
            enemy.EnemyDraw();

            map.Label();

            while (true)
            {
                // Oyuncu hareketi
                if (Console.KeyAvailable)
                    player.Movement(Console.ReadKey(true).Key);

                // Düşman hareketleri
                enemy.EnemyMove();

            }
        }
    }
}