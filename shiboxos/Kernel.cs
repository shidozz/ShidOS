using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics.Extensions;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Graphics;
using System.Drawing;
using IL2CPU.API.Attribs;
using Cosmos.Core.IOGroup;
using Cosmos.System;
using Console = System.Console;
using Chip8 = shiboxos.Chip8.Chip8;
using System.Threading;
using shiboxos.App;
using shiboxos.App.Game.Snake;
using shiboxos.utils;
using Appli = shiboxos.utils.App;
//using shiboxos.App.Game;

namespace shiboxos
{
    public class Kernel : Sys.Kernel
    {
        public static Canvas canvas;

        [ManifestResourceStream(ResourceName = "shiboxos.isoFiles.b.bmp")]
        public static byte[] backgroundImgB; 
        settings settingsApp = new();

        Snake SnakeApp = new();
        [ManifestResourceStream(ResourceName = "shiboxos.isoFiles.font.psf")]
        public static byte[] BFont;
        
        public List<Appli> Apps = new();
        Bitmap bm;
        readonly Sys.ScanMaps.FR_Standard FR = new();
        public static bool windows = true;

        //readonly Sys.ScanMaps.GameController Manette = new();
        protected override void BeforeRun()
        {
            Console.WriteLine("ShiboxKernel a demarer avec succes ;)");
            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(640, 480, ColorDepth.ColorDepth32));
            canvas.Clear(Color.Blue);
            bm = new(backgroundImgB);
            KeyboardManager.SetKeyLayout(FR);
            Apps.Add(settingsApp);
            Apps.Add(SnakeApp);
        }

        protected override void Run()
        {
            try
            {
                KeyEvent key;
                if (windows)
                {
                    canvas.DrawImage(bm, 0, 0);

                    if (KeyboardManager.TryReadKey(out key))
                    {

                        /*if (key.Key == ConsoleKeyEx.S)
                        {
                            //canvas.Clear(Color.Black);
                            Chip8 chip8 = new();
                            chip8.initialiserCpu();
                            chip8.initialiserEcran();
                            chip8.initialiserPixel();
                            byte continuer = 1;

                            do
                            {
                                //On effectuera quatre opérations ici


                                chip8.updateEcran();
                                Thread.Sleep(16);
                            } while (continuer == 1);

                        }*/
                        if (key.Key == ConsoleKeyEx.S)
                        {
                            SnakeApp.Start();
                        }
                        if (key.Key == ConsoleKeyEx.A)
                        {
                            settingsApp.Start(BFont);
                        }
                        if (key.Key == ConsoleKeyEx.Escape)
                        {
                            Power.Shutdown();
                        }
                    }
                    canvas.Display();
                }
                else
                {
                    SnakeApp.Update();
                    /*foreach (Appli app in Apps)
                    {

                        if (KeyboardManager.TryReadKey(out key))
                        {
                            if(app.name == "Snake" && app.isOpen)
                            {
                                
                                if (key.Key == ConsoleKeyEx.S)
                                {
                                    SnakeApp.Stop();
                                }
                            }

                            if (key.Key == ConsoleKeyEx.A)
                            {
                                settingsApp.Stop();
                            }

                            if (key.Key == ConsoleKeyEx.Escape)
                            {
                                Power.Shutdown();
                            }
                        }

                    }*/

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
