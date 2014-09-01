using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
      class JumpingCommand : ICommand
    {
        Mario mario;
        public JumpingCommand(Mario mario)
        {
            this.mario=mario;
        }
        public void Execute()
        {
            if (!mario.isDead)
            {
                    mario.CurrentState.Jump();
            }
        }
    }
}
