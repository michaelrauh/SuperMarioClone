using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class SmallLeftMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public SmallLeftMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateSmallLeftMario();
            this.mario = mario;
            this.mario.marioDX = 0;
        }
        public void Idle()
        {
            //idle
        }
        public void RunLeft()
        {
            mario.CurrentState = new SmallLeftRunningMarioState(mario);
        }
        public void RunRight()
        {
            mario.CurrentState = new SmallRightRunningMarioState(mario);
        }
        public void ToLeft()
        {
            //left
        }

        public void ToRight()
        {
            mario.CurrentState = new SmallRightMarioState(mario);
        }

        public void Jump()
        {
            mario.CurrentState = new SmallLeftJumpingMarioState(mario);
        }

        public void Crouch()
        {
            // small Mario can't crouch
            
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            
        }

        public void GetFlower()
        {
            mario.CurrentState = new BigLeftMarioState(mario);
            mario.currentLocation.Y -= 40;
        }

        public void GetMushroom()
        {
            mario.CurrentState = new BigLeftMarioState(mario);
            mario.currentLocation.Y -= 40;
        }

        public void TakeDamage()
        {
            mario.CurrentState = new MarioDeathState(mario);
        }

        public void GetCoin()
        {

        }
        public void Walk()
        {
            mario.CurrentState = new SmallLeftWalkMarioState(mario);
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
