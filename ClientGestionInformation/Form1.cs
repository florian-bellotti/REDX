using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetierApplication;
using System.Diagnostics;

namespace ClientGestionInformation
{
    public partial class Form1 : Form
    {
        private ObservablePerformance observablePerformance;
        private Thread t;

        public Form1()
        {
            InitializeComponent();

            observablePerformance = new ObservablePerformance();
            observablePerformance.SomethingHappened += UpdateScreen;

            t = new Thread(new ThreadStart(observablePerformance.checkPerformance));
            t.Start();

        }


        public void UpdateScreen(object sender, EventArgs e)
        {
            if (this.textBoxRAM.InvokeRequired)
            {
                SetTextBoxRAMCallback d = new SetTextBoxRAMCallback(SetTextBoxRAM);
                this.Invoke(d, new object[] { observablePerformance.getAllStates()[1] });
            }
            else
            {
                this.textBoxRAM.Text = "(No Invoke)";
            }

            if (this.textBoxCPU.InvokeRequired)
            {
                SetTextBoxCPUCallback d = new SetTextBoxCPUCallback(SetTextBoxCPU);
                this.Invoke(d, new object[] { observablePerformance.getAllStates()[0] });
            }
            else
            {
                this.textBoxCPU.Text = "(No Invoke)";
            }

            if (this.textBoxDisk.InvokeRequired)
            {
                SetTextBoxDiskCallback d = new SetTextBoxDiskCallback(SetTextBoxDisk);
                this.Invoke(d, new object[] { observablePerformance.getAllStates()[2] });
            }
            else
            {
                this.textBoxDisk.Text = "(No Invoke)";
            }

           
            Alert();
        }

        private void Alert()
        {
            string textAlert = "Vous avez des problèmes de : \n";
            bool test = false;
            if (Convert.ToDouble(textBoxCPU.Text) >= 85)
            {
                textAlert += "  - CPU \n";
                test = true;
            }
            if (Convert.ToDouble(textBoxDisk.Text) >= 90)
            {
                textAlert += "  - Disque \n";
                test = true;
            }
            if (Convert.ToDouble(textBoxRAM.Text) <= 50)
            {
                textAlert += "  - RAM \n";
                test = true;
            }
            if (test)
            {
                MessageBox.Show(textAlert);
            }
            else
            {
                try
                {
                    Process p = new System.Diagnostics.Process();
                    if (Process.GetProcessesByName("ClientDiffusion").GetUpperBound(0) != 0)
                    {
                        p.StartInfo.FileName = @"C:\Users\Kazadri\Source\Repos\REDX\ClientDiffusion\bin\Release\ClientDiffusion.exe";
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                        p.Start();
                    }
                
                }catch(Exception err)
                {
                    //Exeception a gerer.
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
            t.Join();
        }
    }
}