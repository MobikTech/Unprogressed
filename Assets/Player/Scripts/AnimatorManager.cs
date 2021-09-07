using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unprogressed.Player
{
    public class AnimatorManager 
    {
        
        public static Anims GetAnimation(DirectableAnimations main, MotionDirections2 direction)
        {
            return (Anims)((int)main | (int)direction);
        }
    }
    public enum DirectableAnimations
    {
        Walking = 0b_00_0000,
        Running = 0b_01_0000,
        Swimming = 0b_10_0000,
    }
    public enum MotionDirections2
    {
        Zero = 0,
        Forward = 0b_00_0001,
        Backward = 0b_00_0010,
        Right = 0b_00_0011,
        Left = 0b_00_0100,
        ForwardRight = 0b_00_0101,
        ForwardLeft = 0b_00_0110,
        BackwardRight = 0b_00_0111,
        BackwardLeft = 0b_00_1000
    }
    public enum Anims
    {
        Idle = 0,
        WalkForward = 1,
        WalkBackward = 2,
        WalkRight = 3,
        WalkLeft = 4,
        WalkForwardRight = 5,
        WalkForwardLeft = 6,
        WalkBackwardRight = 7,
        WalkBackwardLeft = 8,

        Running = 16,
        RunForward = 17,
        RunBackward = 18,
        RunRight = 19,
        RunLeft = 20,
        RunForwardRight = 21,
        RunForwardLeft = 22,
        RunBackwardRight = 23,
        RunBackwardLeft = 24,

        Swimming = 32,
        SwimForward = 33,
        SwimBackward = 34,
        SwimRight = 35,
        SwimLeft = 36,
        SwimForwardRight = 37,
        SwimForwardLeft = 38,
        SwimBackwardRight = 39,
        SwimBackwardLeft = 40,

        JumpShort = 100,
        JumpOnAir = 101,
        JumpOnLand = 102
    }

    //public class Test : UnityEngine.MonoBehaviour
    //{
    //    [UnityEngine.SerializeField] private UnityEngine.Animator _animator;

    //    public bool IsSwimming()
    //    {
    //        throw new System.Exception();
    //    }
    //    public bool IsRunning()
    //    {
    //        throw new System.Exception();
    //    }
    //    public UnityEngine.Vector2 GetRunDirection()
    //    {
    //        throw new System.Exception();
    //    }

    //    public void LogAllStates()
    //    {
    //        Debug.Log(AnimationsNew.Walking | AnimationsNew.Forward);
    //        Debug.Log(AnimationsNew.Walking | AnimationsNew.Right);
    //    }
    //    public void LogState(params AnimationsNew[] states)
    //    {
    //        Debug.Log(AnimationsNew.Walking | AnimationsNew.Forward);
    //        Debug.Log(AnimationsNew.Walking | AnimationsNew.Right);
    //    }

    //    public void Main()
    //    {
    //        AnimationsNew animation = AnimationsNew.Walking;

    //        if (IsSwimming())
    //        {
    //            animation |= AnimationsNew.Swimming;
    //        }
    //        else if (IsRunning())
    //        {
    //            animation |= AnimationsNew.Running;
    //        }

    //        UnityEngine.Vector2 runDirection = GetRunDirection();

    //        int x = UnityEngine.Mathf.RoundToInt(UnityEngine.Mathf.Sign(runDirection.x));
    //        int y = UnityEngine.Mathf.RoundToInt(UnityEngine.Mathf.Sign(runDirection.y));

    //        animation |= x switch
    //        {
    //            1 => AnimationsNew.Right,
    //            -1 => AnimationsNew.Left,
    //            _ => throw new System.Exception()
    //        };

    //        animation |= y switch
    //        {
    //            1 => AnimationsNew.Forward,
    //            -1 => AnimationsNew.Backward,
    //            _ => throw new System.Exception()
    //        };

    //        string animationName = ((int)animation).ToString();

    //        _animator.Play(animationName);
    //    }
    //}
}
