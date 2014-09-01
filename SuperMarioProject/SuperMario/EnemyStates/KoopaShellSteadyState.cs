using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.EnemyStates
{
    class KoopaShellSteadyState : IEnemyState
    {
        public IAnimatedSprite Sprite { get; set; }
        IEnemy koopa;
        double getLegsTimer;

        public KoopaShellSteadyState(IEnemy koopa)
        {
            Sprite = SpriteFactory.CreateKoompaShell();
            this.koopa = koopa;
            getLegsTimer = 3;
        }

        public void ToLeft()
        {
            
        }

        public void ToRight()
        {

        }

        public void TakeDamage()
        {
            koopa.CurrentState = new KoopaShellMovingLeftState(koopa);
        }
        public void GetKilledByStar()
        {
            koopa.CurrentState = new KoopaFlipState(koopa);
        }
        public void Update(GameTime gameTime, Camera camera)
        {
            getLegsTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (getLegsTimer < 0) koopa.CurrentState = new KoopaShellWithLegState(koopa);
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
