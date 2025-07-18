using System;
using System.Drawing;

namespace SadanConsole.Map
{
    public static class MapDesign
    {
        private const char LINE_CHAR = '#';

        public static void DrawRectangle(Rectangle rect)
        {
            //topbottom
            for (int i = rect.X; i <= rect.Right; i++)
            {
                Console.SetCursorPosition(i, rect.Y);
                Console.Write(LINE_CHAR);

                Console.SetCursorPosition(i, rect.Bottom);
                Console.Write(LINE_CHAR);
            }

            //leftright
            for (int i = rect.Y; i <= rect.Bottom; i++)
            {
                Console.SetCursorPosition(rect.X, i);
                Console.Write(LINE_CHAR);

                Console.SetCursorPosition(rect.Right, i);
                Console.Write(LINE_CHAR);
            }
        }
    }
}
