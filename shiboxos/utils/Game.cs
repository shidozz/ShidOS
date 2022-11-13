using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiboxos.utils
{
    public class Game : App
    {
        public Game(string name, string description, bool isOpen) : base(name, description, isOpen)
        {
        }

        public virtual void Start()
        {
        }
        public virtual void Update()
        {
        }
    }
}
