using Cosmos.System.Graphics;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games = shiboxos.utils.Game;
using Kern = shiboxos.Kernel;

namespace shiboxos.App.Game.Snake
{
    
    public class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Circle()
        {
            X = 0;
            Y = 0;
        }
    }
}
