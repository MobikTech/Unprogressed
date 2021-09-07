using System;
using System.Collections.Generic;
using Unprogressed.Common;

namespace Unprogressed.Player
{
    public interface IDirectable
    {
        public Dictionary<MotionDirection, Animations> animations { get; set; }
        //public void SetAnimation(MotionDirection direction);
    }
}
