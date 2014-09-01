using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Blocks
{
    public class FloorBlock : IBlock
    {
        public Rectangle DestinationRectangle { get; set; }
        Vector2 currentLocation;
        IAnimatedSprite blockSprite;

        public FloorBlock(Vector2 location)
        {
            currentLocation = location;
            blockSprite = SpriteFactory.CreateFloorBlock();
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, blockSprite.Width, blockSprite.Height);
        }

        public void Update(GameTime gameTime)
        {
            blockSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            blockSprite.Draw(spriteBatch, DestinationRectangle);
        }


        public void HitBySmallMario()
        {
            
        }


        public void HitByBigMario()
        {
            
        }
    }
}
