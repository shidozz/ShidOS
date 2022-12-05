using shiboxos.Utils.Commands;
using System.Collections.Generic;
using Console = System.Console;

namespace shiboxos.Utils
{
    public abstract class CommandHandler
    {
        public static List<ICommand> Commands = new List<ICommand>();

        public static void init()
        {
            Clear clear = new();
            Commands.Add(clear);

            Help help = new();
            Commands.Add(help);

            KeyLang keyLang = new();
            Commands.Add(keyLang);

            SSharp ssharp = new();
            Commands.Add(ssharp);

            ShutDown shutDown = new();
            Commands.Add(shutDown);

            mkdir Mkdir = new();
            Commands.Add(Mkdir);

            mkfile Mkfile = new();
            Commands.Add(Mkfile);

            CurrentDirectory currentDirectory = new();
            Commands.Add(currentDirectory);

            Date date = new();
            Commands.Add(date);

            Temps temps = new();
            Commands.Add(temps);
        }

        public static void execute(string cmd, string[] args = null)
        {
            foreach(ICommand command in Commands)
            {
                if (string.IsNullOrEmpty(command.Name))
                {
                    Console.ForegroundColor = System.ConsoleColor.Red;
                    Console.WriteLine("Une Commande Sans Nom Vient D'Apparaitre");
                    Console.ForegroundColor = System.ConsoleColor.White;
                    return;
                }
                if(command.Name.ToLower() == cmd.ToLower())
                {
                    command.Execute(args);
                    return;
                }
            }
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine("Cette Commande N'existe Pas !");
            Console.ForegroundColor = System.ConsoleColor.White;

        }
    }
}
