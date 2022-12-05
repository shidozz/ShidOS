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
    public class CurrentDirectory : ICommand
    {
        public CurrentDirectory()
        {
            Name = "cd";
            Description = "Change de dossier";
        }
        public override void Execute(string[] args = null)
        {
            args[0] = args[0].Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\").Replace("/", @"\");
            
            if (fs.fs.GetDirectory(@args[0]) != null)
            {
                Directory.SetCurrentDirectory(@args[0]);
                Console.WriteLine("Le repertoire viens de changer pour \"" + args[0] + "\" !");
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Le repertoire \"" + @args[0] + "\" n'existe pas !");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
        }
    }
}
