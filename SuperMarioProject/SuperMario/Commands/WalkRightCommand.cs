using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class WalkRightCommand : ICommand
    {
        Mario mario;
        public WalkRightCommand(Mario mario)
        {
            this.mario=mario;
        }
        public void Execute()
        {
            if (!mario.isDead)
            {
                mario.CurrentState.ToRight();
                mario.CurrentState.Walk();
            }
        }
    }
}
