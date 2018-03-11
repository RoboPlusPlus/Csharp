namespace AdvancedHMICS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.QuickStartLabel = new System.Windows.Forms.Label();
            this.ping1 = new System.Net.NetworkInformation.Ping();
            this.modbusTCPCom1 = new AdvancedHMIDrivers.ModbusTCPCom(this.components);
            this.Label1 = new System.Windows.Forms.Label();
            this.pingEventTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.modbusTCPCom1)).BeginInit();
            this.SuspendLayout();
            // 
            // QuickStartLabel
            // 
            this.QuickStartLabel.AutoSize = true;
            this.QuickStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.QuickStartLabel.ForeColor = System.Drawing.Color.White;
            this.QuickStartLabel.Location = new System.Drawing.Point(9, 16);
            this.QuickStartLabel.Name = "QuickStartLabel";
            this.QuickStartLabel.Size = new System.Drawing.Size(273, 104);
            this.QuickStartLabel.TabIndex = 44;
            this.QuickStartLabel.Text = resources.GetString("QuickStartLabel.Text");
            this.QuickStartLabel.Visible = false;
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
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label1.Location = new System.Drawing.Point(12, 520);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(194, 32);
            this.Label1.TabIndex = 43;
            this.Label1.Text = "For Development Source Code Visit\r\nhttp://www.advancedhmi.com";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pingEventTimer
            // 
            this.pingEventTimer.Tick += new System.EventHandler(this.pingEventTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.QuickStartLabel);
            this.Controls.Add(this.Label1);
            this.Name = "MainForm";
            this.Text = "AdvancedHMI V3.99w";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modbusTCPCom1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label QuickStartLabel;
        private System.Net.NetworkInformation.Ping ping1;
        private AdvancedHMIDrivers.ModbusTCPCom modbusTCPCom1;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Timer pingEventTimer;
    }
}

