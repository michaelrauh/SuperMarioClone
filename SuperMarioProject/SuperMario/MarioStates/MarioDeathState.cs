using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace SuperMario.MarioStates
{
    class MarioDeathState:IMarioState
    { 
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;
        int risingDistance;

        public MarioDeathState(Mario mario)
        {
            Sprite = SpriteFactory.CreateDeadMario();
            this.mario = mario;
            risingDistance = 0;
            this.mario.isDead = true;
        }
        public void Idle()
        {

        }
        public void RunLeft()
        {
          
        }
        public void RunRight()
        {
            
        }
        public void ToLeft()
        {
            
        }

        public void ToRight()
        {
            
        }

        public void Jump()
        {
            
        }

        public void Crouch()
        {
            
        }

        public void GetStar()
        {
            
        }

        public void GetFlower()
        {
            
        }

        public void GetMushroom()
        {
            
        }

        public void TakeDamage()
        {
            
        }

        public void GetCoin()
        {

        }
        public void Walk()
        {
       
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update();
            if (risingDistance <= 60)
            {
                mario.currentLocation.Y -= 3;
                risingDistance += 3;
            }
            else mario.currentLocation.Y += 3;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}