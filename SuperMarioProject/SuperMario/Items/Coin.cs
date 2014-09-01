using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Items
{
    public class Coin : IItem
    {
        public Rectangle DestinationRectangle { get; set; }
        Vector2 currentLocation;
        IAnimatedSprite currentSprite;
        double flashingTimer;
        int risingDistance;
        bool activated;
        static int risingVelocity = 3;

        public Coin(Vector2 location)
        {
            currentLocation = location;            
            currentSprite = SpriteFactory.CreateCoin();
            DestinationRectangle = new Rectangle();
            risingDistance = 2 * currentSprite.Height;
            flashingTimer = 0.05;
            activated = false;
        }

        public void Activate()
        {
            activated = true;
        }

        public void HitByMario()
        {
            // do not thing
        }

        public void Update(GameTime gameTime)
        {
            if (activated)
            {
                Rise(gameTime);
                Flash(gameTime);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentSprite.Draw(spriteBatch, DestinationRectangle);
        }

        void Flash(GameTime gameTime)
        {
            flashingTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (flashingTimer < 0)
            {
                currentSprite.Update();
                flashingTimer = 0.05;
            }
        }

        void Rise(GameTime gameTime)
        {
            if (risingDistance > 0)
            {
                currentLocation.Y -= risingVelocity;
                DestinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, currentSprite.Width, currentSprite.Height);
                risingDistance -= risingVelocity;
            }
            else
            {
                activated = false;
                DestinationRectangle = new Rectangle();
            }
        }


        public void ChangeDirection()
        {
            
        }

        public void BumpUp(int bumpingDistance)
        {
            
        }

        public void BumpDown(int bumpingDistance)
        {
            
        }

        public void bumpLeft(int blockSide)
        {
            
        }

        public void bumpRight(int blockSide)
        {
            
        }


        public void BumpLeft(int blockSide)
        {
            throw new NotImplementedException();
        }

        public void BumpRight(int blockSide)
        {
            throw new NotImplementedException();
        }

        public void JumpFromGround()
        {
            throw new NotImplementedException();
        }
    }
}
