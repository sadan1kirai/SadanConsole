using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SadanConsole.Map;
using SadanConsole.Core;
using SadanConsole.Movement;


namespace SadanConsole.Map
{
    public class Map
    {
        private Rectangle mapRec = new Rectangle(35, 0, 50, 25);
        private const char LINE_CHAR = '#';
        private char mapChar = LINE_CHAR;


        public Map()
        {
            DrawMap();
        }

        public void Label() // kısa oyun baslıgı ve esc tusu acıklaması((degistirilebilir))
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 30);
            Console.SetBufferSize(100, 30);

            Console.Title = "Sadan Console Game";
            Console.SetCursorPosition(0, 0);
            Console.Write("ESC Tuşuna basıp oyunu \nsonlandırlabilirsiniz.");
        }

        public void Location(Player player)
        {
            Console.SetCursorPosition(0, 3);
            Console.Write(' ');
            Console.SetCursorPosition(0, 3);
            Console.Write($"X: {player.Position.X} Y: {player.Position.Y}");
        }
        private void DrawMap()
        {
            for (int i = mapRec.X; i <= mapRec.Right; i++)
            {
                Console.SetCursorPosition(i, mapRec.Y);
                Console.Write(mapChar);

                Console.SetCursorPosition(i, mapRec.Bottom);
                Console.Write(mapChar);
            }

            for (int i = mapRec.Y; i <= mapRec.Y + mapRec.Height; i++)
            {
                Console.SetCursorPosition(mapRec.X, i);
                Console.Write(mapChar);

                Console.SetCursorPosition(mapRec.Right, i);
                Console.Write(mapChar);
            }
        }
        public bool IsInMap(int x, int y)
        {
            return x >= mapRec.Left + 1 && x <= mapRec.Right - 1 &&
                   y >= mapRec.Top + 1 && y <= mapRec.Bottom - 1;
        }

    }
}
