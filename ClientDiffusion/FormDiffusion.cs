using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.IO;
using System.Windows;
using System.Windows.Media;


namespace ClientDiffusion
{
    public partial class FormDiffusion : Form
    {
       
        public FormDiffusion()
        {
            InitializeComponent();
            /*initializeKinect();

            //initialisation des composants du media player
            WMPLib.IWMPPlaylist playlist = mediaPlayer.newPlaylist("myPlaylist", string.Empty);
            string[] lines = System.IO.File.ReadAllLines(@"playlist.txt");

            foreach (string path in lines)
            {
                WMPLib.IWMPMedia temp = mediaPlayer.newMedia(path);
                playlist.appendItem(temp);
            }

            mediaPlayer.currentPlaylist = playlist;
            mediaPlayer.settings.autoStart = true;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Height = 1032;
            this.Width = 1632;*/
        }

      
    }
}
