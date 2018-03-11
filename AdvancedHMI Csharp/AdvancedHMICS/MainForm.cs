using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;

namespace PingToModbus
{

    public partial class MainForm : Form
    {

        int timeout = 1000;
        private static string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        private static byte[] buffer = Encoding.ASCII.GetBytes(data);


        public MainForm()
        {
            InitializeComponent();
            pingEventTimer.Interval = 1000;

        }

        private void modbusTCPCom1_DataReceived(object sender, MfgControl.AdvancedHMI.Drivers.Common.PlcComEventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pingEventTimer_Tick(object sender, EventArgs e)
        {
            Ping pingHandler = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            options.Ttl = 57;


            PingReply reply = pingHandler.Send(node_id.Text, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {

            }

        }
    }
}
