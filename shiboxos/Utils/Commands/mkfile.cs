using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shiboxos.Utils;
using static shiboxos.Kernel;
namespace shiboxos.Utils.Commands
{
    public class mkfile : ICommand
    {
        public mkfile()
        {
            Name = "mkfile";
            Description = "Creer Un Fichier";
        }
        public override void Execute(string[] args = null)
        {
            args[0] = args[0].Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\");
            
            if (fs.fs.GetFile(@args[0]) == null)
            {
                fs.fs.CreateFile(@args[0]);
                Console.WriteLine("Le fichier \"" + args[0] + "\" vient d'etre creer !");
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Le fichier \"" + @args[0] + "\" existe déjà !");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
        }
    }
}
