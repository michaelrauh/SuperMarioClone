using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    public class FireRightWalkingMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public FireRightWalkingMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateFireRightWalkingMario();
            this.mario = mario;
        }
        public void Idle()
        {
            mario.CurrentState = new FireRightMarioState(mario);
        }
        public void Run()
        {
            //running
            mario.CurrentState=new FireRightRunningMarioState(mario); // This is only for this sprint to get it to toggle
        }

        public void Walk()
        {
            // no change
        }
        public void ToLeft()
        {
            mario.CurrentState = new FireLeftWalkingMarioState(mario);
        }

        public void ToRight()
        {
            //no change, already facing right
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

