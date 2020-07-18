using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    public partial class Game : Form
    {
        Area area = new Area();
        Snake snake = new Snake();
        Timer timerMainMove = new Timer();
        Food food = new Food();
        bool lastmove = false;
        int score = 0;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            timerMainMove.Interval = 250;
            timerMainMove.Tick += new EventHandler(TimerMainMove_Tick);
            timerMainMove.Start();
        }
        private void TimerMainMove_Tick(object sender, EventArgs e)
        {
            lastmove = false;
            snake.Move();
            Collision();
            SnakeBorederCollision();
            Ouroboros();
        }
        private void InitializeGame()
        {
            this.Height = 600;
            this.Width = 600;
            
            this.Controls.Add(area);
            area.Top = 100;
            area.Left = 100;
            //area.Location = new Point(100, 100);

            //adding snake body
            snake.Render(this);

            //keybord press handeler
            this.KeyDown += Game_KeyDown;

            //food stuff 
            this.Controls.Add(food);
            food.BringToFront();
            food.Randomize();

            //score
            score = 0;
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lastmove)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        if (snake.HorizontalVelocity != -1)
                        {
                            snake.HorizontalVelocity = 1;
                            snake.VerticalVelocity = 0;
                        }
                        lastmove = true;
                        break;
                    case Keys.A:
                        if (snake.HorizontalVelocity != 1)
                        {
                            snake.HorizontalVelocity = -1;
                            snake.VerticalVelocity = 0;
                        }
                        lastmove = true;
                        break;
                    case Keys.W:
                        if (snake.VerticalVelocity != 1)
                        {
                            snake.HorizontalVelocity = 0;
                            snake.VerticalVelocity = -1;
                        }
                        lastmove = true;
                        break;
                    case Keys.S:
                        if (snake.VerticalVelocity != -1)
                        {
                            snake.HorizontalVelocity = 0;
                            snake.VerticalVelocity = 1;
                        }
                        lastmove = true;
                        break;
                }
            }
        }
        private void Collision()
        {
            while (snake.snakePixels[0].Bounds.IntersectsWith(food.Bounds))
            {
                SetFoodLocation();
                snake.AddPixel(0);
                snake.Render(this);
                score += 10;
            }
        }
        private void SetFoodLocation()
        {
            bool touch;
            do
            {
                food.Randomize();
                touch = false;
                foreach (var sp in snake.snakePixels)
                {
                    if (sp.Location == food.Location)
                    {
                        touch = true;
                        break;
                    }
                }
            }
            while (touch);
        }
        private void SnakeBorederCollision()
        {
            if (!snake.snakePixels[0].Bounds.IntersectsWith(area.Bounds))
            {
                GameOver();
            }
        }
        private void GameOver()
        {
            timerMainMove.Stop();
            MessageBox.Show("Game over! Your score: " + score);
        }
        private void Ouroboros()
        {
            for (int i = 1; i < snake.snakePixels.Count; i++)
            {
                if (snake.snakePixels[0].Bounds.IntersectsWith(snake.snakePixels[i].Bounds))
                {
                    GameOver();
                }
            }
        }

    }
}
