using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Commands
{
    class BigLeftMarioCommand : ICommand
    {
        public Game1 myGame;

        public BigLeftMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite = SpriteFactory.BigLeftMarioLoad(myGame.bigLeftMarioTexture);
        }
    }
}
