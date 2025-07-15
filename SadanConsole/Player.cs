using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadanConsole
{
    class Player
    {
        private Map map;

        public int X { get; set; }
        public int Y { get; set; }

        public int Speed { get; set; } = 1; //aslında kac kare atlıyacagı ayarı belki 2 3 yaparız mapi büyütürüz gibi degistirilebilir.


        //karakterler
        private const char PLAYER_CHAR = '@';



        public Player(Map map, int StartPosX, int StartPosY)
        {
            this.map = map;
            X = StartPosX;
            Y = StartPosY;
        }


        public void PlayerDraw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(PLAYER_CHAR); 
        }
        public void PlayerClear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
        public void ExitApplication() //exit gibi
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Oyun sonlandırılmıştır.");
            Environment.Exit(0);
        }
        public void Movement(ConsoleKey key)
        {
            int newX = X;
            int newY = Y;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    newY-=Speed;
                    break;
                case ConsoleKey.DownArrow:
                    newY+=Speed;
                    break;
                case ConsoleKey.LeftArrow:
                    newX-=Speed; 
                    break;
                case ConsoleKey.RightArrow:
                    newX+=Speed;
                    break;
                case ConsoleKey.Escape:
                    ExitApplication();
                    break;
            }
            if (map.IsInMap(newX, newY))
            {
                PlayerClear();
                X = newX;
                Y = newY;
                PlayerDraw();
            }
        }
    }
}
