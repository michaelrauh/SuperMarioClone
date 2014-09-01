using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class BigRightJumpingMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        private double marioTimer = MarioConstants.Instance.BigMarioTimer;
        private bool jumpMethodCalled = true;

        public BigRightJumpingMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateBigRightJumpingMario();
            this.mario = mario;
            this.mario.marioDY = MarioConstants.Instance.BigMarioJump;
            this.mario.isStanding = false;
            this.mario.isJumping = true;
        }
        public void Idle()
        {
            mario.CurrentState = new BigRightFallingMarioState(mario);
        }
        public void RunLeft()
        {
            
        }
        public void RunRight()
        {
            
        }
        public void ToLeft()
        {
            mario.CurrentState = new BigLeftJumpingMarioState(mario);
        }

        public void ToRight()
        {
            //already right
        }

        public void Jump()
        {
            jumpMethodCalled = true;
            mario.marioDY *= (float)MarioConstants.Instance.decayFactor;
        }

        public void Crouch()
        {
            mario.CurrentState = new BigRightCrouchMarioState(mario);
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
        }

        public void GetFlower()
        {
            mario.CurrentState = new FireRightJumpingMarioState(mario);
        }

        public void GetMushroom()
        {
            //already big
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallRightJumpingMarioState(mario);
            mario.currentLocation.Y += 40;
        }

        public void GetCoin()
        {

        }
        public void Walk()
        {
            mario.CurrentState = new BigRightWalkMarioState(mario);
        }
        public void Update(GameTime gameTime)
        {
            marioTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (marioTimer < 0)
            {
                Sprite.Update();
                mario.currentLocation.Y += mario.marioDY;
                mario.currentLocation.X += mario.marioDX;
            }
            if ((mario.marioDY <= MarioConstants.Instance.zeroDisplacementEquivalent
                && mario.marioDY >= -MarioConstants.Instance.zeroDisplacementEquivalent) || !jumpMethodCalled)
            {
                mario.CurrentState = new BigRightFallingMarioState(mario);
            }
            jumpMethodCalled = false;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}