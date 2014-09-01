using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class SmallLeftMarioCommand : ICommand
    {
        public Game1 myGame;

        public SmallLeftMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite = SpriteFactory.SmallLeftMarioLoad(myGame.smallLeftMarioTexture);
        }
    }
}
