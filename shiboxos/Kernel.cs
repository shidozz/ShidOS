using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Sys = Cosmos.System;
using Cosmos.System.Graphics.Extensions;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Graphics;
using System.Drawing;
using IL2CPU.API.Attribs;
using Cosmos.Core.IOGroup;
using Cosmos.System;
using Console = System.Console;
using System.Threading;
using shiboxos.utils;
using Appli = shiboxos.utils.App;
using shiboxos.Ssharp.src;
using System.IO;
//using shiboxos.App.Game;
using shiboxos.Utils;

namespace shiboxos
{
    public class Kernel : Sys.Kernel
    {
        //public static VBECanvas canvas;
        //public static VBEIOGroup VBEGroup;


        [ManifestResourceStream(ResourceName = "shiboxos.isoFiles.c.bmp")]
        public static byte[] backgroundImgB;




        [ManifestResourceStream(ResourceName = "shiboxos.isoFiles.font.psf")]
        public static byte[] BFont;




        public List<Appli> Apps = new();
        Bitmap bm;
        public static readonly Sys.ScanMaps.FR_Standard FR = new();
        public static readonly Sys.ScanMaps.US_Standard US = new();
        public static readonly Sys.ScanMaps.DE_Standard DE = new();
        public static readonly Sys.ScanMaps.TR_StandardQ TR = new();
        public static bool windows = false;
        public static bool isInitialized = false;
        public static string lang = "fr_FR";
        //readonly Sys.ScanMaps.GameController Manette = new();
        public static FS fs = new();
        protected override void BeforeRun()
        {
            Console.WriteLine("ShiboxKernel a demarrer avec succes ;)");
            
            KeyboardManager.SetKeyLayout(FR);

            //canvas = (VBECanvas) FullScreenCanvas.GetFullScreenCanvas(new Mode(1280, 720, ColorDepth.ColorDepth32));

            //canvas.Clear(Color.White);
            //windows = true;
            CommandHandler.init();
            CommandHandler.execute("clear");


        }

        protected override void Run()
        {
            try
            {

                bm = new(backgroundImgB);
                if (!windows)
                {
                    isInitialized = false;
                    Console.Write("> ");
                    string input = Console.ReadLine();
                    string[] inputs = input.Split(" ");
                    string cmd = inputs[0];
                    string[] args = inputs.Skip(1).ToArray();

                    CommandHandler.execute(cmd, args);
                } else
                {
                    //canvas.Clear(Color.White);
                    //canvas.DrawImage(bm, 0, 720);
                    //canvas.DrawRectangle(new(Color.Black), new((1280 / 2) - 25, (720 / 2) - 25), 50, 50);
                    //canvas.Display();
                }
            }
            catch (Exception e)
            {
                mDebugger.Send("Exception occurred: " + e.Message);
                Power.Shutdown();
            }
        }
    }
}
