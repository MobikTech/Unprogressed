﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unprogressed.Player
{
    public class Swimming : State, IDirectable
    {
        public Dictionary<MotionDirection, Animations> animations { get; set; } = new Dictionary<MotionDirection, Animations>();
        public override PlayerStates StateType { get; } = PlayerStates.Swimming;
        public Swimming()
        {
            animations[MotionDirection.Forward] = Animations.WalkForward;
            animations[MotionDirection.ForwardRight] = Animations.WalkForwardRight;
            animations[MotionDirection.Right] = Animations.WalkRight;
            animations[MotionDirection.BackwardRight] = Animations.WalkBackwardRight;
            animations[MotionDirection.Backward] = Animations.WalkBackward;
            animations[MotionDirection.BackwardLeft] = Animations.WalkBackwardLeft;
            animations[MotionDirection.Left] = Animations.WalkLeft;
            animations[MotionDirection.ForwardLeft] = Animations.WalkForwardLeft;
        }

        public static bool InWater { get; set; } = false;
        public static bool StateTrigger()
        {
            if (InWater)
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