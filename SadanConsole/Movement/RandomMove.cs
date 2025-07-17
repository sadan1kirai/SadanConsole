using SadanConsole.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadanConsole.Movement
{
    public class RandomMove : MovementSettings
    {
        public static Random rnd = new Random();

        public void Move(Enemy enemy,Map.Map map)
        {
            int newX = enemy.Position.X;
            int newY = enemy.Position.Y;

            switch (rnd.Next(4))
            {
                case 0: newY -= enemy.Speed; break;
                case 1: newX -= enemy.Speed; break;
                case 2: newY += enemy.Speed; break;
                case 3: newX += enemy.Speed; break;
            }
            if (map.IsInMap(newX, newY))
            {
                enemy.Clear();
                enemy.Position = new Position(newX, newY);
                enemy.Draw();
            }
        }
    }
}
