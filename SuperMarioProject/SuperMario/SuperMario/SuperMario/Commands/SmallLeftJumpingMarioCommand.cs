using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class SmallLeftJumpingMarioCommand : ICommand
    {
        public Game1 myGame;

        public SmallLeftJumpingMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite = SpriteFactory.SmallLeftJumpingMarioLoad(myGame.smallLeftMarioTexture);
        }
    }
}
