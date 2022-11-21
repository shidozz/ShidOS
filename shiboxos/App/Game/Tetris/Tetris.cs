using Cosmos.System.Graphics;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appe = shiboxos.utils.App;
using Kern = shiboxos.Kernel;
using Cosmos.System;
using System.Threading;
using Cosmos.System.Graphics.Fonts;

namespace shiboxos.App.Game.Tetris
{
    public class Tetris : Appe
    {

        public int maxWidth;
        public int maxHeight;

        public int score;
        public int highScore;

        public Random rand = new Random();

        public bool goLeft, goRight, goDown, goUp;
        public PCScreenFont font;
        public bool isStarted;

        public Tetris(string name = "Tetris", string description = "Un Autre Jeu Superbe", bool isOpen = false) : base(name, description, isOpen)
        {
            font = PCScreenFont.LoadFont(Kern.BFont);
        }


        public void Start()
        {
            Kern.windows = false;
            isOpen = !isOpen;
            Kern.PrintDebug("Tetris is starting");
        }

        public void Update()
        {
            Kern.canvas.Clear(Color.Black);
            KeyEvent key;

            if (!Kern.isInitialized)
            {
                Kern.canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(640, 480, ColorDepth.ColorDepth32));
                Kern.canvas.Clear(Color.Blue);
                Kern.isInitialized = true;
            }
            Kern.canvas.Display();
            Thread.Sleep(1000 / 15 + (score / 2));
        }
        public void Stop()
        {
        }
    }
}
