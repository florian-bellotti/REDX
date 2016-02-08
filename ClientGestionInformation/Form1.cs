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
using Metier;

namespace ClientGestionInformation
{
    public partial class Form1 : Form
    {
        public ThreadPerformance observable;

        public Form1()
        {
            InitializeComponent();

            observable = new ThreadPerformance();
            observable.SomethingHappened += UpdateScreen;

            Thread t = new Thread(new ThreadStart(observable.run));
            t.Start();
        }


        public void UpdateScreen(object sender, EventArgs e)
        {
            if (this.textBoxRAM.InvokeRequired)
            {
                SetTextBoxRAMCallback d = new SetTextBoxRAMCallback(SetTextBoxRAM);
                this.Invoke(d, new object[] { observable.getAllStates()[1] });
            }
            else
            {
                this.textBoxRAM.Text = "(No Invoke)";
            }

            if (this.textBoxCPU.InvokeRequired)
            {
                SetTextBoxCPUCallback d = new SetTextBoxCPUCallback(SetTextBoxCPU);
                this.Invoke(d, new object[] { observable.getAllStates()[0] });
            }
            else
            {
                this.textBoxCPU.Text = "(No Invoke)";
            }

            if (this.textBoxDisk.InvokeRequired)
            {
                SetTextBoxDiskCallback d = new SetTextBoxDiskCallback(SetTextBoxDisk);
                this.Invoke(d, new object[] { observable.getAllStates()[2] });
            }
            else
            {
                this.textBoxDisk.Text = "(No Invoke)";
            }
        }
    }
}

    public class ThreadPerformance
    {
        public event EventHandler SomethingHappened;
        private string ram;
        private string cpu;
        private string disk;

        public void run()
        {
            MappageMachineInformation mapMachineInfo = new MappageMachineInformation();
            DataSet data = new DataSet();
            while (true)
            {
                data = mapMachineInfo.selectAll();
                foreach (DataTable table in data.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (DataColumn column in table.Columns)
                        {
                            switch (column.ToString())
                            {
                                case "RAM":
                                    ram = row[column].ToString();
                                    break;
                                case "CPU":
                                    cpu = row[column].ToString();
                                    break;
                                case "Disk":
                                    disk = row[column].ToString();
                                    break;
                            }
                        }
                    }
                }

                EventHandler handler = SomethingHappened;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }

                Thread.Sleep(1*60*1000);
            }
        }

    public string[] getAllStates()
    {
        string[] tab = new string[3];
        tab[0] = cpu;
        tab[1] = ram;
        tab[2] = disk;
        return tab;
    }
}

