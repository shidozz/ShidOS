using Cosmos.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace shiboxos.Utils.Commands
{
    public class KeyLang : ICommand
    {
        public KeyLang()
        {
            Name = "KeyLang";
            Description = "Affiche/Modifie La Langue Du Clavier";
        }
        public override void Execute(string[] args = null)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("La langue du clavier est " + Kernel.lang);
            }
            else if (args[0].ToLower() == "fr" || args[0].ToLower() == "fr_fr" || args[0].ToLower() == "fr-fr")
            {
                Console.WriteLine("La langue du clavier est passer de " + Kernel.lang + " a " + "fr_FR");
                Kernel.lang = "fr_FR";
                KeyboardManager.SetKeyLayout(Kernel.FR);
            }
            else if (args[0].ToLower() == "us" || args[0].ToLower() == "en_us" || args[0].ToLower() == "en-us")
            {
                Console.WriteLine("La langue du clavier est passer de " + Kernel.lang + " a " + "en_US");
                Kernel.lang = "en_US";
                KeyboardManager.SetKeyLayout(Kernel.US);
            }
            else if (args[0].ToLower() == "de" || args[0].ToLower() == "de_de" || args[0].ToLower() == "de-de")
            {
                Console.WriteLine("La langue du clavier est passer de " + Kernel.lang + " a " + "de_DE");
                Kernel.lang = "de_DE";
                KeyboardManager.SetKeyLayout(Kernel.DE);
            }
            else if (args[0].ToLower() == "tr" || args[0].ToLower() == "tr_tr" || args[0].ToLower() == "tr-tr")
            {
                Console.WriteLine("La langue du clavier est passer de " + Kernel.lang + " a " + "tr_TR");
                Kernel.lang = "tr_TR";
                KeyboardManager.SetKeyLayout(Kernel.TR);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("La langue que vous avez renseignez n'existe pas dans mon repertoire !");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
