namespace ConnectToArduino
{
    partial class ConnectToArduinoForm
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
            this.PortSelect = new System.Windows.Forms.ComboBox();
            this.Refresh = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.outputConsole = new System.Windows.Forms.TextBox();
            this.BaudSelect = new System.Windows.Forms.ComboBox();
            this.outgoingTextbox = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.LedOn = new System.Windows.Forms.Button();
            this.LedOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PortSelect
            // 
            this.PortSelect.FormattingEnabled = true;
            this.PortSelect.Location = new System.Drawing.Point(12, 12);
            this.PortSelect.Name = "PortSelect";
            this.PortSelect.Size = new System.Drawing.Size(121, 21);
            this.PortSelect.TabIndex = 0;
            this.PortSelect.Text = "Select Port";
            this.PortSelect.SelectedIndexChanged += new System.EventHandler(this.PortSelect_SelectedIndexChanged);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(139, 11);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(75, 23);
            this.Refresh.TabIndex = 1;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(220, 11);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 2;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // outputConsole
            // 
            this.outputConsole.Location = new System.Drawing.Point(12, 40);
            this.outputConsole.Multiline = true;
            this.outputConsole.Name = "outputConsole";
            this.outputConsole.ReadOnly = true;
            this.outputConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputConsole.Size = new System.Drawing.Size(283, 147);
            this.outputConsole.TabIndex = 3;
            this.outputConsole.TextChanged += new System.EventHandler(this.outputConsole_TextChanged);
            // 
            // BaudSelect
            // 
            this.BaudSelect.FormattingEnabled = true;
            this.BaudSelect.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200"});
            this.BaudSelect.Location = new System.Drawing.Point(188, 228);
            this.BaudSelect.Name = "BaudSelect";
            this.BaudSelect.Size = new System.Drawing.Size(108, 21);
            this.BaudSelect.TabIndex = 4;
            this.BaudSelect.Text = "Select Baud Rate";
            this.BaudSelect.SelectedIndexChanged += new System.EventHandler(this.BaudSelect_SelectedIndexChanged);
            // 
            // outgoingTextbox
            // 
            this.outgoingTextbox.Location = new System.Drawing.Point(13, 194);
            this.outgoingTextbox.Name = "outgoingTextbox";
            this.outgoingTextbox.Size = new System.Drawing.Size(201, 20);
            this.outgoingTextbox.TabIndex = 5;
            this.outgoingTextbox.Text = "Send a message";
            this.outgoingTextbox.Click += new System.EventHandler(this.ClickSendBox);
            this.outgoingTextbox.TextChanged += new System.EventHandler(this.outgoingTextbox_TextChanged);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(220, 192);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 6;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // LedOn
            // 
            this.LedOn.Location = new System.Drawing.Point(13, 226);
            this.LedOn.Name = "LedOn";
            this.LedOn.Size = new System.Drawing.Size(75, 23);
            this.LedOn.TabIndex = 7;
            this.LedOn.Text = "LED 13 ON";
            this.LedOn.UseVisualStyleBackColor = true;
            this.LedOn.Click += new System.EventHandler(this.LedOn_Click);
            // 
            // LedOff
            // 
            this.LedOff.Location = new System.Drawing.Point(94, 226);
            this.LedOff.Name = "LedOff";
            this.LedOff.Size = new System.Drawing.Size(75, 23);
            this.LedOff.TabIndex = 8;
            this.LedOff.Text = "LED 13 OFF";
            this.LedOff.UseVisualStyleBackColor = true;
            this.LedOff.Click += new System.EventHandler(this.LedOff_Click);
            // 
            // ConnectToArduinoForm
            // 
            this.AcceptButton = this.Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 261);
            this.Controls.Add(this.LedOff);
            this.Controls.Add(this.LedOn);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.outgoingTextbox);
            this.Controls.Add(this.BaudSelect);
            this.Controls.Add(this.outputConsole);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.PortSelect);
            this.Name = "ConnectToArduinoForm";
            this.Text = "ConnectToArduino";
            this.Load += new System.EventHandler(this.ConnectToArduinoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PortSelect;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.TextBox outputConsole;
        private System.Windows.Forms.ComboBox BaudSelect;
        private System.Windows.Forms.TextBox outgoingTextbox;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Button LedOn;
        private System.Windows.Forms.Button LedOff;
    }
}

