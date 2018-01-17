using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ConnectToArduino
{
    public partial class ConnectToArduinoForm : Form
    {
        string activePort = string.Empty;
        int baudRate = 9600; //Default baud rate
        SerialPort sp;
        public ConnectToArduinoForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //Remove this if you want a resizable window
            RefreshSerialPorts();
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            if (sp == null)
                return;
            if (sp.IsOpen)
                sp.Close();
        }

        private void PortSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            activePort = PortSelect.Text;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshSerialPorts();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (sp != null)
                sp.Close();
            if (string.IsNullOrEmpty(activePort))
            {
                Println("No serial port selected");
                return;
            }
            else
            {
                Println("Connecting to: " + activePort + " at " + baudRate.ToString() + " Baud");
                try
                {
                    sp = new SerialPort(activePort, baudRate, Parity.None, 8, StopBits.One);
                    sp.DtrEnable = false;
                    sp.Open();
                    sp.ReadTimeout = 1;
                    sp.WriteTimeout = 1;
                    sp.DataReceived += new SerialDataReceivedEventHandler(SerialDataRecieved);
                    if (sp.IsOpen)
                        Println("Connected!");
                    else
                        Println("Connection failed!");
                }
                catch { Println("Connection failed!"); }
            }

        }

        delegate void SetTextCallback(string text);

        private void SetText(string text) //This function is required for the serial port to place items in the output console 
                                          //due to the serial ports being handled on another thread.
        {
            if (this.outputConsole.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.outputConsole.AppendText(text);
            }
        }

        void Print(string text) //Print on same line. Only use for local prints.
        {
            outputConsole.AppendText(text);
        }

        void Println(string text) //Print and create a new line. Only use for local prints.
        {
            outputConsole.AppendText(text + "\n");
        }

        private void BaudSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            baudRate = int.Parse(BaudSelect.Text);
        }

        void RefreshSerialPorts()
        {
            PortSelect.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            PortSelect.Items.AddRange(ports);
        }

        void SerialDataRecieved(object sender, SerialDataReceivedEventArgs e) //New message on the incomming serial line!
        {
            SerialPort s = (SerialPort)sender; //Which port just talked to us?
            string txt = string.Empty;
            txt += s.ReadExisting().ToString(); //Send over text to thread-safe text function
            SetText(txt.ToString());
        }

        private void Send_Click(object sender, EventArgs e)
        {
            SendSerialMessage(outgoingTextbox.Text);
            outgoingTextbox.Text = string.Empty;
        }

        private void LedOn_Click(object sender, EventArgs e)
        {
            SendSerialMessage("LED_ON");
            Println("Send LED_ON command");
        }

        private void LedOff_Click(object sender, EventArgs e)
        {
            SendSerialMessage("LED_OFF");
            Println("Send LED_OFF command");
        }

        void SendSerialMessage(string msg)
        {
            if (sp != null)
            {
                if (sp.IsOpen)
                {
                    sp.Write(msg);
                }
                return;
            }
            Println("Serial port not connected.");
        }

        //Just an aesthetic choice to clear the sending box on first click
        bool firstClear = false;
        private void ClickSendBox(object sender, EventArgs e)
        {
            if(!firstClear)
            {
                TextBox t = (TextBox)sender;
                t.Text = string.Empty;
                firstClear = true;
            }
        }

        //Unused elements.
        private void outgoingTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void outputConsole_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConnectToArduinoForm_Load(object sender, EventArgs e)
        {

        }

        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            outputConsole.Clear();
        }

        private void disconnect_Btn_Click(object sender, EventArgs e)
        {
            if(sp != null)
            {
                if (sp.IsOpen)
                    sp.Close();
            }
        }
    }
}
