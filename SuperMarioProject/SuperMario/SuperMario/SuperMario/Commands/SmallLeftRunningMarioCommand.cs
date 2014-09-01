using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class SmallLeftRunningMarioCommand : ICommand
    {
        public Game1 myGame;

        public SmallLeftRunningMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite = SpriteFactory.SmallLeftRunningMarioLoad(myGame.smallLeftMarioTexture);
        }
    }
}
