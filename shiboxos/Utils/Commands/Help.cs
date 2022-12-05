using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shiboxos.Utils;
namespace shiboxos.Utils.Commands
{
    public class Help : ICommand
    {
        public Help()
        {
            Name = "Help";
            Description = "Affiche L'Aide";
        }
        public override void Execute(string[] args = null)
        {
            foreach (ICommand command in CommandHandler.Commands)
            {
                Console.WriteLine(command.Name + " - " + command.Description);
            }
        }
    }
}
