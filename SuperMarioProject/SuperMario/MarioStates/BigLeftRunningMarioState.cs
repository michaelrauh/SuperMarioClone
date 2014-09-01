using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class BigLeftRunningMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        double mariotimer = MarioConstants.Instance.BigMarioTimerRun;

        public BigLeftRunningMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateBigLeftRunningMario();
            this.mario = mario;
            this.mario.marioDX = MarioConstants.Instance.BigMarioRunDX;
        }
        public void Idle()
        {
            mario.CurrentState = new BigLeftMarioState(mario);
        }
        public void RunLeft()
        {
           // Running left
        }
        public void RunRight()
        {
            mario.CurrentState = new BigRightRunningMarioState(mario);
        }
        public void ToLeft()
        {
            //already left
        }

        public void ToRight()
        {
            mario.CurrentState = new BigRightRunningMarioState(mario);
        }

        public void Jump()
        {
            mario.CurrentState = new BigLeftJumpingMarioState(mario);
        }

        public void Crouch()
        {
            mario.CurrentState = new BigLeftCrouchMarioState(mario);
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
        }

        public void GetFlower()
        {
            mario.CurrentState = new FireLeftRunningMarioState(mario);
        }

        public void GetMushroom()
        {
            //already big
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallLeftRunningMarioState(mario);
            mario.currentLocation.Y += 40;
        }

        public void GetCoin()
        {

        }
        public void Walk()
        {
            mario.CurrentState = new BigLeftWalkMarioState(mario);
        }
        public void Update(GameTime gameTime)
        {
            mariotimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (mariotimer < 0)
            {
                Sprite.Update();
                mario.currentLocation.X += mario.marioDX;
                mario.currentLocation.Y += mario.marioDY;
                mariotimer = MarioConstants.Instance.BigMarioTimerRun;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}