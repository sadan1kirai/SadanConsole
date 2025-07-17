using SadanConsole.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SadanConsole.Movement
{
    public interface MovementSettings
    {
        void Move(Enemy enemy, Map.Map map);
        
    }
}
