namespace Pinglogger
{
    partial class PingLogger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.start_ping = new System.Windows.Forms.Button();
            this.node_id = new System.Windows.Forms.TextBox();
            this.node_id_label = new System.Windows.Forms.Label();
            this.ping_logg = new System.Windows.Forms.ListBox();
            this.pingtimer = new System.Windows.Forms.Timer(this.components);
            this.stop_ping_btn = new System.Windows.Forms.Button();
            this.ping_event_box = new System.Windows.Forms.ListBox();
            this.event_timer = new System.Windows.Forms.Timer(this.components);
            this.SaveTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.add_session_btn = new System.Windows.Forms.Button();
            this.timeout_label = new System.Windows.Forms.Label();
            this.TTL_label = new System.Windows.Forms.Label();
            this.save_interval_label = new System.Windows.Forms.Label();
            this.ping_interval_label = new System.Windows.Forms.Label();
            this.event_filter_label = new System.Windows.Forms.Label();
            this.main_tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.trace_log_lable = new System.Windows.Forms.Label();
            this.event_log_label = new System.Windows.Forms.Label();
            this.ping_log_label = new System.Windows.Forms.Label();
            this.trace_listBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.si_i_textBox = new System.Windows.Forms.TextBox();
            this.save_int_update_label = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ft_i_textBox = new System.Windows.Forms.TextBox();
            this.ft_update_label = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pi_i_textBox = new System.Windows.Forms.TextBox();
            this.pingint_update_label = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ttl_i_textBox = new System.Windows.Forms.TextBox();
            this.ttl_update_label = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.timeOut_i_textBox = new System.Windows.Forms.TextBox();
            this.timout_update_label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.si_c_textBox = new System.Windows.Forms.TextBox();
            this.save_interval_c_label = new System.Windows.Forms.Label();
            this.set_save_int_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ft_c_textBox = new System.Windows.Forms.TextBox();
            this.filter_c_label = new System.Windows.Forms.Label();
            this.set_ft_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pi_c_textBox = new System.Windows.Forms.TextBox();
            this.ping_interval_c_label = new System.Windows.Forms.Label();
            this.set_ping_int_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ttl_c_textBox = new System.Windows.Forms.TextBox();
            this.TTL_c_label = new System.Windows.Forms.Label();
            this.set_ttl_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeOut_c_textBox = new System.Windows.Forms.TextBox();
            this.timout_config_label = new System.Windows.Forms.Label();
            this.set_timeout_btn = new System.Windows.Forms.Button();
            this.tracert_interval_timer = new System.Windows.Forms.Timer(this.components);
            this.save_to_log_btn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.main_tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_ping
            // 
            this.start_ping.BackColor = System.Drawing.Color.Gainsboro;
            this.start_ping.Location = new System.Drawing.Point(28, 328);
            this.start_ping.Margin = new System.Windows.Forms.Padding(2);
            this.start_ping.Name = "start_ping";
            this.start_ping.Size = new System.Drawing.Size(99, 27);
            this.start_ping.TabIndex = 0;
            this.start_ping.Text = "Start monitoring";
            this.start_ping.UseVisualStyleBackColor = false;
            this.start_ping.Click += new System.EventHandler(this.start_ping_Click);
            // 
            // node_id
            // 
            this.node_id.Location = new System.Drawing.Point(222, 17);
            this.node_id.Margin = new System.Windows.Forms.Padding(2);
            this.node_id.Name = "node_id";
            this.node_id.Size = new System.Drawing.Size(202, 20);
            this.node_id.TabIndex = 1;
            this.node_id.Text = "10.181.5.35";
            this.node_id.TextChanged += new System.EventHandler(this.node_id_TextChanged);
            // 
            // node_id_label
            // 
            this.node_id_label.AutoSize = true;
            this.node_id_label.Location = new System.Drawing.Point(24, 19);
            this.node_id_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.node_id_label.Name = "node_id_label";
            this.node_id_label.Size = new System.Drawing.Size(180, 13);
            this.node_id_label.TabIndex = 2;
            this.node_id_label.Text = "IP eller maskinnavn som skal pinges:";
            // 
            // ping_logg
            // 
            this.ping_logg.FormattingEnabled = true;
            this.ping_logg.Location = new System.Drawing.Point(28, 163);
            this.ping_logg.Margin = new System.Windows.Forms.Padding(2);
            this.ping_logg.Name = "ping_logg";
            this.ping_logg.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ping_logg.Size = new System.Drawing.Size(223, 147);
            this.ping_logg.TabIndex = 3;
            this.ping_logg.SelectedIndexChanged += new System.EventHandler(this.ping_logg_SelectedIndexChanged);
            // 
            // pingtimer
            // 
            this.pingtimer.Interval = 1000;
            this.pingtimer.Tick += new System.EventHandler(this.pingtimer_Tick);
            // 
            // stop_ping_btn
            // 
            this.stop_ping_btn.BackColor = System.Drawing.Color.Gainsboro;
            this.stop_ping_btn.Location = new System.Drawing.Point(152, 328);
            this.stop_ping_btn.Margin = new System.Windows.Forms.Padding(2);
            this.stop_ping_btn.Name = "stop_ping_btn";
            this.stop_ping_btn.Size = new System.Drawing.Size(99, 27);
            this.stop_ping_btn.TabIndex = 4;
            this.stop_ping_btn.Text = "Stop monitoring";
            this.stop_ping_btn.UseVisualStyleBackColor = false;
            this.stop_ping_btn.Click += new System.EventHandler(this.stop_ping_btn_Click);
            // 
            // ping_event_box
            // 
            this.ping_event_box.FormattingEnabled = true;
            this.ping_event_box.Location = new System.Drawing.Point(268, 163);
            this.ping_event_box.Margin = new System.Windows.Forms.Padding(2);
            this.ping_event_box.Name = "ping_event_box";
            this.ping_event_box.Size = new System.Drawing.Size(455, 147);
            this.ping_event_box.TabIndex = 5;
            this.ping_event_box.SelectedIndexChanged += new System.EventHandler(this.ping_event_box_SelectedIndexChanged);
            // 
            // event_timer
            // 
            this.event_timer.Interval = 5000;
            this.event_timer.Tick += new System.EventHandler(this.event_timer_Tick);
            // 
            // SaveTimer
            // 
            this.SaveTimer.Tick += new System.EventHandler(this.SaveTimer_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // add_session_btn
            // 
            this.add_session_btn.Location = new System.Drawing.Point(1028, 402);
            this.add_session_btn.Margin = new System.Windows.Forms.Padding(2);
            this.add_session_btn.Name = "add_session_btn";
            this.add_session_btn.Size = new System.Drawing.Size(84, 28);
            this.add_session_btn.TabIndex = 6;
            this.add_session_btn.Text = "Add Session";
            this.add_session_btn.UseVisualStyleBackColor = true;
            this.add_session_btn.Click += new System.EventHandler(this.add_session_btn_Click);
            // 
            // timeout_label
            // 
            this.timeout_label.AutoSize = true;
            this.timeout_label.Location = new System.Drawing.Point(24, 49);
            this.timeout_label.Name = "timeout_label";
            this.timeout_label.Size = new System.Drawing.Size(73, 13);
            this.timeout_label.TabIndex = 7;
            this.timeout_label.Text = "Timeout_label";
            this.timeout_label.Click += new System.EventHandler(this.timeout_label_Click);
            // 
            // TTL_label
            // 
            this.TTL_label.AutoSize = true;
            this.TTL_label.Location = new System.Drawing.Point(24, 64);
            this.TTL_label.Name = "TTL_label";
            this.TTL_label.Size = new System.Drawing.Size(27, 13);
            this.TTL_label.TabIndex = 8;
            this.TTL_label.Text = "TTL";
            this.TTL_label.Click += new System.EventHandler(this.TTL_label_Click);
            // 
            // save_interval_label
            // 
            this.save_interval_label.AutoSize = true;
            this.save_interval_label.Location = new System.Drawing.Point(179, 79);
            this.save_interval_label.Name = "save_interval_label";
            this.save_interval_label.Size = new System.Drawing.Size(69, 13);
            this.save_interval_label.TabIndex = 9;
            this.save_interval_label.Text = "Save interval";
            // 
            // ping_interval_label
            // 
            this.ping_interval_label.AutoSize = true;
            this.ping_interval_label.Location = new System.Drawing.Point(25, 79);
            this.ping_interval_label.Name = "ping_interval_label";
            this.ping_interval_label.Size = new System.Drawing.Size(66, 13);
            this.ping_interval_label.TabIndex = 10;
            this.ping_interval_label.Text = "Ping-Interval";
            this.ping_interval_label.Click += new System.EventHandler(this.ping_interval_label_Click);
            // 
            // event_filter_label
            // 
            this.event_filter_label.AutoSize = true;
            this.event_filter_label.Location = new System.Drawing.Point(179, 64);
            this.event_filter_label.Name = "event_filter_label";
            this.event_filter_label.Size = new System.Drawing.Size(51, 13);
            this.event_filter_label.TabIndex = 11;
            this.event_filter_label.Text = "Filter time";
            // 
            // main_tabs
            // 
            this.main_tabs.Controls.Add(this.tabPage1);
            this.main_tabs.Controls.Add(this.tabPage2);
            this.main_tabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.main_tabs.Location = new System.Drawing.Point(-3, 1);
            this.main_tabs.Name = "main_tabs";
            this.main_tabs.SelectedIndex = 0;
            this.main_tabs.Size = new System.Drawing.Size(1133, 396);
            this.main_tabs.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.trace_log_lable);
            this.tabPage1.Controls.Add(this.event_log_label);
            this.tabPage1.Controls.Add(this.ping_log_label);
            this.tabPage1.Controls.Add(this.trace_listBox);
            this.tabPage1.Controls.Add(this.node_id);
            this.tabPage1.Controls.Add(this.event_filter_label);
            this.tabPage1.Controls.Add(this.ping_event_box);
            this.tabPage1.Controls.Add(this.node_id_label);
            this.tabPage1.Controls.Add(this.stop_ping_btn);
            this.tabPage1.Controls.Add(this.ping_interval_label);
            this.tabPage1.Controls.Add(this.ping_logg);
            this.tabPage1.Controls.Add(this.start_ping);
            this.tabPage1.Controls.Add(this.timeout_label);
            this.tabPage1.Controls.Add(this.save_interval_label);
            this.tabPage1.Controls.Add(this.TTL_label);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1125, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Monitoring";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // trace_log_lable
            // 
            this.trace_log_lable.AutoSize = true;
            this.trace_log_lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trace_log_lable.Location = new System.Drawing.Point(753, 143);
            this.trace_log_lable.Name = "trace_log_lable";
            this.trace_log_lable.Size = new System.Drawing.Size(40, 13);
            this.trace_log_lable.TabIndex = 15;
            this.trace_log_lable.Text = "Trace";
            // 
            // event_log_label
            // 
            this.event_log_label.AutoSize = true;
            this.event_log_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.event_log_label.Location = new System.Drawing.Point(268, 144);
            this.event_log_label.Name = "event_log_label";
            this.event_log_label.Size = new System.Drawing.Size(64, 13);
            this.event_log_label.TabIndex = 14;
            this.event_log_label.Text = "Event_log";
            // 
            // ping_log_label
            // 
            this.ping_log_label.AutoSize = true;
            this.ping_log_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ping_log_label.Location = new System.Drawing.Point(28, 145);
            this.ping_log_label.Name = "ping_log_label";
            this.ping_log_label.Size = new System.Drawing.Size(57, 13);
            this.ping_log_label.TabIndex = 13;
            this.ping_log_label.Text = "Ping Log";
            // 
            // trace_listBox
            // 
            this.trace_listBox.FormattingEnabled = true;
            this.trace_listBox.Location = new System.Drawing.Point(753, 163);
            this.trace_listBox.Name = "trace_listBox";
            this.trace_listBox.Size = new System.Drawing.Size(345, 147);
            this.trace_listBox.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1125, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Config";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(267, 47);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 13);
            this.label21.TabIndex = 36;
            this.label21.Text = "Update";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(34, 47);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 13);
            this.label20.TabIndex = 35;
            this.label20.Text = "Current";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(332, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "min";
            // 
            // si_i_textBox
            // 
            this.si_i_textBox.Location = new System.Drawing.Point(245, 144);
            this.si_i_textBox.Name = "si_i_textBox";
            this.si_i_textBox.Size = new System.Drawing.Size(83, 20);
            this.si_i_textBox.TabIndex = 33;
            // 
            // save_int_update_label
            // 
            this.save_int_update_label.AutoSize = true;
            this.save_int_update_label.Location = new System.Drawing.Point(253, 128);
            this.save_int_update_label.Name = "save_int_update_label";
            this.save_int_update_label.Size = new System.Drawing.Size(69, 13);
            this.save_int_update_label.TabIndex = 32;
            this.save_int_update_label.Text = "Save-interval";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(332, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "ms";
            // 
            // ft_i_textBox
            // 
            this.ft_i_textBox.Location = new System.Drawing.Point(245, 95);
            this.ft_i_textBox.Name = "ft_i_textBox";
            this.ft_i_textBox.Size = new System.Drawing.Size(83, 20);
            this.ft_i_textBox.TabIndex = 30;
            // 
            // ft_update_label
            // 
            this.ft_update_label.AutoSize = true;
            this.ft_update_label.Location = new System.Drawing.Point(260, 79);
            this.ft_update_label.Name = "ft_update_label";
            this.ft_update_label.Size = new System.Drawing.Size(51, 13);
            this.ft_update_label.TabIndex = 29;
            this.ft_update_label.Text = "Filter-time";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(339, 186);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "ms";
            // 
            // pi_i_textBox
            // 
            this.pi_i_textBox.Location = new System.Drawing.Point(252, 183);
            this.pi_i_textBox.Name = "pi_i_textBox";
            this.pi_i_textBox.Size = new System.Drawing.Size(83, 20);
            this.pi_i_textBox.TabIndex = 27;
            // 
            // pingint_update_label
            // 
            this.pingint_update_label.AutoSize = true;
            this.pingint_update_label.Location = new System.Drawing.Point(261, 167);
            this.pingint_update_label.Name = "pingint_update_label";
            this.pingint_update_label.Size = new System.Drawing.Size(65, 13);
            this.pingint_update_label.TabIndex = 26;
            this.pingint_update_label.Text = "Ping-interval";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(339, 137);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "ms";
            // 
            // ttl_i_textBox
            // 
            this.ttl_i_textBox.Location = new System.Drawing.Point(252, 134);
            this.ttl_i_textBox.Name = "ttl_i_textBox";
            this.ttl_i_textBox.Size = new System.Drawing.Size(83, 20);
            this.ttl_i_textBox.TabIndex = 24;
            // 
            // ttl_update_label
            // 
            this.ttl_update_label.AutoSize = true;
            this.ttl_update_label.Location = new System.Drawing.Point(279, 118);
            this.ttl_update_label.Name = "ttl_update_label";
            this.ttl_update_label.Size = new System.Drawing.Size(27, 13);
            this.ttl_update_label.TabIndex = 23;
            this.ttl_update_label.Text = "TTL";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(339, 90);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "ms";
            // 
            // timeOut_i_textBox
            // 
            this.timeOut_i_textBox.Location = new System.Drawing.Point(252, 87);
            this.timeOut_i_textBox.Name = "timeOut_i_textBox";
            this.timeOut_i_textBox.Size = new System.Drawing.Size(83, 20);
            this.timeOut_i_textBox.TabIndex = 21;
            // 
            // timout_update_label
            // 
            this.timout_update_label.AutoSize = true;
            this.timout_update_label.Location = new System.Drawing.Point(267, 71);
            this.timout_update_label.Name = "timout_update_label";
            this.timout_update_label.Size = new System.Drawing.Size(47, 13);
            this.timout_update_label.TabIndex = 20;
            this.timout_update_label.Text = "TimeOut";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(94, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "min";
            // 
            // si_c_textBox
            // 
            this.si_c_textBox.Enabled = false;
            this.si_c_textBox.Location = new System.Drawing.Point(7, 144);
            this.si_c_textBox.Name = "si_c_textBox";
            this.si_c_textBox.Size = new System.Drawing.Size(83, 20);
            this.si_c_textBox.TabIndex = 18;
            this.si_c_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // save_interval_c_label
            // 
            this.save_interval_c_label.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.save_interval_c_label.AutoSize = true;
            this.save_interval_c_label.Location = new System.Drawing.Point(15, 128);
            this.save_interval_c_label.Name = "save_interval_c_label";
            this.save_interval_c_label.Size = new System.Drawing.Size(69, 13);
            this.save_interval_c_label.TabIndex = 17;
            this.save_interval_c_label.Text = "Save-interval";
            // 
            // set_save_int_btn
            // 
            this.set_save_int_btn.Location = new System.Drawing.Point(135, 142);
            this.set_save_int_btn.Name = "set_save_int_btn";
            this.set_save_int_btn.Size = new System.Drawing.Size(75, 23);
            this.set_save_int_btn.TabIndex = 16;
            this.set_save_int_btn.Text = "Update";
            this.set_save_int_btn.UseVisualStyleBackColor = true;
            this.set_save_int_btn.Click += new System.EventHandler(this.set_save_int_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "ms";
            // 
            // ft_c_textBox
            // 
            this.ft_c_textBox.Enabled = false;
            this.ft_c_textBox.Location = new System.Drawing.Point(7, 95);
            this.ft_c_textBox.Name = "ft_c_textBox";
            this.ft_c_textBox.Size = new System.Drawing.Size(83, 20);
            this.ft_c_textBox.TabIndex = 14;
            this.ft_c_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // filter_c_label
            // 
            this.filter_c_label.AutoSize = true;
            this.filter_c_label.Location = new System.Drawing.Point(22, 79);
            this.filter_c_label.Name = "filter_c_label";
            this.filter_c_label.Size = new System.Drawing.Size(51, 13);
            this.filter_c_label.TabIndex = 13;
            this.filter_c_label.Text = "Filter-time";
            // 
            // set_ft_btn
            // 
            this.set_ft_btn.Location = new System.Drawing.Point(135, 93);
            this.set_ft_btn.Name = "set_ft_btn";
            this.set_ft_btn.Size = new System.Drawing.Size(75, 23);
            this.set_ft_btn.TabIndex = 12;
            this.set_ft_btn.Text = "Update";
            this.set_ft_btn.UseVisualStyleBackColor = true;
            this.set_ft_btn.Click += new System.EventHandler(this.set_ft_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "ms";
            // 
            // pi_c_textBox
            // 
            this.pi_c_textBox.Enabled = false;
            this.pi_c_textBox.Location = new System.Drawing.Point(14, 183);
            this.pi_c_textBox.Name = "pi_c_textBox";
            this.pi_c_textBox.Size = new System.Drawing.Size(83, 20);
            this.pi_c_textBox.TabIndex = 10;
            this.pi_c_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ping_interval_c_label
            // 
            this.ping_interval_c_label.AutoSize = true;
            this.ping_interval_c_label.Location = new System.Drawing.Point(23, 167);
            this.ping_interval_c_label.Name = "ping_interval_c_label";
            this.ping_interval_c_label.Size = new System.Drawing.Size(65, 13);
            this.ping_interval_c_label.TabIndex = 9;
            this.ping_interval_c_label.Text = "Ping-interval";
            // 
            // set_ping_int_btn
            // 
            this.set_ping_int_btn.Location = new System.Drawing.Point(142, 181);
            this.set_ping_int_btn.Name = "set_ping_int_btn";
            this.set_ping_int_btn.Size = new System.Drawing.Size(75, 23);
            this.set_ping_int_btn.TabIndex = 8;
            this.set_ping_int_btn.Text = "Update";
            this.set_ping_int_btn.UseVisualStyleBackColor = true;
            this.set_ping_int_btn.Click += new System.EventHandler(this.set_ping_int_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "hops";
            // 
            // ttl_c_textBox
            // 
            this.ttl_c_textBox.Enabled = false;
            this.ttl_c_textBox.Location = new System.Drawing.Point(14, 134);
            this.ttl_c_textBox.Name = "ttl_c_textBox";
            this.ttl_c_textBox.Size = new System.Drawing.Size(83, 20);
            this.ttl_c_textBox.TabIndex = 6;
            this.ttl_c_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ttl_c_textBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // TTL_c_label
            // 
            this.TTL_c_label.AutoSize = true;
            this.TTL_c_label.Location = new System.Drawing.Point(41, 118);
            this.TTL_c_label.Name = "TTL_c_label";
            this.TTL_c_label.Size = new System.Drawing.Size(27, 13);
            this.TTL_c_label.TabIndex = 5;
            this.TTL_c_label.Text = "TTL";
            // 
            // set_ttl_btn
            // 
            this.set_ttl_btn.Location = new System.Drawing.Point(142, 132);
            this.set_ttl_btn.Name = "set_ttl_btn";
            this.set_ttl_btn.Size = new System.Drawing.Size(75, 23);
            this.set_ttl_btn.TabIndex = 4;
            this.set_ttl_btn.Text = "Update";
            this.set_ttl_btn.UseVisualStyleBackColor = true;
            this.set_ttl_btn.Click += new System.EventHandler(this.set_ttl_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ms";
            // 
            // timeOut_c_textBox
            // 
            this.timeOut_c_textBox.Enabled = false;
            this.timeOut_c_textBox.Location = new System.Drawing.Point(14, 87);
            this.timeOut_c_textBox.Name = "timeOut_c_textBox";
            this.timeOut_c_textBox.Size = new System.Drawing.Size(83, 20);
            this.timeOut_c_textBox.TabIndex = 2;
            this.timeOut_c_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // timout_config_label
            // 
            this.timout_config_label.AutoSize = true;
            this.timout_config_label.Location = new System.Drawing.Point(29, 71);
            this.timout_config_label.Name = "timout_config_label";
            this.timout_config_label.Size = new System.Drawing.Size(47, 13);
            this.timout_config_label.TabIndex = 1;
            this.timout_config_label.Text = "TimeOut";
            // 
            // set_timeout_btn
            // 
            this.set_timeout_btn.Location = new System.Drawing.Point(142, 85);
            this.set_timeout_btn.Name = "set_timeout_btn";
            this.set_timeout_btn.Size = new System.Drawing.Size(75, 23);
            this.set_timeout_btn.TabIndex = 0;
            this.set_timeout_btn.Text = "Update";
            this.set_timeout_btn.UseVisualStyleBackColor = true;
            this.set_timeout_btn.Click += new System.EventHandler(this.set_timeout_btn_Click);
            // 
            // tracert_interval_timer
            // 
            this.tracert_interval_timer.Interval = 10000;
            this.tracert_interval_timer.Tick += new System.EventHandler(this.tracert_interval_timer_Tick);
            // 
            // save_to_log_btn
            // 
            this.save_to_log_btn.Location = new System.Drawing.Point(930, 402);
            this.save_to_log_btn.Name = "save_to_log_btn";
            this.save_to_log_btn.Size = new System.Drawing.Size(88, 28);
            this.save_to_log_btn.TabIndex = 13;
            this.save_to_log_btn.Text = "Save to log";
            this.save_to_log_btn.UseVisualStyleBackColor = true;
            this.save_to_log_btn.Click += new System.EventHandler(this.SaveTimer_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(344, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "min";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(257, 145);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(83, 20);
            this.textBox1.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(262, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Trace-interval";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(344, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 49;
            this.label13.Text = "ms";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(257, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(83, 20);
            this.textBox2.TabIndex = 48;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(106, 148);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 13);
            this.label17.TabIndex = 46;
            this.label17.Text = "min";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(19, 145);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(83, 20);
            this.textBox3.TabIndex = 45;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 129);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 13);
            this.label19.TabIndex = 44;
            this.label19.Text = "Trace-interval";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(147, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(106, 99);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(20, 13);
            this.label22.TabIndex = 42;
            this.label22.Text = "ms";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(19, 96);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(83, 20);
            this.textBox4.TabIndex = 41;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 39;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(275, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 55;
            this.label15.Text = "TimeOut";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(37, 80);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 13);
            this.label23.TabIndex = 54;
            this.label23.Text = "TimeOut";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.groupBox1.Controls.Add(this.pi_c_textBox);
            this.groupBox1.Controls.Add(this.set_timeout_btn);
            this.groupBox1.Controls.Add(this.timout_config_label);
            this.groupBox1.Controls.Add(this.timeOut_c_textBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.set_ttl_btn);
            this.groupBox1.Controls.Add(this.TTL_c_label);
            this.groupBox1.Controls.Add(this.ttl_c_textBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.set_ping_int_btn);
            this.groupBox1.Controls.Add(this.ping_interval_c_label);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.timout_update_label);
            this.groupBox1.Controls.Add(this.timeOut_i_textBox);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.ttl_update_label);
            this.groupBox1.Controls.Add(this.ttl_i_textBox);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.pingint_update_label);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.pi_i_textBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(10, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 358);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ping Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.groupBox2.Controls.Add(this.set_ft_btn);
            this.groupBox2.Controls.Add(this.filter_c_label);
            this.groupBox2.Controls.Add(this.ft_c_textBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.set_save_int_btn);
            this.groupBox2.Controls.Add(this.save_interval_c_label);
            this.groupBox2.Controls.Add(this.si_c_textBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.ft_update_label);
            this.groupBox2.Controls.Add(this.ft_i_textBox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.save_int_update_label);
            this.groupBox2.Controls.Add(this.si_i_textBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(385, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 358);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Event Settings";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(747, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 358);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trace Settings";
            // 
            // PingLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1134, 441);
            this.Controls.Add(this.save_to_log_btn);
            this.Controls.Add(this.main_tabs);
            this.Controls.Add(this.add_session_btn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1150, 480);
            this.MinimumSize = new System.Drawing.Size(1150, 480);
            this.Name = "PingLogger";
            this.ShowIcon = false;
            this.Text = "PingLogger -JW";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.main_tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start_ping;
        private System.Windows.Forms.TextBox node_id;
        private System.Windows.Forms.Label node_id_label;
        private System.Windows.Forms.ListBox ping_logg;
        private System.Windows.Forms.Timer pingtimer;
        private System.Windows.Forms.Button stop_ping_btn;
        private System.Windows.Forms.ListBox ping_event_box;
        private System.Windows.Forms.Timer event_timer;
        private System.Windows.Forms.Timer SaveTimer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button add_session_btn;
        private System.Windows.Forms.Label timeout_label;
        private System.Windows.Forms.Label TTL_label;
        private System.Windows.Forms.Label save_interval_label;
        private System.Windows.Forms.Label ping_interval_label;
        private System.Windows.Forms.Label event_filter_label;
        private System.Windows.Forms.TabControl main_tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox si_c_textBox;
        private System.Windows.Forms.Label save_interval_c_label;
        private System.Windows.Forms.Button set_save_int_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ft_c_textBox;
        private System.Windows.Forms.Label filter_c_label;
        private System.Windows.Forms.Button set_ft_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pi_c_textBox;
        private System.Windows.Forms.Label ping_interval_c_label;
        private System.Windows.Forms.Button set_ping_int_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ttl_c_textBox;
        private System.Windows.Forms.Label TTL_c_label;
        private System.Windows.Forms.Button set_ttl_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox timeOut_c_textBox;
        private System.Windows.Forms.Label timout_config_label;
        private System.Windows.Forms.Button set_timeout_btn;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox si_i_textBox;
        private System.Windows.Forms.Label save_int_update_label;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox ft_i_textBox;
        private System.Windows.Forms.Label ft_update_label;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox pi_i_textBox;
        private System.Windows.Forms.Label pingint_update_label;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox ttl_i_textBox;
        private System.Windows.Forms.Label ttl_update_label;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox timeOut_i_textBox;
        private System.Windows.Forms.Label timout_update_label;
        private System.Windows.Forms.Timer tracert_interval_timer;
        private System.Windows.Forms.ListBox trace_listBox;
        private System.Windows.Forms.Label trace_log_lable;
        private System.Windows.Forms.Label event_log_label;
        private System.Windows.Forms.Label ping_log_label;
        private System.Windows.Forms.Button save_to_log_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

