using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class RunRightCommand : ICommand
    {
        Mario mario;
        public RunRightCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.CurrentState.RunRight();
        }
    }
}