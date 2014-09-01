using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.EnemyStates
{
    class KoopaShellWithLegState : IEnemyState
    {
        public IAnimatedSprite Sprite { get; set; }
        IEnemy koopa;
        double backToMovingKoopaTimer;
        double flashingLegTimer;
        Boolean hasLeg;

        public KoopaShellWithLegState(IEnemy koopa)
        {
            Sprite = SpriteFactory.CreateKoompaShellWithLegs();
            this.koopa = koopa;
            backToMovingKoopaTimer = 3;
            flashingLegTimer = 0.1;
            hasLeg = true;
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
            backToMovingKoopaTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            flashingLegTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (backToMovingKoopaTimer < 0) koopa.CurrentState = new KoopaMovingLeftState(koopa);
            if (flashingLegTimer < 0)
            {
                if (hasLeg)
                {
                    Sprite = SpriteFactory.CreateKoompaShell();
                    hasLeg = false;
                }
                else
                {
                    Sprite = SpriteFactory.CreateKoompaShellWithLegs();
                    hasLeg = true;
                }
                flashingLegTimer = 0.1;
            }
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
