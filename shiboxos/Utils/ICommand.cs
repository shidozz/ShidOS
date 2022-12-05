using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace shiboxos.Utils
{
    public abstract class ICommand
    {
        public string Name;
        public string Description;

        public abstract void Execute(string[] args = null);

    }
}
