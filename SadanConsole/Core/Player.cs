using System;

namespace SadanConsole.Core
{
    public class Player : Character
    {
        public int Speed { get; set; } = 1;
        public int Health { get; set; } = 3;

        public Player(Position position, char symbol, IRenderer renderer)
            : base(position, symbol, renderer)
        { }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }
    }
}
