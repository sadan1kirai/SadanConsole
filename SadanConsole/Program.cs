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

            player.PlayerDraw();
            map.Label();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;

                    player.Movement(key);
                }
            }
        }
    }
}