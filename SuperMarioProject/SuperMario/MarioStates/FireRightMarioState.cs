using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class FireRightMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public FireRightMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateFireRightMario();
            this.mario = mario;
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
            mario.CurrentState = new FireLeftMarioState(mario);
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
            mario.CurrentState = new FireRightCrouchMarioState(mario);
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