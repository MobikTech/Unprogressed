using System;
using System.Collections.Generic;

namespace Unprogressed.Player
{
    public class StateManager
    {
        private Dictionary<PlayerStates, State> _states = new Dictionary<PlayerStates, State>();
        public State ActiveState { get; set; }
        public Animations ActiveAnimation { get; set; }


        public State GetState(PlayerStates stateName) => _states[stateName];
        public State RegisterState(State state, Action action)
        {
            return _states[state.StateType] = state.AddAction(action);
        }
        public void ChangeState(PlayerStates state)
        {
            if (state != ActiveState.StateType)
            {
                ActiveState = GetState(state);
            }
        }
        public bool TryChangeDirectableAnimation<TState>(TState state, PlayerController player, MotionDirection direction) where TState : IDirectable
        {
            if (ActiveAnimation == state.animations[direction])
            {
                return false;
            }
            else
            {
                player._animator.SetInteger("State", (int)state.animations[direction]);
                ActiveAnimation = state.animations[direction];
                return true;
            }
        }
        public bool TryChangeAnimation(PlayerController player, Animations animation)
        {
            if (ActiveAnimation == animation)
            {
                return false;
            }
            else
            {
                player._animator.SetInteger("State", (int)animation);
                ActiveAnimation = animation;
                return true;
            }
        }
    }
}
