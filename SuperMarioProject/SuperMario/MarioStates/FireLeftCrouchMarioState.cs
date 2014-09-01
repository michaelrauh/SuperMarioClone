using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class FireLeftCrouchMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public FireLeftCrouchMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateFireLeftCrouchMario();
            this.mario = mario;
        }
        public void Idle()
        {
            mario.CurrentState = new FireLeftMarioState(mario);
        }
        public void RunLeft()
        {
            
        }
        public void RunRight()
        {
           
        }
        public void ToLeft()
        {
            //left
        }

        public void ToRight()
        {
            mario.CurrentState = new FireRightCrouchMarioState(mario);
        }

        public void Jump()
        {
            mario.CurrentState = new FireLeftJumpingMarioState(mario);
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
            //fire
        }

        public void GetMushroom()
        {
            // already fire
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
            mario.CurrentState = new FireLeftWalkMarioState(mario);
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