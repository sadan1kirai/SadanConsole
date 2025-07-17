using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadanConsole.Core
{
    public interface IRenderer //INTERFACE
    {
        void Draw(Position position, char symbol);
        void Clear(Position position);
    }
}
