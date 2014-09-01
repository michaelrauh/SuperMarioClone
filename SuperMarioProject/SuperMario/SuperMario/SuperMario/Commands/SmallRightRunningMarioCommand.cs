using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace SuperMario.Commands
{
    class SmallRightRunningMarioCommand : ICommand
    {
        public Game1 myGame;

        public SmallRightRunningMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioSprite=SpriteFactory.SmallRightRunningMarioLoad(myGame.smallRightMarioTexture);
        }
    }
}
