using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    class Snake
    {
        public int HorizontalVelocity { get; set; } = 0;
        public int VerticalVelocity { get; set; } = 0;
        public int Step { get; set; } = 20;
        public List<PictureBox> snakePixels = new List<PictureBox>();

        public Snake()
        {
            InitializeSnake();
        }

        private void InitializeSnake()
        {
            PictureBox head;
            head = new PictureBox();
            head.Height = 20;
            head.Width = 20;
            head.BackColor = Color.Orange;
            head.Left = 300;
            head.Top = 300;
            snakePixels.Add(head);
            this.AddPixel(20);
            this.AddPixel(20);
        }
        public void AddPixel(int offSetLeft)
        {
            PictureBox snakePixel;
            snakePixel = new PictureBox();
            snakePixel.Height = 20;
            snakePixel.Width = 20;
            snakePixel.BackColor = Color.DarkGreen;
            snakePixel.Location = snakePixels[snakePixels.Count - 1].Location;
            snakePixel.Left += offSetLeft;
            snakePixel.BringToFront();
            snakePixels.Add(snakePixel);
        }
        public void Render(Form form)
        {
            foreach (var spixels in snakePixels)
            {
                form.Controls.Add(spixels);
                spixels.BringToFront();
            }
        }
        public void Move()
        {
            if (this.HorizontalVelocity == 0 && this.VerticalVelocity == 0)
            {
                return;
            }
            for (int i = snakePixels.Count - 1; i > 0; i--)
            {
                snakePixels[i].Location = snakePixels[i - 1].Location;
            }
            snakePixels[0].Left += this.HorizontalVelocity * this.Step;
            snakePixels[0].Top += this.VerticalVelocity * this.Step;
        }

    }
}
