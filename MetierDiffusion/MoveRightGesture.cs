using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.Threading;

namespace MetierDiffusion
{
    public class MoveRightGesture
    {
        readonly int WINDOW_SIZE = 10;

        IGestureSegment[] _segments;

        int _currentSegment = 0;
        int _frameCount = 0;

        public event EventHandler GestureRecognized;

        public MoveRightGesture()
        {
            MoveRightSegment1 moveRightSegment1 = new MoveRightSegment1();
            MoveRightSegment2 moveRightSegment2 = new MoveRightSegment2();

            _segments = new IGestureSegment[]
            {
                moveRightSegment1,
                moveRightSegment2,
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
