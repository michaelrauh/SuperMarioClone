using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.EnemyStates
{
    class GoombaDeadState : IEnemyState
    {
        public IAnimatedSprite Sprite { get; set; }
        IEnemy goomba;
        double goombaTimer;

        public GoombaDeadState(IEnemy goomba)
        {
            Sprite = SpriteFactory.CreateDeadGoomba();
            this.goomba = goomba;
            goombaTimer = 0.3;
            goomba.xVelocity = 0;
        }

        public void ToLeft()
        {
            
        }

        public void ToRight()
        {

        }

        public void TakeDamage()
        {
            
        }
        public void GetKilledByStar()
        {

        }

        public void Update(GameTime gameTime, Camera camera)
        {
            goombaTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (goombaTimer < 0)
            {
                goomba.DestinationRectangle = new Rectangle();
            }
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
