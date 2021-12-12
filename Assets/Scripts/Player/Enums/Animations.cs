using System;
using UnityEngine;
namespace Unprogressed.Player
{
    public enum Animations
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

        RunForward = 9,
        RunBackward = 10,
        RunRight = 11,
        RunLeft = 12,
        RunForwardRight = 13,
        RunForwardLeft = 14,
        RunBackwardRight = 15,
        RunBackwardLeft = 16,

        SwimForward = 17,
        SwimBackward = 18,
        SwimRight = 19,
        SwimLeft = 20,
        SwimForwardRight = 21,
        SwimForwardLeft = 22,
        SwimBackwardRight = 23,
        SwimBackwardLeft = 24,

        JumpShort = 25,
        JumpOnAir = 26,
        JumpOnLand = 27
    }
    //public enum AnimationsNew
    //{
    //    Walking =  0b_00_0000,
    //    Running =  0b_01_0000,
    //    Swimming = 0b_10_0000,

    //    Forward =  0b_00_0001,
    //    Backward = 0b_00_0010,
    //    Right =    0b_00_0100,
    //    Left =     0b_00_1000
    //}

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
