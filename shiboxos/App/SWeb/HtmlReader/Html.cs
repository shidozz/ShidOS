using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiboxos.App.SWeb.HtmlReader
{
    internal class Html
    {
        public string data;
        public Html(string data)
        {
            this.data = data;
        }

        public void Read() {
            string[] allData = data.Split(" ");
        }
    }
}
