using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class IdleWalkRunCommand : ICommand
    {
        Mario mario;
        int i;
        public IdleWalkRunCommand(Mario mario)
        {
            this.mario=mario;
            i = 0;
        }
        public void Execute()
        {
            if (!mario.isDead)
            {
                if ((i % 3) == 0)
                {
                    mario.CurrentState.Idle();
                }
                else if ((i % 3) == 1)
                {
                    mario.CurrentState.Walk();
                }
                else
                {
                    mario.CurrentState.Run();
                }
                i++;
            }
        }
    }
}
