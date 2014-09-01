using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class FireRightCrouchMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public FireRightCrouchMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateFireRightCrouchMario();
            this.mario = mario;
        }
        public void Idle()
        {
            mario.CurrentState = new FireRightMarioState(mario);
        }
        public void RunLeft()
        {
           
        }
        public void RunRight()
        {
          
        }
        public void ToLeft()
        {
            mario.CurrentState = new FireLeftCrouchMarioState(mario);
        }

        public void ToRight()
        {
            //right
        }

        public void Jump()
        {
            mario.CurrentState = new FireRightJumpingMarioState(mario);
        }

        public void Crouch()
        {
            //crouching
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            
        }

        public void GetFlower()
        {
            //already fire
        }

        public void GetMushroom()
        {
            //already fire
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
            mario.CurrentState = new FireRightWalkMarioState(mario);
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