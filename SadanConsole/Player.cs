using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SadanConsole
{
    public class Player : Character
    {
        public int Speed { get; set; } = 1;

        public Player(Map map, int X, int Y, char Symbol) : base(map, X, Y, '@')
        { }
        public override void Move(ConsoleKey key)
        {
            int newX = X, newY = Y;

            switch (key)
            {
                case ConsoleKey.UpArrow: newY -= Speed; break;
                case ConsoleKey.DownArrow: newY += Speed; break;
                case ConsoleKey.LeftArrow: newX -= Speed; break;
                case ConsoleKey.RightArrow: newX += Speed; break;

                case ConsoleKey.Escape: Environment.Exit(0); break; //uygulama kapatma tusu belki program.cs tasiyabiliriiz
                                                                    //while icinde kosul acarak
                default: return;
            }

            if (map.IsInMap(newX, newY))
            {
                Clear();     // Eski konumu temizle
                X = newX;
                Y = newY;
                Draw();      // Yeni konuma çiz
            }
        }

    }
}
