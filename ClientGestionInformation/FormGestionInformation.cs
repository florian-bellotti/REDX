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
    public partial class FormGestionInformation : Form
    {
        private ObservablePerformance observablePerformance;
        private Thread t;
        private ProcessStartInfo progDif;

        public FormGestionInformation()
        {
            InitializeComponent();
            
            observablePerformance = new ObservablePerformance();
            observablePerformance.SomethingHappened += UpdateScreen;

            t = new Thread(new ThreadStart(observablePerformance.checkPerformance));
            t.Start();
        }

        /// <summary>
        /// Cette Methode permet de mettre a jour le Form de facon Safe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Permet de générer une alerte en cas de performances insufisantes
        /// et de lancer ou non l'application de diffusion
        /// </summary>
        private void Alert()
        {
            string textAlert = "Vous avez des problèmes de : \n";
            bool erreur = false;

            if (Convert.ToDouble(textBoxCPU.Text) >= 85)
            {
                textAlert += "  - CPU \n";
                erreur = true;
            }
            if (Convert.ToDouble(textBoxDisk.Text) >= 90)
            {
                textAlert += "  - Disque \n";
                erreur = true;
            }
            if (Convert.ToDouble(textBoxRAM.Text) <= 50)
            {
                textAlert += "  - RAM \n";
                erreur = true;
            }

            //s'il y a une erreur, ne pas lancer l'application et afficher une Popup
            if (erreur)
            {
                MessageBox.Show(textAlert);
            }
            else
            {
                progDif = new ProcessStartInfo();
                Process[] processlist = Process.GetProcesses();
                bool processExist = false;

                foreach (Process theprocess in processlist)
                {
                    if (theprocess.ProcessName == "ClientDiffusion")
                    processExist = true;
                }
                    
                if (!processExist)
                {
                    progDif.FileName = "ClientDiffusion.exe";
                    progDif.WorkingDirectory = @"C:\Users\Florian\Documents\Visual Studio 2015\Projects\REDX\ClientDiffusion\bin\release";
                    Process.Start(progDif);
                }                  

            }
        }

        /// <summary>
        /// Permet d'arreter le thread lors de la fermeture de la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
            t.Join();
        }
    }
}