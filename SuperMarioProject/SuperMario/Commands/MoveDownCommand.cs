using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Commands
{
    public class MoveDownCommand : ICommand
    {
        Mario mario;
        public MoveDownCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            if (!mario.isDead)
            {
                mario.currentLocation.Y++;
            }
        }
    }
}
