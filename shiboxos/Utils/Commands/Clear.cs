using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiboxos.Utils.Commands
{
    public class Clear : ICommand
    {
        public Clear()
        {
            Name = "Clear";
            Description = "Clear La Console";
        }
        public override void Execute(string[] args = null)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("#################################");
            Console.WriteLine("#                               #");
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" BIENVENUE SUR SHIDOS ! v0.0.1 ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("#");
            Console.WriteLine("#                               #");
            Console.WriteLine("#################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }
    }
}
