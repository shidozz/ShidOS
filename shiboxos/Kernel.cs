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
using Chip8 = shiboxos.Chip8.Chip8;
using System.Threading;
using shiboxos.App;
using shiboxos.App.Game.Snake;
using shiboxos.App.Game.Tetris;
using shiboxos.utils;
using Appli = shiboxos.utils.App;
using shiboxos.Ssharp.src;
using System.IO;
//using shiboxos.App.Game;
using static shiboxos.Ssharp.src.main;

namespace shiboxos
{
    public class Kernel : Sys.Kernel
    {
        public static Canvas canvas;

        [ManifestResourceStream(ResourceName = "shiboxos.isoFiles.b.bmp")]
        public static byte[] backgroundImgB; 
        settings settingsApp = new();

        Snake SnakeApp = new();
        Tetris TetrisApp = new();

        [ManifestResourceStream(ResourceName = "shiboxos.isoFiles.font.psf")]
        public static byte[] BFont;
        
        public List<Appli> Apps = new();
        Bitmap bm;
        readonly Sys.ScanMaps.FR_Standard FR = new();
        readonly Sys.ScanMaps.US_Standard US = new();
        readonly Sys.ScanMaps.DE_Standard DE = new();
        readonly Sys.ScanMaps.TR_StandardQ TR = new();
        public static bool windows = true;
        public static bool isInitialized = false;
        public static string lang = "fr_FR";
        //readonly Sys.ScanMaps.GameController Manette = new();
        protected override void BeforeRun()
        {
            Console.WriteLine("ShiboxKernel a demarer avec succes ;)");
            
            bm = new(backgroundImgB);
            KeyboardManager.SetKeyLayout(FR);
            Apps.Add(settingsApp);
            Apps.Add(SnakeApp);

            CClear();
        }

        protected override void Run()
        {
            try
            {
                
                if (windows)
                {
                    isInitialized = false;
                    Console.Write("> ");
                    string input = Console.ReadLine();
                    string[] inputs = input.Split(" ");
                    string cmd = inputs[0];
                    string[] args = inputs.Skip(1).ToArray();
                    //canvas.DrawImage(bm, 0, 0);

                    /*if (input.ToLower() == "chip8" || input.ToLower() == "chip")
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
                    if (cmd.ToLower() == "ssharp")
                    {
                        main.Start();
                    }
                    else if (cmd.ToLower() == "snake")
                    {
                        SnakeApp.Start();
                    }
                    else if (cmd.ToLower() == "tetris")
                    {
                        TetrisApp.Start();
                    }
                    else if (cmd.ToLower() == "clear" || cmd.ToLower() == "cls")
                    {
                        CClear();
                    }
                    else if (cmd.ToLower() == "settings" || cmd.ToLower() == "setting" || cmd.ToLower() == "param" || cmd.ToLower() == "parametre")
                    {
                        settingsApp.Start(BFont);
                    }
                    else if (cmd.ToLower() == "stop" || (cmd.ToLower() == "shutdown" && args[0].ToLower() == "-s") || (cmd.ToLower() == "shut" && args[0].ToLower() == "-s")|| cmd.ToLower() == "poweroff" || (cmd.ToLower() == "power" && args[0].ToLower() == "off"))
                    {
                        Console.WriteLine("La console est en train de s'eteindre !");
                        Power.Shutdown();
                    }
                    else if (cmd.ToLower() == "lang")
                    {
                        if (args == null || args.Length == 0)
                        {
                            Console.WriteLine("La langue du clavier est " + lang);
                        }
                        else if (args[0].ToLower() == "fr" || args[0].ToLower() == "fr_fr" || args[0].ToLower() == "fr-fr")
                        {
                            Console.WriteLine("La langue du clavier est passer de " + lang + " a " + "fr_FR");
                            lang = "fr_FR";
                            KeyboardManager.SetKeyLayout(FR);
                        }
                        else if (args[0].ToLower() == "us" || args[0].ToLower() == "en_us" || args[0].ToLower() == "en-us")
                        {
                            Console.WriteLine("La langue du clavier est passer de " + lang + " a " + "en_US");
                            lang = "en_US";
                            KeyboardManager.SetKeyLayout(US);
                        }
                        else if (args[0].ToLower() == "de" || args[0].ToLower() == "de_de" || args[0].ToLower() == "de-de")
                        {
                            Console.WriteLine("La langue du clavier est passer de " + lang + " a " + "de_DE");
                            lang = "de_DE";
                            KeyboardManager.SetKeyLayout(DE);
                        }
                        else if (args[0].ToLower() == "tr" || args[0].ToLower() == "tr_tr" || args[0].ToLower() == "tr-tr")
                        {
                            Console.WriteLine("La langue du clavier est passer de " + lang + " a " + "tr_TR");
                            lang = "tr_TR";
                            KeyboardManager.SetKeyLayout(TR);
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("La langue que vous avez renseignez n'existe pas dans mon repertoire !");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("La commande n'existe pas !");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                if (!windows)
                {
                    if (TetrisApp.isOpen == true)
                    {
                        TetrisApp.Update();
                    }
                    else if (SnakeApp.isOpen == true)
                    {
                        SnakeApp.Update();
                    }
                    canvas.Display();
                }
            }
            catch (Exception e)
            {
                mDebugger.Send("Exception occurred: " + e.Message);
                Power.Shutdown();
            }
        }
        public void CClear()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("#################################");
            Console.WriteLine("#                               #");
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" BIENVENUE SUR SHIDOS ! v0.0.1 ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("#");
            Console.WriteLine("#                               #");
            Console.WriteLine("#################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }
    }
}
