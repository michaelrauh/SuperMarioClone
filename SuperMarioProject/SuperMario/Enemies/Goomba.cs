using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Enemies
{
    public class Goomba : IEnemy
    {
        public Rectangle DestinationRectangle { get; set; }
        public IEnemyState CurrentState { get; set; }
        public Boolean IsDead { get; set; }
        Vector2 currentLocation;
        double yVelocity;
        public double xVelocity { get; set; }
        
        public Goomba(Vector2 initialLocation)
        {
            currentLocation = initialLocation;
            CurrentState = new EnemyStates.GoombaMovingLeftState(this);
            DestinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, CurrentState.Sprite.Width, CurrentState.Sprite.Height);
            yVelocity = 3;
        }

        public void Update(GameTime gameTime, Camera camera)
        {
            CurrentState.Update(gameTime, camera);
            yVelocity *= 1.05;
           // currentLocation.X += (int)xVelocity;
            currentLocation.Y += (int)yVelocity;
            if (!IsDead) DestinationRectangle = new Rectangle((int)(currentLocation.X - camera.Position.X), (int)(currentLocation.Y), CurrentState.Sprite.Width, CurrentState.Sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentState.Draw(spriteBatch, DestinationRectangle);
        }

        public void BumpUp(int blockSide)
        {
            currentLocation.Y = blockSide - CurrentState.Sprite.Height;
            yVelocity = 3;
        }

        public void BumpDown(int blockSide)
        {
            currentLocation.Y = blockSide;
        }

        public void BumpLeft(int blockSide)
        {
            currentLocation.X = blockSide - CurrentState.Sprite.Width;
            CurrentState.ToLeft();
        }

        public void BumpRight(int blockSide)
        {
            currentLocation.X = blockSide;
            CurrentState.ToRight();
        }

        public void KillEnemy(IMarioState marioState)
        {
            if (marioState is MarioStates.StarMarioState)
                CurrentState.GetKilledByStar();
            else CurrentState.TakeDamage();
        }
    }
}
