using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    public class BigLeftWalkingMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public BigLeftWalkingMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateBigLeftWalkingMario();
            this.mario = mario;
        }
        public void Idle()
        {
            mario.CurrentState = new BigLeftMarioState(mario);
        }
        public void Run()
        {
            //running
            mario.CurrentState=new BigLeftRunningMarioState(mario); // This is only for this sprint to get it to toggle
        }

        public void Walk()
        {
            // no change
        }
        public void ToLeft()
        {
            // no change
        }

        public void ToRight()
        {
            mario.CurrentState = new BigRightWalkingMarioState(mario);
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
            mario.CurrentState = new FireLeftWalkingMarioState(mario);
        }

        public void GetMushroom()
        {

        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallLeftWalkingMarioState(mario);
            mario.currentLocation.Y += 40;
        }

        public void GetCoin()
        {

        }

        public void Update()
        {
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
