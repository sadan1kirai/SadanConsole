using System;
using System.Drawing;
using SadanConsole.Core;
using SadanConsole.Map;

namespace SadanConsole.Game
{
    public class CoinManager
    {
        private readonly Map.Map map;
        private readonly Random random = new Random();

        private Point currentCoin;
        private int collectedCoins = 0;
        private const int MaxCoins = 10;       
        private const char CoinChar = '$';
        public int CollectedCoins => collectedCoins;
        public event Action CoinCollected;

        public CoinManager(Map.Map map)
        {
            this.map = map;
            SpawnNewCoin();
        }

        public void DrawCoin()
        {
            Console.SetCursorPosition(currentCoin.X, currentCoin.Y);
            Console.Write(CoinChar);
        }

        public void CheckCollision(Player player)
        {
            if (player.Position.X == currentCoin.X && player.Position.Y == currentCoin.Y)
            {
                collectedCoins++;
                Console.SetCursorPosition(currentCoin.X, currentCoin.Y);
                Console.Write(' ');

                CoinCollected?.Invoke();

                if (collectedCoins < MaxCoins)
                    SpawnNewCoin();
            }
        }
        private void SpawnNewCoin()
        {
            int x, y;
            do
            {
                x = random.Next(16, 64); // mapRec.Left + 1 to Right - 1
                y = random.Next(3, 27);  // mapRec.Top + 1 to Bottom - 1
            } while (!map.IsInMap(x, y));

            currentCoin = new Point(x, y);
            DrawCoin();
        }

        public bool IsGameFinished()
        {
            return collectedCoins >= MaxCoins;
        }
    }
}
