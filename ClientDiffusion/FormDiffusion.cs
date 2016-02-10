using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;

namespace ClientDiffusion
{
    public partial class FormDiffusion : Form
    {
        public KinectSensor sensor = null;
        //static MoveRightGesture _gesture = new MoveRightGesture();
        public FormDiffusion()
        {
            InitializeComponent();

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
            this.Width = 1632;
        }

        private void mediaPlayer_Enter(object sender, EventArgs e)
        {

        }
    }
}
