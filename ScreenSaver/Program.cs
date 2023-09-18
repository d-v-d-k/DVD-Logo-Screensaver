using System;
using System.Windows.Forms;

namespace ScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                switch (args[0])
                {
                    case "/c":
                        MessageBox.Show("This screen saver has no options that you can set.", "DVD Logo Screen Saver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "/p":
                        
                        break;

                    default: // "/s"
                        break;
                }
            }

            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenSaver screensaver = new ScreenSaver();
                screensaver.Location = screen.Bounds.Location;
                screensaver.Show();
            }
            Application.Run();
        }
    }
}
