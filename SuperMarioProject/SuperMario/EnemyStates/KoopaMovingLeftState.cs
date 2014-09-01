using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace SuperMario.EnemyStates
{
    class KoopaMovingLeftState : IEnemyState
    {
        public IAnimatedSprite Sprite { get; set; }
        IEnemy koopa;
        double koopaTimer;

        public KoopaMovingLeftState(IEnemy koopa)
        {
            Sprite = SpriteFactory.CreateMovingLeftKoompa();
            this.koopa = koopa;
            koopaTimer = 0.2;
        }

        public void ToLeft()
        {
            
        }

        public void ToRight()
        {
            koopa.CurrentState = new KoopaMovingRightState(koopa);
        }

        public void TakeDamage()
        {
            koopa.CurrentState = new KoopaShellSteadyState(koopa);
        }
        public void GetKilledByStar()
        {
            koopa.CurrentState = new KoopaFlipState(koopa);
        }

        public void Update(GameTime gameTime, Camera camera)
        {
            koopaTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (koopaTimer < 0)
            {
                Sprite.Update();
                koopaTimer = 0.2;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
