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
        Random color = new Random();
        public Food()
        {
            InitilizeFood();

        }
        private void InitilizeFood()
        {
            this.Width = 20;
            this.Height = 20;
            this.BackColor = Color.FromArgb(color.Next(0,255), color.Next(0,255), color.Next(0,255));
        }
        private int FoodRandomizer()
        {
            Random rand = new Random();
            int val = rand.Next(100, 500);

            
            int leftOver = val % 20;
            int newVal = val + leftOver; 
            return newVal;
        }
    }
}
