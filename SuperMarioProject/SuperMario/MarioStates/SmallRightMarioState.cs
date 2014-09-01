using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    public class SmallRightMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public SmallRightMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateSmallRightMario();
            this.mario = mario;
            this.mario.isStanding = true;
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
            mario.CurrentState = new SmallLeftMarioState(mario);
        }

        public void ToRight()
        {
            //right
        }

        public void Jump()
        {
            mario.CurrentState = new SmallRightJumpingMarioState(mario);
        }

        public void Crouch()
        {
             // small Mario doesn't crouch
        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
        }

        public void GetFlower()
        {
            mario.CurrentState = new BigRightMarioState(mario);
            mario.currentLocation.Y -= 40;
        }

        public void GetMushroom()
        {
            mario.CurrentState = new BigRightMarioState(mario);
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
            mario.CurrentState = new SmallRightWalkMarioState(mario);
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
