using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    class Food : PictureBox
    {
        public Food()
        {
            InitilizeFood();

        }
        private void InitilizeFood()
        {
            this.Width = 20;
            this.Height = 20;
            this.BackColor = Color.LightGreen;
        }
        private int Randomizer20()
        {
            Random rand = new Random();
            int numbers = 100 + rand.Next(0, 20) * 20;
            return numbers;
        }
        public void Randomize()
        {
            this.Location = new Point(Randomizer20(), Randomizer20());

        }

    }
}
