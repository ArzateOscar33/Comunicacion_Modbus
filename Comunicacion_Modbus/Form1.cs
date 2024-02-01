using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus.Device;
using Modbus;
using System.IO.Ports;
using EasyModbus;

namespace Comunicacion_Modbus
{
    public partial class Form1 : Form
    {
        //declaramos variables
        ModbusServer modServer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(btnStart.Text=="START")
            { 
            modServer = new ModbusServer();
            modServer.Listen();
            lblStatus.Text = "Status .- Started";

            }
           else if (btnStart.Text == "STOP")
            {
                modServer.StopListening();
                modServer = null;
                lblStatus.Text = "Status .- Stopped";
                btnStart.Text = "START";

            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            int iadr = int.Parse(txbRegAdd.Text);
            short ival = short.Parse(txbRegVal.Text);


            if(cboRegType.Text=="Holding Register")
            {
                ModbusServer.HoldingRegisters regs = modServer.holdingRegisters;
                regs[iadr] = ival;
            }
            else if (cboRegType.Text == "Input Register")
            {
                ModbusServer.InputRegisters regs = modServer.inputRegisters;
                regs[iadr] = ival;
            }
            else if (cboRegType.Text == "Digital Input")
            {
                bool ivalB = bool.Parse(txbRegVal.Text);
                ModbusServer.DiscreteInputs regs = modServer.discreteInputs;
                regs[iadr] = ivalB;
            }

            else if (cboRegType.Text == "Coil Input")
            {
                bool ivalB = bool.Parse(txbRegVal.Text);
                ModbusServer.Coils regs = modServer.coils;
                regs[iadr] = ivalB;
            }
        }
    }
}
