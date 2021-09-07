using Unprogressed.Player;
using UnityEngine;

namespace Unprogressed.Common
{
    public sealed class InputSystem
    {
        public static MotionDirection GetDirection(float vert, float hor)
        {
            if (vert > 0)
            {
                if (hor > 0)
                {
                    return MotionDirection.ForwardRight;
                }
                else if (hor < 0)
                {
                    return MotionDirection.ForwardLeft;
                }
                else
                {
                    return MotionDirection.Forward;
                }
            }
            else if (vert < 0)
            {
                if (hor > 0)
                {
                    return MotionDirection.BackwardRight;
                }
                else if (hor < 0)
                {
                    return MotionDirection.BackwardLeft;
                }
                else
                {
                    return MotionDirection.Backward;
                }
            }
            else
            {
                if (hor > 0)
                {
                    return MotionDirection.Right;
                }
                else if (hor < 0)
                {
                    return MotionDirection.Left;
                }
                else
                {
                    return MotionDirection.Zero;
                }
            }
        }
        public static MotionDirections2 GetDirection2(float vert, float hor)
        {
            if (vert > 0)
            {
                if (hor > 0)
                {
                    return MotionDirections2.ForwardRight;
                }
                else if (hor < 0)
                {
                    return MotionDirections2.ForwardLeft;
                }
                else
                {
                    return MotionDirections2.Forward;
                }
            }
            else if (vert < 0)
            {
                if (hor > 0)
                {
                    return MotionDirections2.BackwardRight;
                }
                else if (hor < 0)
                {
                    return MotionDirections2.BackwardLeft;
                }
                else
                {
                    return MotionDirections2.Backward;
                }
            }
            else
            {
                if (hor > 0)
                {
                    return MotionDirections2.Right;
                }
                else if (hor < 0)
                {
                    return MotionDirections2.Left;
                }
                else
                {
                    return MotionDirections2.Zero;
                }
            }
        }
    }
}
