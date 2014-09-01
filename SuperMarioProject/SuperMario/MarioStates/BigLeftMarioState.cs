using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class BigLeftMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public BigLeftMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateBigLeftMario();
            this.mario = mario;
            this.mario.marioDX = 0;
        }
        public void Idle()
        {
            //already idle
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
            //already left
        }

        public void ToRight()
        {
            mario.CurrentState = new BigRightMarioState(mario);
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
            mario.CurrentState = new FireLeftMarioState(mario);
        }

        public void GetMushroom()
        {
            
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