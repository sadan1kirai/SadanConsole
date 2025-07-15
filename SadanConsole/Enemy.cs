using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadanConsole
{
    class Enemy
    {
        private Map map;
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; } = 1;

        private DateTime nextMoveTime = DateTime.Now;
        public int EnemySpeedMS { get; set; } = 150;


        private const char ENEMY_CHAR = 'X';
        private static readonly Random rnd = new Random();

        public Enemy(Map map,int StartPosX,int StartPosY)
        {
            this.map = map;
            X = StartPosX;
            Y = StartPosY;
        }
        public void EnemyDraw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(ENEMY_CHAR);
        }
        public void EnemyClear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
        public void EnemyMove()
        {
            int randomMove = rnd.Next(4);
            int newX = X;
            int newY = Y;

            if (DateTime.Now < nextMoveTime)
                return; // zamanı gelmediyse hareket etme

            switch (randomMove)
            {
                case 0: newY -= Speed; break; //yukari
                case 1: newY += Speed; break; //asagi
                case 2: newX -= Speed; break; //sol
                case 3: newX += Speed; break; //sag
            }
            nextMoveTime = DateTime.Now.AddMilliseconds(EnemySpeedMS);
            if (map.IsInMap(newX, newY))
            {
                EnemyClear();
                X = newX;
                Y = newY;
                EnemyDraw();
            }
        }
    }
}
