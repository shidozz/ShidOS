using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.Graphics;
using System.Drawing;
using IL2CPU.API.Attribs;
using shiboxos.utils;
using Kern = shiboxos.Kernel;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System;

namespace shiboxos.App
{
    internal class settings : utils.App
    {
        public static PCScreenFont font;
        public settings(string name = "settings", string description = "ceci est une descritpion", bool isOpen = false) : base(name, description, isOpen)
        {
        }
        public void Start(byte[] ft)
        {
            if (!isOpen)
            {
                Canvas canvas = Kern.canvas;
                canvas.Clear(Color.DarkGray);
                Button btn = new(3, 3, 50, 50, BtnState.NORMAL);
                canvas.DrawFilledCircle(new(Color.Gray), btn.X + (btn.maxX / 2), btn.Y + (btn.maxY / 2), btn.maxX / 2);

                font = PCScreenFont.LoadFont(ft);
                canvas.DrawString("ST", font, new(Color.Black), new(btn.X + (btn.maxX / 2) - ((8 * 2) / 2), btn.Y + (btn.maxY / 2) - (16 / 2)));
                canvas.DrawString(name, font, new(Color.Black), new((640 / 2) - ((8 * (name.Length + 1)) / 2), (480 / 2) - (16 / 2)));
                canvas.DrawString(description, font, new(Color.Black), new((640 / 2) - ((8 * (description.Length + 1)) / 2), ((480 / 2) - (16 / 2)) + 24 ));
                canvas.Display();
                isOpen = !isOpen;
            }
        }
        public void Stop()
        {
            if (isOpen)
            {
                Canvas canvas = Kern.canvas;
                canvas.Clear(Color.DarkGray);
                
                canvas.Display();
                isOpen = !isOpen;
            }
        }
    }
}
