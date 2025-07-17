using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadanConsole.Core
{
    public class ConsoleRenderer : IRenderer
    {
        public void Draw(Position position,char Symbol)
        {
            Console.SetCursorPosition(position.X,position.Y);
            Console.Write(Symbol);
        }
        public void Clear(Position position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(' ');
        }
    }
}
