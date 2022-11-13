using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = Cosmos.System.Graphics.Point;

namespace shiboxos.Chip8
{
    internal class Chip8
    {
        public struct CPU
        {
            public byte[] memoire; // la mémoire est en octets (8 bits), soit un tableau de 4096 byte (Uint8)
            public byte[] V;
            public UInt16 I;
            public UInt16[] saut;
            public byte nbrsaut;
            public byte compteurSon;
            public byte compteurJeu;
            public UInt16 pc;
            public CPU()
            {
                memoire = new byte[4096];
                V = new byte[16]; //le registre
                I = new UInt16(); //stocke une adresse mémoire ou dessinateur
                saut = new UInt16[16]; //pour gérer les sauts dans « mémoire », 16 au maximum
                nbrsaut = new byte(); //stocke le nombre de sauts effectués pour ne pas dépasser 16
                compteurJeu = new byte(); //compteur pour la synchronisation 
                compteurSon = new byte(); //compteur pour le son
                pc = new UInt16(); //pour parcourir le tableau « mémoire »
            }
        }
        public CPU cpu;
        public void initialiserCpu()
        {
            //On initialise le tout

            UInt16 i;

            for (i = 0; i < 4096; i++) //faisable avec memset, mais je n'aime pas cette fonction ^_^
            {
                cpu.memoire[i] = 0;
            }

            for (i = 0; i < 16; i++)
            {
                cpu.V[i] = 0;
                cpu.saut[i] = 0;
            }

            cpu.pc = 512;
            cpu.nbrsaut = 0;
            cpu.compteurJeu = 0;
            cpu.compteurSon = 0;
            cpu.I = 0;

        }
        public void decompter()
        {
            if (cpu.compteurJeu > 0)
                cpu.compteurJeu--;

            if (cpu.compteurSon > 0)
                cpu.compteurSon--;
        }
        public struct Vector2
        {
            public int x;
            public int y;
        }
        public struct PIXEL
        {
            public Vector2 position; //regroupe l'abscisse et l'ordonnée
            public byte couleur;   //comme son nom l'indique, c'est la couleur
        }
        public PIXEL[][] pixel = new PIXEL[64][];
        public void initialiserPixel()
        {
            byte x = 0, y = 0;

            for (x = 0; x < 64; x++)
            {
                for (y = 0; y < 32; y++)
                {
                    pixel[x][y].position.x = x * 8;
                    pixel[x][y].position.y = y * 8;
                    pixel[x][y].couleur = 0; //on met par défaut les pixels en noir
                }
            }

        }
        Canvas ecran;
        public void initialiserEcran()
        {
            ecran = Kernel.canvas;
            ecran.DrawFilledRectangle(new(Color.Black, 1), new Point(0, 0), 8, 8); //le pixel noir

        }
        public void dessinerPixel(PIXEL pixel)
        {
            if (pixel.couleur == 0)
                ecran.DrawFilledRectangle(new(Color.Black, 1), new Point(pixel.position.x, pixel.position.y), 8, 8); ; //le pixel blanc
            if (pixel.couleur == 1)
                ecran.DrawFilledRectangle(new(Color.White, 1), new Point(pixel.position.x, pixel.position.y), 8, 8); ; //le pixel blanc
        }
        public void effacerEcran()
        {
            //Pour effacer l'écran, on remet tous les pixels en noir

            byte x = 0, y = 0;
            for (x = 0; x < 64; x++)
            {
                for (y = 0; y < 32; y++)
                {
                    pixel[x][y].couleur = 0;
                }
            }
            ecran.Clear(Color.Black);
        }
        public void updateEcran()
        {
            //On dessine tous les pixels à l'écran
            byte x = 0, y = 0;

            for (x = 0; x < 64; x++)
            {
                for (y = 0; y < 32; y++)
                {
                    dessinerPixel(pixel[x][y]);
                }
            }
        }
    }
}
