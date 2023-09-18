using System;
using System.Drawing; // Color
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class ScreenSaver : Form
    {
        int tick = 25;
        int step = 4;

        int color;
        int direction;

        // Blue, Green, Light Blue, Orange, Pink, Purple, Red, Yellow
        Color[] colors = { Color.FromArgb(0, 0, 255), Color.FromArgb(0, 255, 0), Color.FromArgb(0, 255, 255), Color.FromArgb(255, 128, 0), Color.FromArgb(255, 0, 128), Color.FromArgb(128, 0, 255), Color.FromArgb(255, 0, 0), Color.FromArgb(255, 255, 0) };
        public ScreenSaver()
        {
            InitializeComponent();
        }

        private void ScreenSaver_Load(object sender, EventArgs e)
        {
            this.Bounds = Screen.FromControl(this).Bounds;

            color = (new Random()).Next(0, colors.Length);
            direction = (new Random()).Next(0, 4);

            pbLogo.Top = (new Random()).Next(0, this.Height - pbLogo.Height);
            pbLogo.Left = (new Random()).Next(0, this.Width - pbLogo.Width);
            pbLogo.BackColor = colors[color];

            Timer timer = new Timer();
            timer.Interval = tick;
            timer.Tick += MoveLogo;
            timer.Start();
        }

        private void MoveLogo(object sender, EventArgs e)
        {
            switch (direction)
            {
                case 0: // Top-Left
                    pbLogo.Top -= step;
                    pbLogo.Left -= step;
                    break;

                case 1: // Top-Right
                    pbLogo.Top -= step;
                    pbLogo.Left += step;
                    break;

                case 2: // Bottom-Left
                    pbLogo.Top += step;
                    pbLogo.Left -= step;
                    break;

                case 3: // Bottom-Right
                    pbLogo.Top += step;
                    pbLogo.Left += step;
                    break; 
            }
            CheckForWall();
        }

        private void CheckForWall()
        {
            if (pbLogo.Top < 0) // Top
            {
                if (direction == 0) direction = 2; // Top-Left > Bottom-Left
                if (direction == 1) direction = 3; // Top-Right > Bottom-Right
                ChangeColor();
                return;
            }
            if (pbLogo.Left < 0) // Left
            {
                if (direction == 0) direction = 1; // Top-Left > Top-Right
                if (direction == 2) direction = 3; // Bottom-Left > Bottom-Right
                ChangeColor();
                return;
            }
            if (pbLogo.Top >= this.Height - pbLogo.Height) // Bottom
            {
                if (direction == 2) direction = 0; // Bottom-Left > Top-Left
                if (direction == 3) direction = 1; // Bottom-Right > Top-Right
                ChangeColor();
                return;
            }
            if (pbLogo.Left >= this.Width - pbLogo.Width) // Right
            {
                if (direction == 1) direction = 0; // Top-Right > Top-Left
                if (direction == 3) direction = 2; // Bottom-Right > Bottom-Left
                ChangeColor();
                return;
            }
        }

        private void ChangeColor()
        {
            color++; if (color >= colors.Length) color = 0;
            pbLogo.BackColor = colors[color];
        }

        private void ScreenSaver_MouseMove(object sender, MouseEventArgs e)
        {
            //Application.Exit();
        }

        private void ScreenSaver_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void ScreenSaver_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Exit();
        }
    }
}
