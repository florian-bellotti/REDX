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
using System.IO;
using MetierDiffusion;

namespace ClientDiffusion
{
    public partial class FormDiffusion : Form
    {
        public KinectSensor sensor = null;
        static MoveRightGesture _gesture = new MoveRightGesture();
        public FormDiffusion()
        {
            InitializeComponent();
            initializeKinect();

            //initialisation des composants du media player
            /*WMPLib.IWMPPlaylist playlist = mediaPlayer.newPlaylist("myPlaylist", string.Empty);
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

        private void initializeKinect()
        {
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }
            if (null != this.sensor)
            {
                this.sensor.SkeletonStream.Enable();
                this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;
                _gesture.GestureRecognized += Gesture_GestureRecognized;

                try
                {
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    this.sensor = null;
                }
            }
        }

        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (var frame = e.OpenSkeletonFrame())
            {
                Skeleton[] skeletons = new Skeleton[frame.SkeletonArrayLength];
                if (frame != null)
                {
                    frame.CopySkeletonDataTo(skeletons);

                    if (skeletons.Length > 0)
                    {
                        var user = skeletons.Where(
                                   u => u.TrackingState == SkeletonTrackingState.Tracked).FirstOrDefault();

                        if (user != null)
                        {
                            _gesture.Update(user);
                        }
                    }
                }
            }
        }
        public void Gesture_GestureRecognized(object sender, EventArgs e)
        {
            mediaPlayer.Ctlcontrols.pause();
            Console.WriteLine("Gesture reconnue");
        }

        private void mediaPlayer_Enter(object sender, EventArgs e)
        {

        }
    }
}
