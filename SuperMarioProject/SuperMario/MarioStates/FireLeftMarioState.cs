using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class FireLeftMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public FireLeftMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateFireLeftMario();
            this.mario = mario;
            this.mario.marioDX = 0;
        }
        public void Idle()
        {
            //idle
        }
        public void RunLeft()
        {
            mario.CurrentState = new FireLeftRunningMarioState(mario);
        }
        public void RunRight()
        {
            mario.CurrentState = new FireRightRunningMarioState(mario);
        }
        public void ToLeft()
        {
            //left
        }

        public void ToRight()
        {
            mario.CurrentState = new FireRightMarioState(mario);
        }

        public void Jump()
        {
            mario.CurrentState = new FireLeftJumpingMarioState(mario);
        }

        public void Crouch()
        {
            mario.CurrentState = new FireLeftCrouchMarioState(mario);
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            
        }

        public void GetFlower()
        {
            // no change
            
        }

        public void GetMushroom()
        {
            // no change
            
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