using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Items
{
    public class OneUpMushroom : IItem
    {
        public Rectangle DestinationRectangle { get; set; }
        Vector2 currentLocation;
        IAnimatedSprite currentSprite;
        Boolean activated;
        int risingHeight;
        double yVelocity;
        double xVelocity;
        double activateDelayTimer; // the mushroom appears after the block bumps
        bool escapedFromBlock;

        public OneUpMushroom(Vector2 location)
        {
            currentLocation = location;
            currentSprite = SpriteFactory.CreateOneUpMushroom();
            xVelocity = 0;
            yVelocity = 0;
            DestinationRectangle = new Rectangle();
            activated = false;
            escapedFromBlock = false;
            risingHeight = currentSprite.Height;
        }

        public void Update(GameTime gameTime)
        {
            if (activated)
            {
                activateDelayTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                if (activateDelayTimer < 0)
                {
                    if (risingHeight > 0) Rise();
                    else if (risingHeight == 0)
                    {
                        xVelocity = 2;
                        yVelocity = 3;
                        escapedFromBlock = true;
                        risingHeight = -1;
            }
                    yVelocity *= 1.05;
                    currentLocation.X += (int)xVelocity;
                    currentLocation.Y += (int)yVelocity;
                    DestinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, currentSprite.Width, currentSprite.Height);
        }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (activated) currentSprite.Draw(spriteBatch, DestinationRectangle);
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
            yVelocity = -2;
            risingHeight += (int)yVelocity;
        }

        public void ChangeDirection()
        {
            if (escapedFromBlock) xVelocity = -xVelocity;
        }

        public void BumpUp(int blockSide)
        {
            if (escapedFromBlock) currentLocation.Y = blockSide - currentSprite.Height;
            yVelocity = 3;
        }

        public void BumpDown(int blockSide)
        {
            if (escapedFromBlock) currentLocation.Y = blockSide;
        }

        public void BumpLeft(int blockSide)
        {
            if (escapedFromBlock) currentLocation.X = blockSide - currentSprite.Width;
        }

        public void BumpRight(int blockSide)
        {
            if (escapedFromBlock) currentLocation.X = blockSide;
        }


        public void JumpFromGround()
        {
            
        }
    }
}
