using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.Threading;

namespace MetierDiffusion
{
    public class MoveLeftGesture
    {
        readonly int WINDOW_SIZE = 10;

        IGestureSegment[] _segments;

        int _currentSegment = 0;
        int _frameCount = 0;

        public event EventHandler GestureRecognized;

        public MoveLeftGesture()
        {
            MoveLeftSegment1 moveLeftSegment1 = new MoveLeftSegment1();
            MoveLeftSegment2 moveLeftSegment2 = new MoveLeftSegment2();

            _segments = new IGestureSegment[]
            {
                moveLeftSegment1,
                moveLeftSegment2,
            };
        }

        public void Update(Skeleton skeleton)
        {
            GesturePartResult result = _segments[_currentSegment].Update(skeleton);
            if (result == GesturePartResult.Succeeded)
            {
                if (_currentSegment + 1 < _segments.Length)
                {
                    _currentSegment++;
                    _frameCount = 0;
                }
                else
                {
                    if (GestureRecognized != null)
                    {
                        GestureRecognized(this, new EventArgs());
                  
                        Reset();
                    }
                }
            }
            else if (result == GesturePartResult.Failed || _frameCount == WINDOW_SIZE)
            {
                Reset();
            }
            else
            {
                _frameCount++;
            }
        }
        public void Reset()
        {
            _currentSegment = 0;
            _frameCount = 0;
        }
    }
}
