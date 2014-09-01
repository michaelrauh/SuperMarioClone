using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    public class SmallRightWalkingMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public SmallRightWalkingMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateSmallRightWalkingMario();
            this.mario = mario;
        }
        public void Idle()
        {
            mario.CurrentState = new SmallRightMarioState(mario);
        }
        public void Run()
        {
            //running
            mario.CurrentState=new SmallRightRunningMarioState(mario); // This is only for this sprint to get it to toggle
        }

        public void Walk()
        {
            // no change
        }
        public void ToLeft()
        {
            mario.CurrentState = new SmallLeftWalkingMarioState(mario);
        }

        public void ToRight()
        {
            //no change, already facing right
        }

        public void Jump()
        {
            mario.CurrentState = new SmallRightJumpingMarioState(mario);
        }

        public void Crouch()
        {
            // no change
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
        }

        public void GetFlower()
        {
            mario.CurrentState = new BigRightWalkingMarioState(mario);
        }

        public void GetMushroom()
        {

        }

        public void TakeDamage()
        {
            mario.CurrentState = new MarioDeathState(mario);
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

