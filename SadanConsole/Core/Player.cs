using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SadanConsole.Core
{
    public class Player : Character
    {
        public int Speed { get; set; } = 1;

        public Player(Position position, char symbol, IRenderer renderer)
            : base(position, symbol, renderer)
        { }

        public override void Move(ConsoleKey key, Map.Map map)
        {
            var newPosition = new Position(Position.X, Position.Y);

            switch (key)
            {
                case ConsoleKey.UpArrow: newPosition.Y -= Speed; break;
                case ConsoleKey.DownArrow: newPosition.Y += Speed; break;
                case ConsoleKey.LeftArrow: newPosition.X -= Speed; break;
                case ConsoleKey.RightArrow: newPosition.X += Speed; break;
                case ConsoleKey.Escape: Environment.Exit(0); break;
                default: return;
            }

            if (map.IsInMap(newPosition.X, newPosition.Y))
            {
                Clear();
                Position = newPosition;
                Draw();
            }
        }
    }

}
