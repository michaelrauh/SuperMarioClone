using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class BigRightWalkMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        double mariotimer = MarioConstants.Instance.BigMarioTimer;

        public BigRightWalkMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateBigRightRunningMario();
            this.mario = mario;
            this.mario.marioDX = MarioConstants.Instance.BigMarioDX;
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
            mario.CurrentState = new BigRightRunningMarioState(mario);
        }
        public void ToLeft()
        {
            mario.CurrentState = new BigLeftWalkMarioState(mario);
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
            mario.CurrentState = new FireRightWalkMarioState(mario);
        }

        public void GetMushroom()
        {
            //already big
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallRightWalkMarioState(mario);
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