using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario.Commands
{
    class SmallMarioDeadCommand:ICommand
    {
        public Game1 myGame;

        public SmallMarioDeadCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite = SpriteFactory.SmallMarioDeadLoad(myGame.deadMario);
        }
    }
}
