using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.EnemyStates
{
    class GoombaFlipState : IEnemyState
    {
        public IAnimatedSprite Sprite { get; set; }
        IEnemy goomba;
        double goombaTimer;

        public GoombaFlipState(IEnemy goomba)
        {
            Sprite = SpriteFactory.CreateSteadyGoomba();
            this.goomba = goomba;
            goombaTimer = 0.5;
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
            Sprite.Draw(spriteBatch, destinationRectangle, 3.14f);
        }
    }
}
