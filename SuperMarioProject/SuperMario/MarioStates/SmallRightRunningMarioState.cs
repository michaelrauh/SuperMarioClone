using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class SmallRightRunningMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        private double mariotimer=MarioConstants.Instance.SmallMarioTimerRun;

        public SmallRightRunningMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateSmallRightRunningMario();
            this.mario = mario;
            this.mario.marioDX = MarioConstants.Instance.SmallMarioRunDX;
        }
        public void Idle()
        {
            mario.CurrentState = new SmallRightMarioState(mario);
        }
        public void RunLeft()
        {
            mario.CurrentState = new SmallLeftRunningMarioState(mario);
        }
        public void RunRight()
        {
            
        }
        public void ToLeft()
        {
            mario.CurrentState = new SmallLeftRunningMarioState(mario);
        }

        public void ToRight()
        {
            // no change
            
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
            mario.CurrentState = new BigRightRunningMarioState(mario);
            mario.currentLocation.Y -= 40;
        }

        public void GetMushroom()
        {
            mario.CurrentState = new BigRightRunningMarioState(mario);
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
            mariotimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (mariotimer < 0)
            {
                Sprite.Update();
                mario.currentLocation.X +=mario.marioDX;
                mario.currentLocation.Y += mario.marioDY;
                mariotimer = MarioConstants.Instance.SmallMarioTimerRun;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}