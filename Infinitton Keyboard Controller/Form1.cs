using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;
using System.IO;

namespace Infinitton_Keyboard_Controller
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);
        }
        ManagementObject myObj;

        public void Disable()
        {
            try
            {

                if (myObj != null)
                {
                    myObj.InvokeMethod("Disable", null, null);
                }
            }
            catch
            {

            }
        }

        public void Enable()
        {
            try
            {
                if (myObj != null)
                {
                    myObj.InvokeMethod("Enable", null, null);
                }
            }
            catch
            {

            }
        }

        private void Form1_Load(object sender, EventArgs ea)
        {
            try
            {

                this.BeginInvoke((Action)delegate
                {
                    this.Hide();
                });

                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity ");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (queryObj["DeviceID"].ToString().Contains(Properties.Settings.Default.SerialNo))
                    {
                        myObj = queryObj;
                        break;
                    }

                }

                Enable();



            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
            
            
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                Disable();
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                Enable();
            }
        }
    }
}
