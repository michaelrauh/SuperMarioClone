using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class FireRightJumpingMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public FireRightJumpingMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateFireRightJumpingMario();
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
            mario.CurrentState = new FireLeftJumpingMarioState(mario);
        }

        public void ToRight()
        {
            //right
        }

        public void Jump()
        {
            //jumping
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
            ////already fire
        }

        public void GetMushroom()
        {
            //already fire
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallRightJumpingMarioState(mario);
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