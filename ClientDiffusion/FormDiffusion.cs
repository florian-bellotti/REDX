using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Kinect;
using MetierDiffusion;
using System.Threading;
using System.Media;


namespace ClientDiffusion
{
    public partial class FormDiffusion : Form
    {
        static MoveRightGesture _gestureRight = new MoveRightGesture();
        static MoveLeftGesture _gestureLeft = new MoveLeftGesture();
        static Boolean musicIsPlaying = false;
        static SoundPlayer lecteur;
        static Boolean gestureRightAlreadyDisplay = false;
        static Boolean gestureLeftAlreadyDisplay = false;

        private KinectSensor sensor;

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
            _gestureRight.GestureRecognized += GestureRight_GestureRecognized;
            _gestureLeft.GestureRecognized += GestureLeft_GestureRecognized;
            lecteur = new SoundPlayer(@"C:\Users\Kazadri\Source\Repos\REDX\SkeletonBasics-WPF\Tetoma.wav");

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Height = 1032;
            this.Width = 1632;
        }

        private void initialyzeKinect()
        {
            if (null != this.sensor)
            {
                // Turn on the skeleton stream to receive skeleton frames
                this.sensor.SkeletonStream.Enable();

                // Add an event handler to be called whenever there is new color frame data
                this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;

                // Start the sensor!
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

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (null != this.sensor)
            {
                this.sensor.Stop();
            }
        }

        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                    if (skeletons.Length > 0)
                    {
                        var user = skeletons.Where(u => u.TrackingState == SkeletonTrackingState.Tracked).FirstOrDefault();

                        if (user != null)
                        {
                            _gestureRight.Update(user);
                            _gestureLeft.Update(user);
                        }
                    }
                }
            }
        }

        static void GestureRight_GestureRecognized(object sender, EventArgs e)
        {
            if (!gestureRightAlreadyDisplay)
            {
                gestureRightAlreadyDisplay = true;
                if (!musicIsPlaying)
                {
                    lecteur.Play();
                    Thread.Sleep(2000);
                    //MessageBox.Show("Gesture droite reconnue");
                    gestureRightAlreadyDisplay = false;
                    musicIsPlaying = true;
                }

            }
        }
        static void GestureLeft_GestureRecognized(object sender, EventArgs e)
        {
            if (!gestureLeftAlreadyDisplay)
            {
                gestureLeftAlreadyDisplay = true;
                if (musicIsPlaying)
                {
                    lecteur.Stop();
                    Thread.Sleep(2000);
                    musicIsPlaying = false;
                    //MessageBox.Show("Gesture gauche reconnue");
                    gestureLeftAlreadyDisplay = false;
                }

            }
        }
    }
}
