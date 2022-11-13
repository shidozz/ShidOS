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

        public bool goLeft, goRight, goDown, goUp;
        


        public Snake(string name = "Snake", string description = "Un Jeu superbe", bool isOpen = false) : base(name, description, isOpen)
        {
        }


        public void Start()
        {
            new Setting();
            RestartGame();
            Kern.windows = false;
            isOpen = !isOpen;
            Kern.PrintDebug("Snake is starting");
        }

        public void Update()
        {
            Kern.canvas.Clear(Color.Black);
            KeyEvent key;
            if (KeyboardManager.TryReadKey(out key))
            {
                if (key.Key == ConsoleKeyEx.UpArrow && Setting.direction != "down")
                {
                    goUp = true;
                    goDown = false;
                    goLeft = false;
                    goRight = false;
                }
                if (key.Key == ConsoleKeyEx.LeftArrow && Setting.direction != "right")
                {
                    goUp = false;
                    goDown = false;
                    goLeft = true;
                    goRight = false;
                }
                if (key.Key == ConsoleKeyEx.DownArrow && Setting.direction != "up")
                {
                    
                    goUp = false;
                    goDown = true;
                    goLeft = false;
                    goRight = false;
                }
                if (key.Key == ConsoleKeyEx.RightArrow && Setting.direction != "left")
                {

                    goUp = false;
                    goDown = false;
                    goLeft = false;
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
                Kern.canvas.DrawFilledEllipse(snakeColour, new(snake[i].X * Setting.Width, snake[i].Y * Setting.Height), Setting.Width, Setting.Height);
            }
            Kern.canvas.DrawFilledEllipse(new(Color.DarkRed), new(food.X * Setting.Width, food.Y * Setting.Height), Setting.Width, Setting.Height);
            
            Kern.canvas.Display();
            if (goLeft)
            {
                Setting.direction = "left";
            }
            if (goRight)
            {
                Setting.direction = "right";
            }
            if (goUp)
            {
                Setting.direction = "up";
            }
            if (goDown)
            {
                Setting.direction = "down";
            }


            for (int i = (snake.Count -1); i >=0 ; i--)
            {
                if(i == 0)
                {
                    switch (Setting.direction)
                    {
                        case "left":
                            snake[i].X--;
                            break;
                        case "right":
                            snake[i].X++;
                            break;
                        case "up":
                            snake[i].Y--;
                            break;
                        case "down":
                            snake[i].Y++;
                            break;
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
            }
           

        }
        private void EatFood()
        {
        }
        private void RestartGame()
        {
            maxWidth = Kern.canvas.Mode.Columns / Setting.Width - 1;
            maxHeight = Kern.canvas.Mode.Rows / Setting.Height - 1;

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
