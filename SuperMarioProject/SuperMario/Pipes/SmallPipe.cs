using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace SuperMario.Pipes
{
    public class SmallPipe:IPipe
    {
        public Rectangle DestinationRectangle { get; set; }
        Vector2 currentlocation;
        IAnimatedSprite pipeSprite;

        public SmallPipe(Vector2 location)
        {
            currentlocation = location;
            pipeSprite = SpriteFactory.CreateSmallPipe();
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, pipeSprite.Width, pipeSprite.Height);
        }

        public void Update()
        {
            pipeSprite.Update();
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            pipeSprite.Draw(spriteBatch, DestinationRectangle);
        }
    }
}
