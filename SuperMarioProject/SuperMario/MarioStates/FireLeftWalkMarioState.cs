using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class FireLeftWalkMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        double mariotimer = MarioConstants.Instance.BigMarioTimer;

        public FireLeftWalkMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateFireLeftRunningMario();
            this.mario = mario;
            this.mario.marioDX = MarioConstants.Instance.BigMarioDX;
        }
        public void Idle()
        {
            mario.CurrentState = new FireLeftMarioState(mario);
        }
        public void RunLeft()
        {
            mario.CurrentState = new FireLeftRunningMarioState(mario);
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
            mario.CurrentState = new FireRightWalkMarioState(mario);
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
            //already big
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallLeftWalkMarioState(mario);
        }

        public void GetCoin()
        {

        }
        public void Walk()
        {
            //walking
        }
        public void Update(GameTime gameTime)
        {
            mariotimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (mariotimer < 0)
            {
                Sprite.Update();
                mario.currentLocation.X += mario.marioDX;
                mario.currentLocation.Y += mario.marioDY;
                mariotimer = MarioConstants.Instance.BigMarioTimer;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}