using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class BigLeftCrouchMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public BigLeftCrouchMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateBigLeftCrouchMario();
            this.mario = mario;
        }
        public void Idle()
        {
            mario.CurrentState = new BigLeftMarioState(mario);
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
            // Already left
        }

        public void ToRight()
        {
            mario.CurrentState = new BigRightCrouchMarioState(mario);
        }

        public void Jump()
        {
            mario.CurrentState = new BigLeftJumpingMarioState(mario);
        }

        public void Crouch()
        {
            //already crouched
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
        }

        public void GetFlower()
        {
            mario.CurrentState = new FireLeftCrouchMarioState(mario);
        }

        public void GetMushroom()
        {
            //already large
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallLeftMarioState(mario);
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
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}