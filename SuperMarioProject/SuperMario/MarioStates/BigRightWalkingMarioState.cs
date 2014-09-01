using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    public class BigRightWalkingMarioState:IMarioState
    {
	    public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public BigRightWalkingMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateBigRightWalkingMario();
            this.mario = mario;
        }
        public void Idle()
        {
            mario.CurrentState = new BigRightMarioState(mario);
        }
        public void Run()
        {
            //running
            mario.CurrentState.Idle(); // This is only for this sprint to get it to toggle
        }

        public void Walk()
        {
            // no change
        }
        public void ToLeft()
        {
            mario.CurrentState = new BigLeftWalkingMarioState(mario);
        }

        public void ToRight()
        {
            //no change, already facing right
        }

        public void Jump()
        {
            mario.CurrentState = new BigRightJumpingMarioState(mario);
        }

        public void Crouch()
        {
            mario.CurrentState = new BigRightCrouchMarioState(mario);
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
        }

        public void GetFlower()
        {
            mario.CurrentState = new FireRightWalkingMarioState(mario);
        }

        public void GetMushroom()
        {
            
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallRightWalkingMarioState(mario);
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

