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
        //map-panel location width+height
        private Rectangle mapRec = new Rectangle(15, 2, 50, 25);
        private Rectangle panelRec = new Rectangle(70, 2, 30, 12);
        private Rectangle panelRec2 = new Rectangle(70,15,30,12);

        private const char LINE_CHAR = '#';
        private char mapChar = LINE_CHAR;

        private void DrawMap()
        {
            MapDesign.DrawRectangle(mapRec);
        }
        private void DrawPanel()
        {
            MapDesign.DrawRectangle(panelRec);
        }
        private void DrawPanel2()
        {
            MapDesign.DrawRectangle(panelRec2);
        }

        public Map()
        {
            DrawMap();
            DrawPanel();
            DrawPanel2();
        }

        public void Label() // kısa oyun baslıgı ve esc tusu acıklaması((degistirilebilir))
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(110, 30);
            Console.SetBufferSize(110, 30);

            Console.Title = "Sadan Console Game";
            Console.SetCursorPosition(0,0);
            Console.Write("ESC Tuşuna basıp oyunu \nsonlandırlabilirsiniz.");           
        }

        public void Location(Player player)
        {
            Console.SetCursorPosition(82, 20);
            Console.WriteLine("Oyuncu Konumu");
            Console.SetCursorPosition(82, 21);
            Console.Write(' ');
            Console.SetCursorPosition(82, 21);
            
            Console.Write($"X: {player.Position.X} Y: {player.Position.Y}");
        }
        public bool IsInMap(int x, int y)
        {
            return x >= mapRec.Left + 1 && x <= mapRec.Right - 1 &&
                   y >= mapRec.Top + 1 && y <= mapRec.Bottom - 1;
        }

    }
}
