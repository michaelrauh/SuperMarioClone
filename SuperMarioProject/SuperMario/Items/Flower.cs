using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Items
{
    public class Flower : IItem
    {
        public Rectangle DestinationRectangle { get; set; }
        Vector2 currentLocation;
        IAnimatedSprite flowerSprite;
        Boolean activated;
        double flashingTimer;
        int risingHeight;
        static int yVelocity = 2;
        double activateDelayTimer; // the flower appears after the block bumps

        public Flower(Vector2 location)
        {
            currentLocation = location;
            flowerSprite = SpriteFactory.CreateFireFlower();
            DestinationRectangle = new Rectangle();
            activated = false;
            flashingTimer = 0.05;
            risingHeight = flowerSprite.Height;
        }

        public void Update(GameTime gameTime)
        {
            if (activated)
            {
                activateDelayTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                if (activateDelayTimer < 0)
                {
                    Flash(gameTime);
                    Rise();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (activated) flowerSprite.Draw(spriteBatch, DestinationRectangle);
        }

        public void Activate()
        {
            activated = true;
            activateDelayTimer = 0.5;
        }

        public void HitByMario()
        {
            activated = false;
            DestinationRectangle = new Rectangle();
        }

        private void Rise()
        {
            if (risingHeight > 0)
            {
                currentLocation.Y -= yVelocity;
                DestinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, flowerSprite.Width, flowerSprite.Height);
                risingHeight -= yVelocity;
            }
        }

        private void Flash(GameTime gameTime)
        {
            flashingTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (flashingTimer < 0)
            {
                flowerSprite.Update();
                flashingTimer = 0.05;
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


        public void BumpLeft(int blockSide)
        {
            
        }

        public void BumpRight(int blockSide)
        {

        }


        public void JumpFromGround()
        {
            throw new NotImplementedException();
        }
    }
}
