using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    public class MoveUpCommand : ICommand
    {
        Mario mario;
        public MoveUpCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            if (!mario.isDead)
            {
                mario.currentLocation.Y--;
            }
        }
    }
}
