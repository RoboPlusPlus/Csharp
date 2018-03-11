namespace PingToModbus
{
    partial class MainForm
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
            this.ping1 = new System.Net.NetworkInformation.Ping();
            this.modbusTCPCom1 = new AdvancedHMIDrivers.ModbusTCPCom(this.components);
            this.pingEventTimer = new System.Windows.Forms.Timer(this.components);
            this.ListBox_IPs_and_MB_adresses = new System.Windows.Forms.ListBox();
            this.listBox_ping_results = new System.Windows.Forms.ListBox();
            this.textBox_Add_IP = new System.Windows.Forms.TextBox();
            this.textBox_Add_MB_address = new System.Windows.Forms.TextBox();
            this.button_add_node = new System.Windows.Forms.Button();
            this.label_add_ip = new System.Windows.Forms.Label();
            this.label_add_MB_add = new System.Windows.Forms.Label();
            this.pilotLight1 = new AdvancedHMIControls.PilotLight();
            ((System.ComponentModel.ISupportInitialize)(this.modbusTCPCom1)).BeginInit();
            this.SuspendLayout();
            // 
            // modbusTCPCom1
            // 
            this.modbusTCPCom1.DisableSubscriptions = false;
            this.modbusTCPCom1.IniFileName = "";
            this.modbusTCPCom1.IniFileSection = null;
            this.modbusTCPCom1.IPAddress = "10.181.5.35";
            this.modbusTCPCom1.MaxReadGroupSize = 20;
            this.modbusTCPCom1.SwapBytes = true;
            this.modbusTCPCom1.SwapWords = false;
            this.modbusTCPCom1.TcpipPort = ((ushort)(502));
            this.modbusTCPCom1.TimeOut = 3000;
            this.modbusTCPCom1.UnitId = ((byte)(1));
            this.modbusTCPCom1.DataReceived += new System.EventHandler<MfgControl.AdvancedHMI.Drivers.Common.PlcComEventArgs>(this.modbusTCPCom1_DataReceived);
            // 
            // pingEventTimer
            // 
            this.pingEventTimer.Tick += new System.EventHandler(this.pingEventTimer_Tick);
            // 
            // ListBox_IPs_and_MB_adresses
            // 
            this.ListBox_IPs_and_MB_adresses.FormattingEnabled = true;
            this.ListBox_IPs_and_MB_adresses.Location = new System.Drawing.Point(12, 107);
            this.ListBox_IPs_and_MB_adresses.Name = "ListBox_IPs_and_MB_adresses";
            this.ListBox_IPs_and_MB_adresses.Size = new System.Drawing.Size(244, 160);
            this.ListBox_IPs_and_MB_adresses.TabIndex = 0;
            // 
            // listBox_ping_results
            // 
            this.listBox_ping_results.FormattingEnabled = true;
            this.listBox_ping_results.Location = new System.Drawing.Point(294, 107);
            this.listBox_ping_results.Name = "listBox_ping_results";
            this.listBox_ping_results.Size = new System.Drawing.Size(240, 160);
            this.listBox_ping_results.TabIndex = 1;
            this.listBox_ping_results.SelectedIndexChanged += new System.EventHandler(this.listBox_ping_results_SelectedIndexChanged);
            // 
            // textBox_Add_IP
            // 
            this.textBox_Add_IP.Location = new System.Drawing.Point(12, 66);
            this.textBox_Add_IP.Name = "textBox_Add_IP";
            this.textBox_Add_IP.Size = new System.Drawing.Size(118, 20);
            this.textBox_Add_IP.TabIndex = 2;
            // 
            // textBox_Add_MB_address
            // 
            this.textBox_Add_MB_address.Location = new System.Drawing.Point(160, 66);
            this.textBox_Add_MB_address.Name = "textBox_Add_MB_address";
            this.textBox_Add_MB_address.Size = new System.Drawing.Size(124, 20);
            this.textBox_Add_MB_address.TabIndex = 3;
            // 
            // button_add_node
            // 
            this.button_add_node.Location = new System.Drawing.Point(307, 64);
            this.button_add_node.Name = "button_add_node";
            this.button_add_node.Size = new System.Drawing.Size(75, 23);
            this.button_add_node.TabIndex = 4;
            this.button_add_node.Text = "Add Node";
            this.button_add_node.UseVisualStyleBackColor = true;
            this.button_add_node.Click += new System.EventHandler(this.button_add_node_Click);
            // 
            // label_add_ip
            // 
            this.label_add_ip.AutoSize = true;
            this.label_add_ip.Location = new System.Drawing.Point(12, 47);
            this.label_add_ip.Name = "label_add_ip";
            this.label_add_ip.Size = new System.Drawing.Size(17, 13);
            this.label_add_ip.TabIndex = 5;
            this.label_add_ip.Text = "IP";
            // 
            // label_add_MB_add
            // 
            this.label_add_MB_add.AutoSize = true;
            this.label_add_MB_add.Location = new System.Drawing.Point(157, 47);
            this.label_add_MB_add.Name = "label_add_MB_add";
            this.label_add_MB_add.Size = new System.Drawing.Size(64, 13);
            this.label_add_MB_add.TabIndex = 6;
            this.label_add_MB_add.Text = "MB Adresse";
            // 
            // pilotLight1
            // 
            this.pilotLight1.Blink = false;
            this.pilotLight1.ComComponent = this.modbusTCPCom1;
            this.pilotLight1.LegendPlate = MfgControl.AdvancedHMI.Controls.PilotLight.LegendPlates.Large;
            this.pilotLight1.LightColor = MfgControl.AdvancedHMI.Controls.PilotLight.LightColors.Green;
            this.pilotLight1.LightColorOff = MfgControl.AdvancedHMI.Controls.PilotLight.LightColors.White;
            this.pilotLight1.Location = new System.Drawing.Point(886, 354);
            this.pilotLight1.Name = "pilotLight1";
            this.pilotLight1.OutputType = MfgControl.AdvancedHMI.Controls.OutputType.MomentarySet;
            this.pilotLight1.PLCAddressClick = "00001";
            this.pilotLight1.PLCAddressText = "";
            this.pilotLight1.PLCAddressValue = "";
            this.pilotLight1.PLCAddressVisible = "";
            this.pilotLight1.Size = new System.Drawing.Size(75, 110);
            this.pilotLight1.TabIndex = 7;
            this.pilotLight1.Text = "pilotLight1";
            this.pilotLight1.Value = false;
            this.pilotLight1.ValueToWrite = 0;
            this.pilotLight1.Click += new System.EventHandler(this.pilotLight1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1031, 502);
            this.Controls.Add(this.pilotLight1);
            this.Controls.Add(this.label_add_MB_add);
            this.Controls.Add(this.label_add_ip);
            this.Controls.Add(this.button_add_node);
            this.Controls.Add(this.textBox_Add_MB_address);
            this.Controls.Add(this.textBox_Add_IP);
            this.Controls.Add(this.listBox_ping_results);
            this.Controls.Add(this.ListBox_IPs_and_MB_adresses);
            this.Name = "MainForm";
            this.Text = "AdvancedHMI V3.99w";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modbusTCPCom1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Net.NetworkInformation.Ping ping1;
        private AdvancedHMIDrivers.ModbusTCPCom modbusTCPCom1;
        private System.Windows.Forms.Timer pingEventTimer;
        private System.Windows.Forms.ListBox ListBox_IPs_and_MB_adresses;
        private System.Windows.Forms.ListBox listBox_ping_results;
        private System.Windows.Forms.TextBox textBox_Add_IP;
        private System.Windows.Forms.TextBox textBox_Add_MB_address;
        private System.Windows.Forms.Button button_add_node;
        private System.Windows.Forms.Label label_add_ip;
        private System.Windows.Forms.Label label_add_MB_add;
        private AdvancedHMIControls.PilotLight pilotLight1;
    }
}

