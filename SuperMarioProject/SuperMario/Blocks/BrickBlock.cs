using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Blocks
{
    public class BrickBlock : IBlock
    {
        public Rectangle DestinationRectangle { get; set; }
        Vector2 currentLocation;
        IAnimatedSprite blockSprite;
        double bumpingTimer;
        static int bumpingVelocity = 2;

        public BrickBlock(Vector2 location)
        {
            currentLocation = location;
            blockSprite = SpriteFactory.CreateBrickBlock();
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, blockSprite.Width, blockSprite.Height);
            bumpingTimer = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (bumpingTimer > 0.15)
            {
                currentLocation.Y -= bumpingVelocity;
                bumpingTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (bumpingTimer > 0)
            {
                currentLocation.Y += bumpingVelocity;
                bumpingTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            DestinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, blockSprite.Width, blockSprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            blockSprite.Draw(spriteBatch, DestinationRectangle);
        }


        public void HitBySmallMario()
        {
            bumpingTimer = 0.3;
        }


        public void HitByBigMario()
        {
            throw new NotImplementedException();
        }
    }
}
