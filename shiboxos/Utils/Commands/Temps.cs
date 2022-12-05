using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiboxos.Utils.Commands
{
    public class Temps : ICommand
    {
        public Temps()
        {
            Name = "Time";
            Description = "Affiche l'heure";
        }
        public override void Execute(string[] args = null)
        {
            Console.WriteLine(Time.getTime("hh:mm:ss"));
        }
    }
}
