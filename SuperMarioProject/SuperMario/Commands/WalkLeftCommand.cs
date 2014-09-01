using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class WalkLeftCommand : ICommand
    {
        Mario mario;
        public WalkLeftCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            if (!mario.isDead)
            {
                mario.CurrentState.ToLeft();
                mario.CurrentState.Walk();
            }
        }
    }
}
