using System;
using System.Drawing;
using System.Windows.Forms;

namespace dvdbounce
{
    partial class ScreenSaver : Form
    {
        private bool isActive = false;
        private Point mouseLocation;

        int step = 4;

        int color;
        int direction;

        // Blue, Green, Light Blue, Orange, Pink, Purple, Red, Yellow
        Color[] colors = { Color.FromArgb(0, 0, 255), Color.FromArgb(0, 255, 0), Color.FromArgb(0, 255, 255), Color.FromArgb(255, 128, 0), Color.FromArgb(255, 0, 128), Color.FromArgb(128, 0, 255), Color.FromArgb(255, 0, 0), Color.FromArgb(255, 255, 0) };

        public ScreenSaver()
        {
            InitializeComponent();
            SetupScreenSaver();
        }

        private void InitializeComponent()
        {
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.White;
            this.pbLogo.Image = global::dvdbounce.Properties.Resources.dvdpng;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(320, 191);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // ScreenSaver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.pbLogo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenSaver";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScreenSaverForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupScreenSaver()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.Capture = true;
            Cursor.Hide();

            color = (new Random()).Next(0, colors.Length);
            direction = (new Random()).Next(0, 4);

            pbLogo.Top = (new Random()).Next(0, this.Height - pbLogo.Height);
            pbLogo.Left = (new Random()).Next(0, this.Width - pbLogo.Width);
            pbLogo.BackColor = colors[color];
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Set IsActive and MouseLocation only the first time this event is called.
            if (!isActive)
            {
                mouseLocation = MousePosition;
                isActive = true;
            }
            else
            {
                // If the mouse has moved significantly since first call, close.
                if ((Math.Abs(MousePosition.X - mouseLocation.X) > 10) ||
                    (Math.Abs(MousePosition.Y - mouseLocation.Y) > 10))
                {
                    Application.Exit();
                }
            }
        }

        private void ScreenSaverForm_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Exit();
        }

        private void ScreenSaverForm_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        public void MoveLogo()
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
    }
}