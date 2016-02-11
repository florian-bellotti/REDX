using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace MetierDiffusion
{
    public class MoveLeftSegment1 : IGestureSegment
    {
        public GesturePartResult Update(Skeleton skeleton)
        {
            // Main au dessus du coude
            if (skeleton.Joints[JointType.HandLeft].Position.Y >
                skeleton.Joints[JointType.ElbowLeft].Position.Y)
            {
                // Main a la droite position que le coude
                if (skeleton.Joints[JointType.HandLeft].Position.X >
                    skeleton.Joints[JointType.ElbowLeft].Position.X)
                {
                    return GesturePartResult.Succeeded;
                }
            }

            // Hand dropped
            return GesturePartResult.Failed;
        }
    }
}
