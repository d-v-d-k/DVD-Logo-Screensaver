using System;
using System.Windows.Forms;
using System.Globalization;

namespace dvdbounce
{
    static class Program
    {
        static int tick = 10;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // Get the 2 character command line argument
                string arg = args[0].ToLower(CultureInfo.InvariantCulture).Trim().Substring(0, 2);
                switch (arg)
                {
                    case "/c":
                        // Show the options dialog
                        ShowOptions();
                        break;
                    case "/p":
                        // Don't do anything for preview
                        break;
                    case "/s":
                        // Show screensaver form
                        ShowScreenSaver();
                        break;
                    default:
                        MessageBox.Show("Invalid command line argument :" + arg, "Invalid Command Line Argument", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                // If no arguments were passed in, show the screensaver
                ShowScreenSaver();
            }
        }

        static void ShowOptions()
        {
            OptionsForm optionsForm = new OptionsForm();
            Application.Run(optionsForm);
        }

        static void ShowScreenSaver()
        {
            ScreenSaver[] fScreenSaver = new ScreenSaver[16];
            int index = 0;

            foreach (Screen screen in Screen.AllScreens)
            {
                fScreenSaver[index] = new ScreenSaver();
                fScreenSaver[index].Show();
                fScreenSaver[index].Location = screen.Bounds.Location;
                fScreenSaver[index].WindowState = FormWindowState.Maximized;
                index++;
            }

            while (true)
            {
                for (int i = 0; i < index; i++)
                {
                    fScreenSaver[i].MoveLogo();
                    Application.DoEvents();
                }
                System.Threading.Thread.Sleep(tick);
            }

            Application.Run();
        }
    }
}