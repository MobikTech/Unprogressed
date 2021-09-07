using System.Collections.Generic;
using UnityEngine;

namespace Unprogressed.Player
{
    public class Walking : State, IDirectable
    {
        public Dictionary<MotionDirection, Animations> animations { get; set; } = new Dictionary<MotionDirection, Animations> 
        {
            { MotionDirection.Zero, Animations.Idle },
            { MotionDirection.Forward, Animations.WalkForward },
            { MotionDirection.ForwardRight, Animations.WalkForwardRight},
            { MotionDirection.Right, Animations.WalkRight},
            { MotionDirection.BackwardRight, Animations.WalkBackwardRight},
            { MotionDirection.Backward, Animations.WalkBackward},
            { MotionDirection.BackwardLeft, Animations.WalkBackwardLeft},
            { MotionDirection.Left, Animations.WalkLeft},
            { MotionDirection.ForwardLeft, Animations.WalkForwardLeft}
        };
        public override PlayerStates StateType { get; } = PlayerStates.Walking;
        public static bool StateTrigger()
        {
            return !Input.GetKey(KeyCode.LeftShift) && (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0);
        }
    }
}
