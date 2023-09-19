using System;
using System.Windows.Forms;
using Microsoft.Win32; // Registry

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
            LoadSettings();

            if (args.Length != 0)
            {
                if (args[0].StartsWith("/c")) // Configure
                {
                    Configure fConfigure = new Configure();
                    fConfigure.ShowDialog();
                    return;
                }

                if (args[0].StartsWith("/p")) // Preview
                {
                    // Run a preview of the screensaver
                    return;
                }
            }

            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenSaver fScreenSaver = new ScreenSaver();
                fScreenSaver.Location = screen.Bounds.Location;
                fScreenSaver.Show();
            }

            Application.Run();
        }
        static void LoadSettings()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Screensavers\DVD");
            if(rk == null) rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Screensavers\DVD");
            Properties.Settings.Default.Speed = Convert.ToInt16(rk.GetValue("Speed", 25));
            Properties.Settings.Default.Step = Convert.ToInt16(rk.GetValue("Step", 4));
            rk.Close();
        }
    }
}