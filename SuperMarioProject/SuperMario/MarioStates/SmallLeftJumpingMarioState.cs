using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class SmallLeftJumpingMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        private double marioTimer = MarioConstants.Instance.SmallMarioTimer;
        private bool jumpMethodCalled = true;

        public SmallLeftJumpingMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateSmallLeftJumpingMario();
            this.mario = mario;
            this.mario.marioDY = MarioConstants.Instance.SmallMarioJump;
            this.mario.isStanding = false;
            this.mario.isJumping = true;
        }
        public void Idle()
        {
            mario.CurrentState = new SmallLeftFallingMarioState(mario);
        }
        public void RunLeft()
        {
            
        }
        public void RunRight()
        {
            
        }
        public void ToLeft()
        {
            // no change
            
        }

        public void ToRight()
        {
            mario.CurrentState = new SmallRightJumpingMarioState(mario);
        }

        public void Jump()
        {
            jumpMethodCalled = true;
            mario.marioDY *= (float)MarioConstants.Instance.decayFactor;
        }

        public void Crouch()
        {
            // no change
            mario.CurrentState = new SmallLeftMarioState(mario);
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            
        }

        public void GetFlower()
        {
            mario.CurrentState = new BigLeftJumpingMarioState(mario);
            mario.currentLocation.Y -= 40;
        }

        public void GetMushroom()
        {
            mario.CurrentState = new BigLeftJumpingMarioState(mario);
            mario.currentLocation.Y -= 40;
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
            mario.CurrentState = new SmallLeftWalkMarioState(mario);
        }
        public void Update(GameTime gameTime)
        {
            marioTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (marioTimer < 0)
            {
                Sprite.Update();
                mario.currentLocation.Y += mario.marioDY;
                mario.currentLocation.X += mario.marioDX;
                //marioTimer = MarioConstants.Instance.SmallMarioTimer;
            }
            if ((mario.marioDY <= MarioConstants.Instance.zeroDisplacementEquivalent
                && mario.marioDY >= -MarioConstants.Instance.zeroDisplacementEquivalent) || !jumpMethodCalled)
            {
                mario.CurrentState = new SmallLeftFallingMarioState(mario);
            }
            jumpMethodCalled = false;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}