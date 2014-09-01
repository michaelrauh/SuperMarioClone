using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    public class MoveRightCommand : ICommand
    {
        Mario mario;
        public MoveRightCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            if (!mario.isDead)
            {
                mario.CurrentState.ToRight();
                mario.currentLocation.X++;
            }
        }
    }
}
