using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class SmallRightJumpingMarioCommand : ICommand
    {
        public Game1 myGame;

        public SmallRightJumpingMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite = SpriteFactory.SmallRightJumpingMarioLoad(myGame.smallRightMarioTexture);
        }
    }
}
