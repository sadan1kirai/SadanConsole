using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SadanConsole
{
    public interface MovementSettings
    {
        void Move(Enemy enemy, Map map);
    }

    public static class RandomClass
    {
        public static Random rnd = new Random();
    }

    public class HorizontalMove : MovementSettings //yatay
    {
        public void Move(Enemy enemy, Map map)
        {
            int rndmove = RandomClass.rnd.Next(2) == 0 ? -enemy.Speed : enemy.Speed;
            int newX = enemy.X + rndmove;

            if (map.IsInMap(newX, enemy.Y)) //map control
            {
                enemy.Clear();
                enemy.X = newX;
                enemy.Draw();
            }
        }
    }
    public class VeritcalMove : MovementSettings //dikey
    {
        public void Move(Enemy enemy, Map map)
        {
            int rndmove = RandomClass.rnd.Next(2) == 0 ? -enemy.Speed : enemy.Speed;
            int newY = enemy.Y + rndmove;

            if (map.IsInMap(newY, enemy.Y)) // map.IsInMap(enemy.X, newY) * (?)
            {
                enemy.Clear();
                enemy.Y = newY;
                enemy.Draw();
            }
        }
    }
    public class RandomMove : MovementSettings //yatay+dikey
    {
        private static Random rnd = new Random();
        public void Move(Enemy enemy, Map map)
        {
            int newX = enemy.X;
            int newY = enemy.Y;

            switch (RandomClass.rnd.Next(4))
            {
                case 0: newY -= enemy.Speed; break;
                case 1: newX -= enemy.Speed; break;
                case 2: newY += enemy.Speed; break;
                case 3: newX += enemy.Speed; break;
            }
            if (map.IsInMap(newX, newY))
            {
                enemy.Clear();
                enemy.Y = newY;
                enemy.X = newX;
                enemy.Draw();
            }
        }
    }
}
