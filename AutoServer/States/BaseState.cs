using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoServer.States
{
    public abstract class BaseState
    {
        public StateMachine machine { get; set; }

        public abstract void Start();
        public abstract void Update();
        public abstract void End();
    }
}
