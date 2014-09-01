using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class BigRightCrouchMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public BigRightCrouchMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateBigRightCrouchMario();
            this.mario = mario;
        }
        public void Idle()
        {
            mario.CurrentState = new BigRightMarioState(mario);
        }
        public void RunLeft()
        {
          
        }
        public void RunRight()
        {
           
        }
        public void ToLeft()
        {
            mario.CurrentState = new BigLeftCrouchMarioState(mario);
        }

        public void ToRight()
        {
         //already right   
        }

        public void Jump()
        {
            mario.CurrentState = new BigRightJumpingMarioState(mario);
        }

        public void Crouch()
        {
            //already crouching
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
        }

        public void GetFlower()
        {
            mario.CurrentState = new FireRightCrouchMarioState(mario);
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