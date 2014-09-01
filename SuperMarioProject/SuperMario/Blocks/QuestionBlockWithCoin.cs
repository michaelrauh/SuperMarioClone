using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Blocks
{
    public class QuestionBlockWithCoin : IBlock
    {
        public Rectangle DestinationRectangle { get; set; }
        Vector2 currentLocation;
        IAnimatedSprite blockSprite;
        double spriteTimer;
        double bumpingTimer;
        bool used;
        static int bumpingVelocity = 5;
        IItem coin;

        public QuestionBlockWithCoin(Vector2 location)
        {
            currentLocation = location;
            blockSprite = SpriteFactory.CreateQuestionBlock();
            DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, blockSprite.Width, blockSprite.Height);
            spriteTimer = 0.1;
            bumpingTimer = 0;
            used = false;
            coin = new Items.Coin(new Vector2(location.X + 10, location.Y));
        }

        public void HitBySmallMario()
        {
            if (!used)
            {
                blockSprite = SpriteFactory.CreateUsedBlock();
                bumpingTimer = 0.2;
                used = true;
                coin.Activate();
            }
        }

        public void Update(GameTime gameTime)
        {
            Flash(gameTime);
            Bump(gameTime);
            DestinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, blockSprite.Width, blockSprite.Height);
            coin.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            coin.Draw(spriteBatch);
            blockSprite.Draw(spriteBatch, DestinationRectangle);
        }

        private void Flash(GameTime gameTime)
        {
            spriteTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (spriteTimer < 0)
            {
                blockSprite.Update();
                spriteTimer = 0.1;
            }
        }

        private void Bump(GameTime gameTime)
        {
            if (bumpingTimer > 0.1)
            {
                currentLocation.Y -= bumpingVelocity;
                bumpingTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (bumpingTimer > 0)
            {
                currentLocation.Y += bumpingVelocity;
                bumpingTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
        }


        public void HitByBigMario()
        {
            throw new NotImplementedException();
        }
    }
}
