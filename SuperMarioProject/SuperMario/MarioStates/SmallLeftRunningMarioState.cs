using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class SmallLeftRunningMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        double mariotimer = MarioConstants.Instance.SmallMarioTimerRun;

        public SmallLeftRunningMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateSmallLeftRunningMario();
            this.mario = mario;
            this.mario.marioDX = -MarioConstants.Instance.SmallMarioRunDX;
        }
        public void Idle()
        {
            mario.CurrentState = new SmallLeftMarioState(mario);
        }
        public void RunLeft()
        {
            
        }
        public void RunRight()
        {
            mario.CurrentState = new SmallRightRunningMarioState(mario);
        }
        public void ToLeft()
        {
            // no change
            
        }

        public void ToRight()
        {
            mario.CurrentState = new SmallRightRunningMarioState(mario);
        }

        public void Jump()
        {
            mario.CurrentState = new SmallLeftJumpingMarioState(mario);
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
            mario.CurrentState = new BigLeftRunningMarioState(mario);
            mario.currentLocation.Y -= 40;
        }

        public void GetMushroom()
        {
            mario.CurrentState = new BigLeftRunningMarioState(mario);
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
            mariotimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (mariotimer < 0)
            {
                Sprite.Update();
                mario.currentLocation.X += mario.marioDX;
                mario.currentLocation.Y+=mario.marioDY;
                mariotimer = MarioConstants.Instance.SmallMarioTimerRun;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}