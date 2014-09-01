using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.EnemyStates
{
    class KoopaFlipState : IEnemyState
    {
        public IAnimatedSprite Sprite { get; set; }
        IEnemy koopa;
        double koopaTimer;

        public KoopaFlipState(IEnemy koopa)
        {
            Sprite = SpriteFactory.CreateKoompaShell();
            this.koopa= koopa;
            koopaTimer = 0.5;
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
           
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle, 3.14f);
        }
    }
}
