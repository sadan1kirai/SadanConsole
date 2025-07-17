using SadanConsole.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadanConsole.Core
{
    // Core klasöründeki Enemy.cs
    public class Enemy : Character
    {
        public int Speed { get; set; }
        private MovementSettings movement;

        public Enemy(Position position, char symbol, int speed, IRenderer renderer, MovementSettings movement)
            : base(position, symbol, renderer)
        {
            Speed = speed;
            this.movement = movement;
        }

        public override void Move(ConsoleKey key, Map.Map map)
        {
            movement.Move(this, map);
        }
    }

}
