using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadTryWinForm
{
    public partial class Form1 : Form
    {
        //List<Thread> threads = new List<Thread>();
        private static List<String> node_ips = new List<string>();
        private static List<String> global_outputs = new List<string>();
        private static int threadCount = 0;
        private static int number = 0;
        private static string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        private static byte[] buffer = Encoding.ASCII.GetBytes(data);
        
        public Form1()
        {
            InitializeComponent();
            node_ips.Add("10.181.5.34");
            node_ips.Add("10.181.5.35");
            node_ips.Add("10.181.5.36");
            node_ips.Add("10.181.5.37");
            node_ips.Add("10.181.5.38");
            timer_update_outputs.Start();

        }
        
        
        private void executePing()
        {
            //listBox_result.Items.Add("Started thread");
            threadCount++;
            int thisThreadNumber = threadCount;
            string thisIP = node_ips[thisThreadNumber - 1];
            global_outputs.Add(String.Format("Started thread: {0}, with IP: {1}", thisThreadNumber, thisIP));

            try
            {
                
                Ping pinghandler = new Ping();
                PingOptions options = new PingOptions();
                options.Ttl = 64;
                options.DontFragment = true;
                PingReply reply = pinghandler.Send(thisIP, 1000, buffer, options);

                if (reply.Status == IPStatus.Success)
                {
                    global_outputs.Add(String.Format("Ping Success from {0} at {1}ms", thisIP, reply.RoundtripTime));
                }
                else
                {
                    global_outputs.Add(String.Format("Ping failure from {0}", thisIP));
                }
            }
            catch
            {
                global_outputs.Add(String.Format("General Ping failure from {0}", thisIP));
            }

            global_outputs.Add(String.Format("Ending thread {0} ", thisThreadNumber));
            threadCount--;
        }


        private void button_start_Click(object sender, EventArgs e)
        {
            if (!timer_update_outputs.Enabled)
            {
                timer_update_outputs.Start();
            }

            //String ip_to_ping = node_ips[0];

            foreach (string ip in node_ips)
            {
                Thread pingThread = new Thread(new ThreadStart(executePing));
                pingThread.IsBackground = true;
                pingThread.Start();
            }




        }

        private void timer_update_outputs_Tick(object sender, EventArgs e)
        {
            listBox_result.Items.Clear();
            try
            {
                List<String> temp_global_outputs = global_outputs;
                foreach (string output in global_outputs)
                {
                    listBox_result.Items.Add(output);
                }
            }
            catch
            {
                listBox_result.Items.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            if (timer_update_outputs.Enabled)
            {
                timer_update_outputs.Stop();
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            global_outputs.Clear();
        }
    }
}
