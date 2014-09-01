using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace SuperMario.EnemyStates
{
    class GoombaMovingRightState : IEnemyState
    {
        public IAnimatedSprite Sprite { get; set; }
        IEnemy goomba;
        double goombaTimer;

        public GoombaMovingRightState(IEnemy goomba)
        {
            Sprite = SpriteFactory.CreateWalkingGoomba();
            this.goomba = goomba;
            goombaTimer = 0.15;
            goomba.xVelocity = 3;
        }

        public void ToLeft()
        {
            goomba.CurrentState = new GoombaMovingLeftState(goomba);
        }

        public void ToRight()
        {

        }

        public void TakeDamage()
        {
            goomba.CurrentState = new GoombaDeadState(goomba);
            goomba.IsDead = true;
        }
        public void GetKilledByStar()
        {
            goomba.CurrentState = new GoombaFlipState(goomba);
        }
        public void Update(GameTime gameTime, Camera camera)
        {
            goombaTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (goombaTimer < 0)
            {
                Sprite.Update();
                goombaTimer = 0.15;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            Sprite.Draw(spriteBatch, destinationRectangle);
        }
    }
}
