using System;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Win32; // Registry

namespace dvdbounce
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            LoadSettings();

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

        static void LoadSettings()
        {
            //HKU\.DEFAULT\Software\Microsoft\Windows\CurrentVersion\Screen Savers\
            //HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Screen Savers\
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Screensavers\DVD Bounce");
            if (rk == null) rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Screensavers\DVD Bounce");
            Properties.Settings.Default.Speed = Convert.ToInt16(rk.GetValue("Speed", 25));
            Properties.Settings.Default.Step = Convert.ToInt16(rk.GetValue("Step", 4));
            rk.Close();
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

            while (!Properties.Settings.Default.Exit)
            {
                for (int i = 0; i < index; i++)
                {
                    fScreenSaver[i].MoveLogo();
                    Application.DoEvents();
                }
                System.Threading.Thread.Sleep(Properties.Settings.Default.Speed);
            }

            Application.Run();
        }
    }
}