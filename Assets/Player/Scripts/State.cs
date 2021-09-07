using System;

namespace Unprogressed.Player
{
    public abstract class State
    {
        private event Action StateAction;
        public abstract PlayerStates StateType { get; }
        public void RunBehaviour() => StateAction?.Invoke();
        /// <summary>
        /// needs refactor
        /// </summary>
        public State AddAction(Action action)
        {
            StateAction += action;
            return this;
        }
    }
}
