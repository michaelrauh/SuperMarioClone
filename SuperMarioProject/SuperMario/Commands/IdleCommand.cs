using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class IdleCommand : ICommand
    {
           Mario mario;
        public IdleCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            if (!mario.isDead)
            {
                mario.CurrentState.Idle();
            }
        }
    }
}
