using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace shiboxos.Utils.Commands
{
    public class ShutDown : ICommand
    {
        public ShutDown()
        {
            Name = "ShutDown";
            Description = "Permet De Géré L'État De L'Alimentation";
        }
        public override void Execute(string[] args = null)
        {
            if(args == null)
            {
                Console.WriteLine("Veuillez Précisé Un Argument");
                return;
            }
            else if (args[0].ToLower() == "-s")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("La Console Est Entrain S'Éteindre");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Beep();
                Power.Shutdown();
            }
            else if (args[0].ToLower() == "-r")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("La Console Est Entrain De Redémarré");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Beep();
                Power.Reboot();
            }
            else if (args[0].ToLower() == "-h")
            {
                Console.WriteLine("-S      Permet d'éteindre la console");
                Console.WriteLine("-R      Permet de redémarré la console");
                Console.WriteLine("-H      Permet d'affiché l'aide sur la commande shutdown");
            }
        }
    }
}
