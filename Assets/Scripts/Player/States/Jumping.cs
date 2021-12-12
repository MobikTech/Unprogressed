using System.Collections.Generic;
using UnityEngine;

namespace Unprogressed.Player
{
    public class Jumping : State
    {
        //public Dictionary<MotionDirection, Animations> animations { get; set; }
        public override PlayerStates StateType { get; } = PlayerStates.Jumping;
        //public Jumping()
        //{
        //    animations[MotionDirection.Forward] = Animations.WalkForward;
        //    animations[MotionDirection.ForwardRight] = Animations.WalkForwardRight;
        //    animations[MotionDirection.Right] = Animations.WalkRight;
        //    animations[MotionDirection.BackwardRight] = Animations.WalkBackwardRight;
        //    animations[MotionDirection.Backward] = Animations.WalkBackward;
        //    animations[MotionDirection.BackwardLeft] = Animations.WalkBackwardLeft;
        //    animations[MotionDirection.Left] = Animations.WalkLeft;
        //    animations[MotionDirection.ForwardLeft] = Animations.WalkForwardLeft;
        //}
        public static bool StateTrigger()
        {
            return Input.GetAxis("Jump") != 0/* && Input.GetButtonDown("Jump")*/;
        }
    }
}
