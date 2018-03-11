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
        int ttl = 57;
        private static string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        private static byte[] buffer = Encoding.ASCII.GetBytes(data);


        public MainForm()
        {
            InitializeComponent();
            pingEventTimer.Interval = 1000;
            pingEventTimer.Start();

        }

        private void modbusTCPCom1_DataReceived(object sender, MfgControl.AdvancedHMI.Drivers.Common.PlcComEventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pingEventTimer_Tick(object sender, EventArgs e)
        {
            pingEventTimer.Stop();
            Ping pingHandler = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            options.Ttl = ttl;

            foreach (string node in ListBox_IPs_and_MB_adresses.Items)
            {
                string[] ListBox_Item_IP_and_MB_adress = node.Split(',');
                string nodeIP = ListBox_Item_IP_and_MB_adress[0];
                string nodeMB_address = ListBox_Item_IP_and_MB_adress[1];



                PingReply reply = pingHandler.Send(nodeIP, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    listBox_ping_results.Items.Add(string.Format("{0} Link UP, Roundtrip time = {1}", nodeIP, reply.RoundtripTime));
                    modbusTCPCom1.BeginInit();
                    modbusTCPCom1.Write(nodeMB_address.ToString(), "1");
                }
                else
                {
                    listBox_ping_results.Items.Add(string.Format("{0} Link DOWN,", nodeIP ));
                    modbusTCPCom1.Write(nodeMB_address.ToString(), "0");
                }

            }

            pingHandler.Dispose();
            pingEventTimer.Start();
        }

        private void listBox_ping_results_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_add_node_Click(object sender, EventArgs e)
        {
            if( textBox_Add_IP.Text != "" && textBox_Add_MB_address.Text != "")
            {
                string newNode = string.Format("{0}, {1}", textBox_Add_IP.Text, textBox_Add_MB_address.Text);
                ListBox_IPs_and_MB_adresses.Items.Add(newNode);
            }
        }

        private void pilotLight1_Click(object sender, EventArgs e)
        {

        }
    }
}
