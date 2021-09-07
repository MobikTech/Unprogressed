using System;
using UnityEngine;

namespace Unprogressed.Player
{
    public class Idle : State
    {
        public override PlayerStates StateType { get; } = PlayerStates.Idle;
        public static bool StateTrigger()
        {
            return Input.GetAxis("Jump") == 0 && Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 && !Input.GetKeyDown(KeyCode.LeftShift);
        }
    }
}
