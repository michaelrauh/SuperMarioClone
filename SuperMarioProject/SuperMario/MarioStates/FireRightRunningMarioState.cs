using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace SuperMario.MarioStates
{
    class FireRightRunningMarioState:IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        double mariotimer;

        public FireRightRunningMarioState(Mario mario)
        {
            Sprite = SpriteFactory.CreateFireRightRunningMario();
            this.mario = mario;
            mariotimer = 0.1;
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
            mario.CurrentState = new FireLeftRunningMarioState(mario);
        }

        public void ToRight()
        {
            // no change
            
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
            //already fire
        }

        public void TakeDamage()
        {
            mario.CurrentState = new SmallRightRunningMarioState(mario);
            mario.currentLocation.Y += 40;
        }

        public void GetCoin()
        {

        }
        public void Walk()
        {
            mario.CurrentState = new FireRightWalkMarioState(mario);
        }
        public void Update(GameTime gameTime)
        {
            mariotimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (mariotimer < 0)
            {
                Sprite.Update();
                mariotimer = 0.1;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}