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
    public class mkdir : ICommand
    {
        public mkdir()
        {
            Name = "mkdir";
            Description = "Creer Un Dossier/Repertoire";
        }
        public override void Execute(string[] args = null)
        {
            args[0].Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\").Replace("/", "\\");
            
            if (string.IsNullOrEmpty(fs.fs.GetDirectory(args[0]).mName) || string.IsNullOrWhiteSpace(fs.fs.GetDirectory(args[0]).mName))
            {
                fs.fs.CreateDirectory(args[0]);
                Console.WriteLine("Le dossier \"" + args[0] + "\" vient d'etre creer !");
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Le dossier \"" + @args[0] + "\" existe déjà !");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
        }
    }
}
