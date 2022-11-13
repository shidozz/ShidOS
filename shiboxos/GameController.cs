using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.System.ScanMaps
{
    public class GameController : ScanMapBase
    {
        enum ConsoleKeyEX
        {
            UP = 114,
            DOWN = 115,
            LEFT = 116,
            RIGHT = 117,
            I = 118,
            R = 119,
            O = 120,
            X = 121,
        }
        protected override void InitKeys()
        {

            _keys = new List<KeyMapping>();
            _keys.Add(new KeyMapping(0, ConsoleKeyEx.NoName));
            _keys.Add(new KeyMapping(1, ConsoleKeyEx.Escape));
            _keys.Add(new KeyMapping(2, '\0', '\0', '\0', '\0', '\0', '\0', (ConsoleKeyEx)ConsoleKeyEX.UP));
            _keys.Add(new KeyMapping(3, '\0', '\0', '\0', '\0', '\0', '\0', (ConsoleKeyEx)ConsoleKeyEX.DOWN));
            _keys.Add(new KeyMapping(4, '\0', '\0', '\0', '\0', '\0', '\0', (ConsoleKeyEx)ConsoleKeyEX.LEFT));
            _keys.Add(new KeyMapping(5, '\0', '\0', '\0', '\0', '\0', '\0', (ConsoleKeyEx)ConsoleKeyEX.RIGHT));
            _keys.Add(new KeyMapping(6, '\0', '\0', '\0', '\0', '\0', '\0', (ConsoleKeyEx)ConsoleKeyEX.I));
            _keys.Add(new KeyMapping(7, '\0', '\0', '\0', '\0', '\0', '\0', (ConsoleKeyEx)ConsoleKeyEX.R));
            _keys.Add(new KeyMapping(8, '\0', '\0', '\0', '\0', '\0', '\0', (ConsoleKeyEx)ConsoleKeyEX.O));
            _keys.Add(new KeyMapping(9, '\0', '\0', '\0', '\0', '\0', '\0', (ConsoleKeyEx)ConsoleKeyEX.X));
        }
    }
}