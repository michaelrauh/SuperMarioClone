using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Blocks
{
    public class BrickBlockWithCoins : IBlock
    {
        public Rectangle DestinationRectangle { get; set; }
        Vector2 currentLocation;
        IAnimatedSprite blockSprite;
        double bumpingTimer;
        double coinTimer;
        static int bumpingVelocity = 2;
        bool activated;
        IItem coin;
        Vector2 coinInitialLocation;
        bool used;

        public BrickBlockWithCoins(Vector2 location, double coinTimer)
        {
            currentLocation = location;
            blockSprite = SpriteFactory.CreateBrickBlock();
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, blockSprite.Width, blockSprite.Height);
            bumpingTimer = 0;
            this.coinTimer = coinTimer;
            coinInitialLocation = new Vector2(location.X + 10, location.Y);
            coin = new Items.Coin(coinInitialLocation);
            used = false;
        }

        public void Update(GameTime gameTime)
        {
            if (activated) coinTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            Bump(gameTime);
            DestinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, blockSprite.Width, blockSprite.Height);
            coin.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            coin.Draw(spriteBatch);
            blockSprite.Draw(spriteBatch, DestinationRectangle);
        }


        public void HitBySmallMario()
        {
            if (!used)
            {
                activated = true;
                if (coinTimer < 0)
                {
                    blockSprite = SpriteFactory.CreateUsedBlock();
                    activated = false;
                    used = true;
                }
                bumpingTimer = 0.3;
                coin = new Items.Coin(coinInitialLocation);
                coin.Activate();
            }
        }

        private void Bump(GameTime gameTime)
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



        public void HitByBigMario()
        {
            throw new NotImplementedException();
        }
    }
}
