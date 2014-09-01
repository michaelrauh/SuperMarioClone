using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class BigRightRunningMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        double mariotimer = MarioConstants.Instance.BigMarioTimer;

        public BigRightRunningMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateBigRightRunningMario();
            this.mario = mario;
            this.mario.marioDX = MarioConstants.Instance.BigMarioRunDX;
        }
        public void Idle()
        {
            mario.CurrentState = new BigRightMarioState(mario);
        }
        public void RunLeft()
        {
            mario.CurrentState = new BigLeftRunningMarioState(mario);
        }
        public void RunRight()
        {
        }
        public void ToLeft()
        {
            mario.CurrentState = new BigLeftRunningMarioState(mario);
        }

        public void ToRight()
        {
            //right
        }

        public void Jump()
        {
            mario.CurrentState = new BigRightJumpingMarioState(mario);
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
            mario.CurrentState = new FireRightRunningMarioState(mario);
        }

        public void GetMushroom()
        {
            
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallRightRunningMarioState(mario);
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
            mariotimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (mariotimer < 0)
            {
                Sprite.Update();
                mario.currentLocation.X += mario.marioDX;
                mario.currentLocation.Y += mario.marioDY;
                mariotimer = MarioConstants.Instance.BigMarioTimer;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}