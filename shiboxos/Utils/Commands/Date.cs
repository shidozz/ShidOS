using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiboxos.Utils.Commands
{
    public class Date : ICommand
    {
        public Date()
        {
            Name = "Date";
            Description = "Affiche la date";
        }
        public override void Execute(string[] args = null)
        {
            Console.WriteLine(Time.getDate("dd/mm/yy"));
        }
    }
}
