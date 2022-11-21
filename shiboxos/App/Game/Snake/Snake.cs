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

namespace shiboxos.App.Game.Snake
{
    public class Snake : Appe
    {
        public List<Circle> snake = new();
        public Circle food = new();

        public int maxWidth;
        public int maxHeight;

        public int score;
        public int highScore;

        public Random rand = new Random();

        public bool goLeft, goRight, goDown, goUp = false;
        public PCScreenFont font;
        public bool isStarted;

        public Snake(string name = "Snake", string description = "Un Jeu superbe", bool isOpen = false) : base(name, description, isOpen)
        {
            font = PCScreenFont.LoadFont(Kern.BFont);
        }


        public void Start()
        {
            new Setting();
            RestartGame();
            Kern.windows = false;
        }

        public void Update()
        {
            Kern.canvas.Clear(Color.Black);
            KeyEvent key;
            if (KeyboardManager.TryReadKey(out key))
            {
                if (key.Key == ConsoleKeyEx.UpArrow && !goDown)
                {
                    goUp = true;
                    goLeft = false;
                    goRight = false;
                }
                if (key.Key == ConsoleKeyEx.LeftArrow && !goRight)
                {
                    goUp = false;
                    goDown = false;
                    goLeft = true;
                }
                if (key.Key == ConsoleKeyEx.DownArrow && !goUp)
                {
                    goDown = true;
                    goLeft = false;
                    goRight = false;
                }
                if (key.Key == ConsoleKeyEx.RightArrow && !goLeft)
                {
                    goUp = false;
                    goDown = false;
                    goRight = true;
                }
            }
            Pen snakeColour = new(Color.Black);
            for(int i = 0; i < snake.Count; i++)
            {
                if(i == 0)
                {
                    snakeColour.Color = Color.White;
                }
                else
                {
                    snakeColour.Color = Color.LightBlue;
                }
                Kern.canvas.DrawFilledRectangle(snakeColour, new(snake[i].X * Setting.Width, snake[i].Y * Setting.Height), Setting.Width, Setting.Height);
            }
            Kern.canvas.DrawFilledRectangle(new(Color.DarkRed), new(food.X * Setting.Width, food.Y * Setting.Height), Setting.Width, Setting.Height);
            
                


            for (int i = (snake.Count -1); i >=0 ; i--)
            {
                if(i == 0)
                {

                    if (goLeft)
                    {
                        snake[i].X--;
                    }
                    if (goRight)
                    {
                        snake[i].X++;
                    }
                    if (goUp)
                    {
                        snake[i].Y--;
                    }
                    if (goDown)
                    {
                        snake[i].Y++;
                    }
                    if (snake[i].X == food.X && snake[i].Y == food.Y)
                    {
                        EatFood();
                    }
                    if (snake[i].X < 0)
                    {
                        snake[i].X = maxWidth;
                    }
                    if (snake[i].X > maxWidth)
                    {
                        snake[i].X = 0;
                    }
                    if (snake[i].Y < 0)
                    {
                        snake[i].Y = maxHeight;
                    }
                    if (snake[i].Y > maxHeight)
                    {
                        snake[i].Y = 0;
                    }
                }
                else
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
                for(int j = 0; j < snake.Count; j++)
                {
                    if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
                    {
                        GameOver();
                    }
                }
            }
            string vScore = "Votre Score est de " + Convert.ToString(score) + " points";
            Kern.canvas.DrawString(vScore, font, new(Color.White), new((640 / 2) - ((vScore.Length / 2) * 8) ,20));
            Kern.canvas.Display();
            Thread.Sleep(1000 / 15);
        }
        private void EatFood()
        {
            score += 1;
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }
        private void RestartGame()
        {
            isOpen = true;
            if (Kern.isInitialized) {
                maxWidth = Kern.canvas.Mode.Columns / Setting.Width - 1;
                maxHeight = Kern.canvas.Mode.Rows / Setting.Height - 1;
            }
            else
            {

                Kern.canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(640, 480, ColorDepth.ColorDepth32));
                Kern.canvas.Clear(Color.Blue);
                Kern.isInitialized = true;
                maxWidth = Kern.canvas.Mode.Columns / Setting.Width - 1;
                maxHeight = Kern.canvas.Mode.Rows / Setting.Height - 1;
            }
            snake.Clear();

            score = 0;

            Circle head = new Circle { X = 10, Y = 5};

            snake.Add(head);

            for(int i = 0; i < 10; i++)
            {

                Circle body = new();
                snake.Add(body);
            }

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }
        private void GameOver()
        {
            isOpen = false;
            Kern.windows = true;
        }
        public void Stop()
        {
            GameOver();
        }
    }
    class Setting
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static string direction { get; set; }
        public Setting()
        {
            Width = 16;
            Height = 16;
            direction = "left";
        }
    }
}
