using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    public partial class Game : Form
    {
        int horVelocity = 0;
        int verVelocity = 0;
        int step = 20;
        Area area = new Area();
        Snake snake = new Snake();
        Timer timerMainMove = new Timer();

        public Game()
        {
            InitializeComponent();
            InitializeGame();
        }
        private void InitializeTimer()
        {
            timerMainMove.Interval = 500;
            timerMainMove.Tick += new EventHandler(TimerMainMove_Tick);
            timerMainMove.Start();
        }
        private void TimerMainMove_Tick(object sender, EventArgs e)
        {

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
        }

    }
}
