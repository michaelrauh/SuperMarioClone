using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.MarioStates
{
    class StarMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        public IMarioState parent;
        Mario mario;
        static double startimer = MarioConstants.Instance.StarMarioTimer;
        static double flashtimer = MarioConstants.Instance.StarMarioFlashTimer;
        static bool activeTint = true;

        public StarMarioState(Mario mario, IMarioState parent)
        {
            this.mario = mario;
            this.parent = parent;
            Sprite = this.parent.Sprite; // Same base sprite. Need to change color though
        }

        public void Idle()
        {
            this.parent.Idle();
            if (!(mario.CurrentState is StarMarioState))
            {
                mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            }
        }

        public void RunLeft()
        {
            this.parent.RunLeft();
            if (!(mario.CurrentState is StarMarioState))
            {
                mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            }
        }
        public void RunRight()
        {
            this.parent.RunRight();
            if (!(mario.CurrentState is StarMarioState))
            {
                mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            }
        }
        public void ToLeft()
        {
            this.parent.ToLeft();
            if (!(mario.CurrentState is StarMarioState))
            {
                mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            }
        }

        public void ToRight()
        {
            this.parent.ToRight();
            if (!(mario.CurrentState is StarMarioState))
            {
                mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            }
        }

        public void Jump()
        {
            this.parent.Jump();
            if (!(mario.CurrentState is StarMarioState))
            {
                mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            }
        }

        public void Crouch()
        {
            this.parent.Crouch();
            if (!(mario.CurrentState is StarMarioState))
            {
                mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            }
        }

        public void GetStar()
        {
            //already star

        }

        public void GetFlower()
        {
            this.parent.GetFlower();
            if (!(mario.CurrentState is StarMarioState))
            {
                mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            }
        }

        public void GetMushroom()
        {
            this.parent.GetMushroom();
            if (!(mario.CurrentState is StarMarioState))
            {
                mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            }
        }

        public void TakeDamage()
        {
        }

        public void GetCoin()
        {

        }
        public void Walk()
        {
            this.parent.Walk();
            if (!(mario.CurrentState is StarMarioState))
            {
                mario.CurrentState = new StarMarioState(mario, mario.CurrentState);
            }
        }
        public void Update(GameTime gameTime)
        {
            this.parent.Update(gameTime);
            startimer -= gameTime.ElapsedGameTime.TotalSeconds;
            flashtimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (startimer < 0)
            {
                startimer = MarioConstants.Instance.StarMarioTimer;
                mario.CurrentState = this.parent;
            }
            else
            {
                if (flashtimer < 0)
                {
                    flashtimer = MarioConstants.Instance.StarMarioFlashTimer;
                    activeTint = !activeTint;
                    Sprite.Update();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            //logic needs to be put in here to change the color
            if (activeTint) Sprite.Draw(spriteBatch, destinationRectangle, Color.Brown);
            else Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}