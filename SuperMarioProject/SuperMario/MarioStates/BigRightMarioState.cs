using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class BigRightMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public BigRightMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateBigRightMario();
            this.mario = mario;
            this.mario.marioDX = 0;
        }
        public void Idle()
        {
            //idle
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
            mario.CurrentState = new BigLeftMarioState(mario);
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
            mario.CurrentState = new FireRightMarioState(mario);
        }

        public void GetMushroom()
        {
            //already big
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallRightMarioState(mario);
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
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}