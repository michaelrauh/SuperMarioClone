using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class SmallLeftWalkMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        double mariotimer=MarioConstants.Instance.SmallMarioTimer;

        public SmallLeftWalkMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateSmallLeftRunningMario();
            this.mario = mario;
            this.mario.marioDX = -MarioConstants.Instance.SmallMarioDX;
        }
        public void Idle()
        {
            mario.CurrentState = new SmallLeftMarioState(mario);
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
            mario.CurrentState = new SmallRightWalkMarioState(mario);
        }

        public void Jump()
        {
            mario.CurrentState = new SmallLeftJumpingMarioState(mario);
        }

        public void Crouch()
        {
            //can't crouch

        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
        }

        public void GetFlower()
        {
            mario.CurrentState = new BigLeftWalkMarioState(mario);
            mario.currentLocation.Y -= 40;
        }

        public void GetMushroom()
        {
            //already big
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
            //walking
        }
        public void Update(GameTime gameTime)
        {
            mariotimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (mariotimer<0)
            {
                Sprite.Update();
                mario.currentLocation.X += mario.marioDX;
                mario.currentLocation.Y+=mario.marioDY;
                mariotimer = MarioConstants.Instance.SmallMarioTimer;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}