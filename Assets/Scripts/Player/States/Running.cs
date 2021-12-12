using System;
using System.Collections.Generic;
using UnityEngine;
using Unprogressed.Common;

namespace Unprogressed.Player
{
    public class Running : State, IDirectable
    {
        public Dictionary<MotionDirection, Animations> animations { get; set; } = new Dictionary<MotionDirection, Animations>();
        public override PlayerStates StateType { get; } = PlayerStates.Running;
        public Running()
        {
            animations[MotionDirection.Forward] = Animations.RunForward;
            animations[MotionDirection.ForwardRight] = Animations.RunForwardRight;
            animations[MotionDirection.Right] = Animations.RunRight;
            animations[MotionDirection.BackwardRight] = Animations.RunBackwardRight;
            animations[MotionDirection.Backward] = Animations.RunBackward;
            animations[MotionDirection.BackwardLeft] = Animations.RunBackwardLeft;
            animations[MotionDirection.Left] = Animations.RunLeft;
            animations[MotionDirection.ForwardLeft] = Animations.RunForwardLeft;
        }
        public static bool StateTrigger()
        {
            if (Input.GetKey(KeyCode.LeftShift) /*&& (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)*/)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
