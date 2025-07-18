using System;
using SadanConsole.Core;
using SadanConsole.Map;

namespace SadanConsole.Movement
{
    public class PlayerMove
    {
        private readonly Player player;

        public PlayerMove(Player player)
        {
            this.player = player;
        }

        public void Move(ConsoleKey key, Map.Map map)
        {
            var newPosition = new Position(player.Position.X, player.Position.Y);

            switch (key)
            {
                case ConsoleKey.UpArrow: newPosition.Y -= player.Speed; break;
                case ConsoleKey.DownArrow: newPosition.Y += player.Speed; break;
                case ConsoleKey.LeftArrow: newPosition.X -= player.Speed; break;
                case ConsoleKey.RightArrow: newPosition.X += player.Speed; break;
                case ConsoleKey.Escape: Environment.Exit(0); break;
                default: return;
            }

            if (map.IsInMap(newPosition.X, newPosition.Y))
            {
                player.Clear();
                player.Position = newPosition;
                player.Draw();
            }
        }
    }
}
