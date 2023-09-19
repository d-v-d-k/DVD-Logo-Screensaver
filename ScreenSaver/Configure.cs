using System;
using System.Windows.Forms;
using Microsoft.Win32; // Registry

namespace ScreenSaver
{
    public partial class Configure : Form
    {
        public Configure()
        {
            InitializeComponent();
        }

        private void Configure_Load(object sender, EventArgs e)
        {
            tbSpeed.Value = Properties.Settings.Default.Speed;
            tbStep.Value = Properties.Settings.Default.Step;
            tbSpeed_Scroll(sender, e);
            tbStep_Scroll(sender, e);
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            gbSpeed.Text = "Speed (" + tbSpeed.Value + " ms)";
        }

        private void tbStep_Scroll(object sender, EventArgs e)
        {
            gbStep.Text = "Step (" + tbStep.Value + " pixels)";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Screensavers\DVD", true);
            rk.SetValue("Speed", tbSpeed.Value, RegistryValueKind.DWord);
            rk.SetValue("Step", tbStep.Value, RegistryValueKind.DWord);
            rk.Close();

            this.Close();
        }
    }
}