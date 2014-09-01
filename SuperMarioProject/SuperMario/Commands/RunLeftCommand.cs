using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class RunLeftCommand : ICommand
    {
        Mario mario;
        public RunLeftCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.CurrentState.RunLeft();
        }
    }
}