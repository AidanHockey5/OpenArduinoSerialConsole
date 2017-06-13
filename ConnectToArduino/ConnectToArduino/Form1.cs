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
                sp = new SerialPort(activePort, baudRate, Parity.None, 8, StopBits.One);
                sp.DtrEnable = false;
                sp.Open();
                sp.ReadTimeout = 1;
                sp.WriteTimeout = 1;
                sp.DataReceived += new SerialDataReceivedEventHandler(SerialDataRecieved);
            }

        }

        void Print(string text) //Print on same line
        {
            outputConsole.AppendText(text);
        }

        void Println(string text) //Print and create a new line.
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
            string inData = sp.ReadExisting();
            Print(inData);
        }

        private void Send_Click(object sender, EventArgs e)
        {
            SendSerialMessage(outgoingTextbox.Text);
            outgoingTextbox.Text = string.Empty;
        }

        private void LedOn_Click(object sender, EventArgs e)
        {
            SendSerialMessage("LED_ON");
        }

        private void LedOff_Click(object sender, EventArgs e)
        {
            SendSerialMessage("LED_OFF");
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
    }
}
