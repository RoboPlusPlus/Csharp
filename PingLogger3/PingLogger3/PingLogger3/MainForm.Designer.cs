namespace PingLogger3
{
    partial class Form_MainForm
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
            this.tabControl_frontPage = new System.Windows.Forms.TabControl();
            this.tabPage_Monitoring = new System.Windows.Forms.TabPage();
            this.tabPage_Settings = new System.Windows.Forms.TabPage();
            this.listBox_pingLogg = new System.Windows.Forms.ListBox();
            this.listBox_tracedRoute = new System.Windows.Forms.ListBox();
            this.tabControl_frontPage.SuspendLayout();
            this.tabPage_Monitoring.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_frontPage
            // 
            this.tabControl_frontPage.Controls.Add(this.tabPage_Monitoring);
            this.tabControl_frontPage.Controls.Add(this.tabPage_Settings);
            this.tabControl_frontPage.Location = new System.Drawing.Point(4, 135);
            this.tabControl_frontPage.Name = "tabControl_frontPage";
            this.tabControl_frontPage.SelectedIndex = 0;
            this.tabControl_frontPage.Size = new System.Drawing.Size(704, 423);
            this.tabControl_frontPage.TabIndex = 0;
            // 
            // tabPage_Monitoring
            // 
            this.tabPage_Monitoring.Controls.Add(this.listBox_tracedRoute);
            this.tabPage_Monitoring.Controls.Add(this.listBox_pingLogg);
            this.tabPage_Monitoring.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Monitoring.Name = "tabPage_Monitoring";
            this.tabPage_Monitoring.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Monitoring.Size = new System.Drawing.Size(696, 397);
            this.tabPage_Monitoring.TabIndex = 0;
            this.tabPage_Monitoring.Text = "Monitoring";
            this.tabPage_Monitoring.UseVisualStyleBackColor = true;
            // 
            // tabPage_Settings
            // 
            this.tabPage_Settings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Settings.Name = "tabPage_Settings";
            this.tabPage_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Settings.Size = new System.Drawing.Size(902, 499);
            this.tabPage_Settings.TabIndex = 1;
            this.tabPage_Settings.Text = "Settings";
            this.tabPage_Settings.UseVisualStyleBackColor = true;
            // 
            // listBox_pingLogg
            // 
            this.listBox_pingLogg.FormattingEnabled = true;
            this.listBox_pingLogg.Location = new System.Drawing.Point(7, 20);
            this.listBox_pingLogg.Name = "listBox_pingLogg";
            this.listBox_pingLogg.Size = new System.Drawing.Size(328, 368);
            this.listBox_pingLogg.TabIndex = 0;
            // 
            // listBox_tracedRoute
            // 
            this.listBox_tracedRoute.FormattingEnabled = true;
            this.listBox_tracedRoute.Location = new System.Drawing.Point(353, 20);
            this.listBox_tracedRoute.Name = "listBox_tracedRoute";
            this.listBox_tracedRoute.Size = new System.Drawing.Size(328, 368);
            this.listBox_tracedRoute.TabIndex = 1;
            // 
            // Form_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 570);
            this.Controls.Add(this.tabControl_frontPage);
            this.Name = "Form_MainForm";
            this.Text = "PingLogger3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl_frontPage.ResumeLayout(false);
            this.tabPage_Monitoring.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_frontPage;
        private System.Windows.Forms.TabPage tabPage_Monitoring;
        private System.Windows.Forms.ListBox listBox_tracedRoute;
        private System.Windows.Forms.ListBox listBox_pingLogg;
        private System.Windows.Forms.TabPage tabPage_Settings;
    }
}

