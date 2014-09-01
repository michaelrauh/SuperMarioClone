using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class FireLeftRunningMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        double mariotimer = MarioConstants.Instance.BigMarioTimerRun;

        public FireLeftRunningMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateFireLeftRunningMario();
            this.mario = mario;
            this.mario.marioDX = MarioConstants.Instance.BigMarioRunDX;
        }
        public void Idle()
        {
            mario.CurrentState = new FireLeftMarioState(mario);
        }
        public void RunLeft()
        {
            //Running left
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
            mario.CurrentState = new FireRightRunningMarioState(mario);
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
            
        }

        public void GetMushroom()
        {
            
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallLeftRunningMarioState(mario);
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
            mariotimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (mariotimer < 0)
            {
                Sprite.Update();
                mario.currentLocation.X += mario.marioDX;
                mario.currentLocation.Y += mario.marioDY;
                mariotimer = MarioConstants.Instance.BigMarioTimerRun;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}