using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class MoveLeftCommand : ICommand
    {
        Mario mario;
        public MoveLeftCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            if (!mario.isDead)
            {
                mario.CurrentState.ToLeft();
                mario.currentLocation.X--;
            }
        }
    }
}
