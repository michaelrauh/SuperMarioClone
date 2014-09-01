using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class SmallRightWalkMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        private double mariotimer=MarioConstants.Instance.SmallMarioTimer;

        public SmallRightWalkMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateSmallRightRunningMario();
            this.mario = mario;
            this.mario.marioDX = MarioConstants.Instance.SmallMarioDX;
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
            mario.CurrentState = new SmallRightRunningMarioState(mario);
        }
        public void ToLeft()
        {
            mario.CurrentState = new SmallLeftWalkMarioState(mario);
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
           //can't crouch

        }

        public void GetStar()
        {
            mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
        }

        public void GetFlower()
        {
            mario.CurrentState = new BigRightWalkMarioState(mario);
            mario.currentLocation.Y -= 40;
        }

        public void GetMushroom()
        {
            mario.CurrentState = new BigRightWalkMarioState(mario);
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
                mario.currentLocation.X = mario.currentLocation.X + mario.marioDX;
                mario.currentLocation.Y = mario.currentLocation.Y + mario.marioDY;
                mariotimer = MarioConstants.Instance.SmallMarioTimer;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}