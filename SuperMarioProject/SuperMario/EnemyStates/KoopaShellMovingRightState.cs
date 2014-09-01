using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace SuperMario.EnemyStates
{
    class KoopaShellMovingRightState : IEnemyState
    {
        public IAnimatedSprite Sprite { get; set; }
        IEnemy koopa;

        public KoopaShellMovingRightState(IEnemy koopa)
        {
            Sprite = SpriteFactory.CreateKoompaShell();
            this.koopa = koopa;
        }

        public void ToLeft()
        {
            koopa.CurrentState = new KoopaShellMovingLeftState(koopa);
        }

        public void ToRight()
        {

        }

        public void TakeDamage()
        {
            
        }
        public void GetKilledByStar()
        {
            koopa.CurrentState = new KoopaFlipState(koopa);
        }

        public void Update(GameTime gameTime, Camera camera)
        {
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
