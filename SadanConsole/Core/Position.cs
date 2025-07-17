using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadanConsole.Core
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position (int x, int y) // this kaldırılabilir deneyebiliriz
        {
            this.X = x;
            this.Y = y;
        }
        public Position Clone() => new Position(X,Y); 
    }
}
