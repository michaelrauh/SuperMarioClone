using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace SuperMario.Pipes
{
    public class MediumPipe : IPipe
    {
        public Rectangle DestinationRectangle { get; set; }
        Vector2 currentlocation;
        IAnimatedSprite pipeSprite;

        public MediumPipe(Vector2 location)
        {
            currentlocation = location;
            pipeSprite = SpriteFactory.CreateMediumPipe();
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
