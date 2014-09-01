using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class CrouchingCommand : ICommand
    {
        Mario mario;
        public CrouchingCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            if (!mario.isDead)
            {
                mario.CurrentState.Crouch();
                mario.currentLocation.Y++;
            }
        }
    }
}
