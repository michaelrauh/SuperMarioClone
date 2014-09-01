using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class SmallRightMarioCommand : ICommand
    {
        public Game1 myGame;

        public SmallRightMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite = SpriteFactory.SmallRightMarioLoad(myGame.smallRightMarioTexture);
        }
    }
}
