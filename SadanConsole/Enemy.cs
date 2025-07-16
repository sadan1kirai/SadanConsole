using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadanConsole
{
    public class Enemy : Character
    {
        public int Speed { get; set; }
        public MovementSettings movementSettings;

        public Enemy(Map map, int X, int Y, char symbol, int speed, MovementSettings movementSettings) : base(map, X, Y, symbol)
        {
            this.movementSettings = movementSettings;
            this.Speed = speed;
        }
        public override void Move(ConsoleKey key)
        {
            movementSettings.Move(this, map);
        }
    }
}
