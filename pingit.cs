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

namespace Pinglogger
{
    public partial class PingLogger : Form
    {
        private bool connected = false;
        private int save_interval_minutes = 10;
        private string[] eventlog_lines;
        List<string> events = new List<string>();
        int timeout, ttl;
        static bool running = false;

        private static string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        private static byte[] buffer = Encoding.ASCII.GetBytes(data);
        private List<string> tracert_result = new List<string>();
        private static List<string> trace_ips = new List<string>();
        private static bool tracedone = false;
        private static bool pingerror = false;
        private bool all_pinged_at_pingerror = false;
        private bool got_ping = false;

        List<string> traceResults_ = new List<string>();

        public PingLogger()
        {
            InitializeComponent();
            pingtimer.Interval = 1000;
            event_timer.Interval = 3200;
            SaveTimer.Interval = 60000;
            timeout = 120;
            ttl = 57;
            tracert_interval_timer.Interval = 240000;
           
            timeOut_c_textBox.Text = timeout.ToString();
            ttl_c_textBox.Text = ttl.ToString();
            pi_c_textBox.Text = pingtimer.Interval.ToString();
            ft_c_textBox.Text = event_timer.Interval.ToString();
            si_c_textBox.Text = (SaveTimer.Interval / 60000).ToString();




            timeout_label.Text = String.Format("Timeout = {0} ms", timeout.ToString());
            TTL_label.Text = String.Format("TTL = {0} hops", ttl.ToString());
            save_interval_label.Text = String.Format("Save every {0} minutes", (SaveTimer.Interval/60000).ToString());
            ping_interval_label.Text = String.Format("Ping-interval = {0} ms", pingtimer.Interval.ToString());
            event_filter_label.Text = String.Format("Alarm-filter_time = {0} ms", event_timer.Interval.ToString());


        }

         ~PingLogger()
        {
  
        }



        private void node_id_TextChanged(object sender, EventArgs e)
        {
            pingtimer.Stop();
            SaveTimer.Stop();
            tracert_interval_timer.Stop();
            ping_event_box.Items.Clear();
            connected = false;
            tracedone = false;
            running = false;
        }

        private void start_ping_Click(object sender, EventArgs e)
        {
            if (node_id.Text != "")
            {
                pingtimer.Start();
                SaveTimer.Start();
                tracert_interval_timer.Start();
                running = true;
                tracert_interval_timer.Interval = 5000;
            }
            else
            {
                ping_logg.Items.Add("Please input node IP or hostname");
            }


        }

        private void stop_ping_btn_Click(object sender, EventArgs e)
        {
            pingtimer.Stop();
            SaveTimer.Stop();
            tracert_interval_timer.Stop();
            ping_event_box.Items.Clear();
            connected = false;
            tracedone = false;
            running = false;
        }

        private void pingtimer_Tick(object sender, EventArgs e)
        {

            
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;
            options.Ttl = ttl;

            //int timeout = 12;
            try
            {
                if (ping_logg.Items.Count > 10)
                {
                    ping_logg.Items.Clear();
                }
                PingReply reply = pingSender.Send(node_id.Text, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {

                    string add_log_item = String.Format("{0} ping success at {1}ms ", node_id.Text, reply.RoundtripTime.ToString());
                    ping_logg.Items.Add(add_log_item);
                    
                    event_timer.Stop();
                    

                    if (connected == false)
                    {
                        string datetime = DateTime.Now.ToString();
                        string eventstring = String.Format("Node {0} link up at {1}.", node_id.Text, datetime);
                        ping_event_box.Items.Add(eventstring);
                        events.Add(eventstring);

                        event_timer.Stop();
                        connected = true;
                        pingerror = false;
                        got_ping = true;
                    }
                }
                else
                {
                    event_timer.Start();
                    ping_logg.Items.Add("ping error");
                    tracert_interval_timer.Interval = 5000;
                    pingerror = true;
                    got_ping = false;
                }



            }
            catch
            {
                ping_logg.Items.Add("Could not execute ping");

            }
            
            if (pingerror &&  !all_pinged_at_pingerror)
            {
                if (tracedone)
                {
                    trace_listBox.Items.Add("No ping event. Checking path\r");
                    events.Add("No ping event. Checking path\r");
                }

                Ping pingTrace = new Ping();
                PingOptions traceOptions = new PingOptions();
                traceOptions.DontFragment = true;
                traceOptions.Ttl = ttl;
                foreach(string t_address in trace_ips)
                {
                    PingReply traceReply = pingTrace.Send(t_address, timeout, buffer, options);
                    if (traceReply.Status == IPStatus.Success)
                    {
                        trace_listBox.Items.Add(string.Format("Trace link UP to {0} \ttimestamp: {1}", t_address, DateTime.Now));
                        events.Add(string.Format("Trace link UP to {0} \ttimestamp: {1}", t_address, DateTime.Now));
                    }
                    else
                    {
                        trace_listBox.Items.Add(string.Format("Trace link DOWN to {0} \ttimestamp: {1}", t_address, DateTime.Now));
                        events.Add("No ping event. Checking path\r");
                        events.Add(string.Format("Trace link DOWN to {0} \ttimestamp: {1}", t_address, DateTime.Now));
                    }
                    

                }
                pingTrace.Dispose();
                all_pinged_at_pingerror = true;
            }
            if (!pingerror)
            {
                all_pinged_at_pingerror = false;
            }
            pingSender.Dispose();

        }

        
        private void event_timer_Tick(object sender, EventArgs e)
        {   
            string datetime = DateTime.Now.ToString();
            string eventstring = String.Format("No link to node {0} at {1}.", node_id.Text, datetime);



            if (connected == true)
            {
                ping_event_box.Items.Add(eventstring);
                events.Add(eventstring);
                connected = false;
            }
        }

        private void SaveTimer_Tick(object sender, EventArgs e)
        {
            string path = @"C:\PingloggerSaves\";
            try
            {
                bool folderExists = Directory.Exists(path);
                if (!folderExists)
                    Directory.CreateDirectory(path);
            }
            catch
            {
                ping_event_box.Items.Add("Could not create folder");
            }

            try
            {

                string fullpath = string.Format("{0}{1} Savelog {2}.txt", path, node_id.Text, DateTime.Now.ToShortDateString());
                string header = string.Format("\r###############\r Saved log at {0} \r################\r\r", DateTime.Now.ToString());
                System.IO.StreamWriter file = new System.IO.StreamWriter(fullpath, true);

                file.WriteLine("\r");
                file.WriteLine("\r");
                file.WriteLine(header);
                
                file.WriteLine("\r");
                //foreach (string t in trace_listBox.Items)
                //{
                //events.Add(t);
                //}

                foreach (string line in events)
                {
                    file.WriteLine(line);

                }
                if( events.Count == 0 && connected == true)
                {
                    file.WriteLine("\rNo events. Still connected\r");
                }
                if (events.Count == 0 && connected == false)
                {
                    file.WriteLine("\rNo events. Still disconnected\r");
                }



                file.Close();
                events.Clear();
                trace_listBox.Items.Clear();
                trace_listBox.Items.Add(string.Format("saved to logg at {0}", DateTime.Now.ToString()));

            }
            catch
            {
                ping_event_box.Items.Add("Could not save to file");
            }

        }

        private void tracert_interval_timer_Tick(object sender, EventArgs e)
        {
            tracert_interval_timer.Interval = 240000;
            pingtimer.Stop();
            SaveTimer.Stop();
            event_timer.Stop();



            if (running && got_ping)
            {
                tracert_result.Clear();
                trace_listBox.Items.Add("Tracing....");
                trace_listBox.Update();
                Traceroute(node_id.Text);
                tracert_result.AddRange(traceResults_);
                traceResults_.Clear();
                trace_listBox.Items.Clear();
                foreach (string i in tracert_result)
                {
                    trace_listBox.Items.Add(i);
                    char[] separators = { ' ', '\r' };
                    string[] tokens = i.Split(separators);

                }
                
                tracedone = true;
              
            }
            pingtimer.Start();
        }

        public bool Traceroute(string ipAddress)

        {
            tracert_interval_timer.Stop();
            bool trace_ok = false;

                trace_listBox.Items.Add("Tracing.... in tracerout  try");



       


            using (Ping pingSender_T = new Ping())
            {
                PingOptions pingOptions = new PingOptions();
                System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
                byte[] bytes = new byte[32];
                pingOptions.DontFragment = true;
                pingOptions.Ttl = 1;
                int maxHops = 30;
                string addressname = "";

                traceResults_.Add( string.Format("Traced route to {0} over a maximum of {1} hops:",ipAddress, maxHops));
                trace_ips.Clear();


                for (int i = 1; i < maxHops + 1; i++)
                {
                    
                    stopWatch.Reset();
                    stopWatch.Start();
                    PingReply pingReply_ = pingSender_T.Send(ipAddress, 3000, new byte[32], pingOptions);
                    try
                    {
                        addressname = pingReply_.Address.ToString();
                    }
                    catch
                    {
                        addressname = "Unresolved address";
                    }

                    stopWatch.Stop();
                    try
                    {
                            
                            if (stopWatch.ElapsedMilliseconds > 30000)
                        {
                            trace_ok = false;

                            


                            traceResults_.Add(string.Format("trace failed {0} ms\t{1}", i, addressname));
                            events.Add(string.Format("trace failed {0} ms\t{1}", i, addressname));
                            break;
                        }
                    traceResults_.Add(string.Format("{0}\t{1} ms\t{2}", i, stopWatch.ElapsedMilliseconds, addressname));
                        events.Add(string.Format("{0}\t{1} ms\t{2}", i, stopWatch.ElapsedMilliseconds, addressname));
                        trace_ips.Add(pingReply_.Address.ToString());
                    }
                    catch
                    {
                            trace_listBox.Items.Add("Tracing.... in tracerout  inner catch");
                            
                        }

                    if (pingReply_.Status == IPStatus.Success)

                    {
                        trace_ok = true;
                        break;
                    }


                    pingOptions.Ttl++;
                }

                    pingSender_T.Dispose();
                }

            tracert_interval_timer.Start();
            SaveTimer.Start();
            event_timer.Start();
            return trace_ok;

        }




        //
        //
        //
        //
        //
        private void add_session_btn_Click(object sender, EventArgs e)
        {
            PingLogger form2 = new PingLogger();
            form2.Show();

        }

        private void ping_logg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void autosave_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }



        }

        private void timeout_label_Click(object sender, EventArgs e)
        {

        }

        private void TTL_label_Click(object sender, EventArgs e)
        {

        }

        private void ping_interval_label_Click(object sender, EventArgs e)
        {

        }

        private void set_timeout_btn_Click(object sender, EventArgs e)
        {
            if (timeOut_i_textBox.Text != "")
            {
                try
                {
                    timeout = Convert.ToInt32(timeOut_i_textBox.Text);
                    timeOut_c_textBox.Text = timeout.ToString();
                    timeout_label.Text = String.Format("Timeout = {0} ms", timeout.ToString());
                }
                catch
                {
                    timeOut_i_textBox.Text = "try again";
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void set_ttl_btn_Click(object sender, EventArgs e)
        {
            if (ttl_i_textBox.Text != "")
            {
                try
                {
                    ttl = Convert.ToInt32(ttl_i_textBox.Text);
                    ttl_c_textBox.Text = ttl.ToString();
                    TTL_label.Text = String.Format("TTL = {0} hops", ttl.ToString());
                }
                catch
                {
                    ttl_i_textBox.Text = "Try again";
                }
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void set_ping_int_btn_Click(object sender, EventArgs e)
        {
            if (pi_i_textBox.Text != "")
            {
                try
                {
                    pingtimer.Interval = Convert.ToInt32(pi_i_textBox.Text);
                    pi_c_textBox.Text = pingtimer.Interval.ToString();
                    ping_interval_label.Text = String.Format("Ping interval = {0} ms ", pingtimer.Interval.ToString());
                }
                catch
                {
                    pi_c_textBox.Text = "Try again";
                }
            }
        }

        private void set_ft_btn_Click(object sender, EventArgs e)
        {
            if (ft_i_textBox.Text != "")
            {
                try
                {
                    event_timer.Interval = Convert.ToInt32(ft_i_textBox.Text);
                    ft_c_textBox.Text = (event_timer.Interval).ToString();
                    event_filter_label.Text = String.Format("Event Filter time = {0} ms", event_timer.Interval.ToString());
                }
                catch
                {
                    ft_i_textBox.Text = "Try again";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ping_event_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void set_save_int_btn_Click(object sender, EventArgs e)
        {
            if (si_i_textBox.Text != "")
            {
                try
                {
                    SaveTimer.Interval = Convert.ToInt32(si_i_textBox.Text) * 60000;
                    si_c_textBox.Text = (SaveTimer.Interval / 60000).ToString();
                    save_interval_label.Text = String.Format("Save every {0} minutes", (SaveTimer.Interval / 60000).ToString());
                }
                catch
                {
                    si_c_textBox.Text = "Try again";
                }

            }

        }
    }

}

