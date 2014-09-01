using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    public class SmallRightFallingMarioState : IMarioState
    {
         public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        private double mariotimer=MarioConstants.Instance.SmallMarioTimer;


        public SmallRightFallingMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateSmallRightJumpingMario();
            this.mario = mario;
            this.mario.isJumping = false;
            if(!mario.isFalling)
            {
                this.mario.marioDY = MarioConstants.Instance.SmallMarioFall;
            }
            mario.isFalling = true;
        }
        public void Idle()
        {
            //mario.CurrentState = new SmallRightMarioState(mario);
        }
        public void RunLeft()
        {
            //mario.CurrentState = new SmallRightRunningMarioState(mario);
        }
        public void RunRight()
        {
            //
        }
        public void ToLeft()
        {
            //mario.CurrentState = new SmallLeftWalkMarioState(mario);
        }

        public void ToRight()
        {
            //right
        }

        public void Jump()
        {
            //mario.CurrentState = new SmallRightJumpingMarioState(mario);
        }

        public void Crouch()
        {
           //can't crouch

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
            if (mariotimer<0)
            {
                Sprite.Update();
                mario.currentLocation.Y += mario.marioDY;
                mario.currentLocation.X += mario.marioDX;
                //mariotimer = MarioConstants.Instance.SmallMarioTimer;
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
                mario.CurrentState = new SmallRightMarioState(mario);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}