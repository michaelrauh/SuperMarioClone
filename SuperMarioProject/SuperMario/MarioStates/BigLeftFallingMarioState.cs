using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    public class BigLeftFallingMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        private double mariotimer = MarioConstants.Instance.BigMarioTimer;


        public BigLeftFallingMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateBigLeftJumpingMario();
            this.mario = mario;
            this.mario.isJumping = false;
            if (!mario.isFalling)
            {
                this.mario.marioDY = MarioConstants.Instance.BigMarioFall;
            }
            mario.isFalling = true;
        }
        public void Idle()
        {
        }
        public void RunLeft()
        {
        }
        public void RunRight()
        {
        }
        public void ToLeft()
        {
        }

        public void ToRight()
        {
        }

        public void Jump()
        {
        }

        public void Crouch()
        {
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
        }

        public void GetFlower()
        {
            mario.CurrentState = new BigRightWalkMarioState(mario);
            mario.currentLocation.Y -= 40;
        }

        public void GetMushroom()
        {
            mario.CurrentState = new BigRightWalkMarioState(mario);
        }

        public void TakeDamage()
        {
            mario.CurrentState = new MarioDeathState(mario);
        }

        public void GetCoin()
        {

        }
        public void Walk()
        {
            //walking
        }
        public void Update(GameTime gameTime)
        {
            mariotimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (mariotimer < 0)
            {
                Sprite.Update();
                mario.currentLocation.Y += mario.marioDY;
                mario.currentLocation.X += mario.marioDX;
                mariotimer = MarioConstants.Instance.BigMarioTimer;
            }
            if (mario.marioDY < 15)
            {
                mario.marioDY *= MarioConstants.Instance.growthFactor;
            }
            if (mario.bottomBlocked)
            {
                mario.isFalling = false;
                mario.isStanding = true;
                mario.marioDY = 0;
                mario.CurrentState = new BigLeftMarioState(mario);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
