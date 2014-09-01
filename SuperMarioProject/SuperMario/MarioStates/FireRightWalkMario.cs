using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class FireRightWalkMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        double mariotimer;

        public FireRightWalkMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateFireRightRunningMario();
            this.mario = mario;
            mariotimer = 0.25;
        }
        public void Idle()
        {
            mario.CurrentState = new FireRightMarioState(mario);
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
            mario.CurrentState = new FireLeftWalkMarioState(mario);
        }

        public void ToRight()
        {
           //right
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
           //already fire
        }

        public void GetMushroom()
        {
            //already big
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallRightWalkMarioState(mario);
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
                mariotimer = 0.25;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}