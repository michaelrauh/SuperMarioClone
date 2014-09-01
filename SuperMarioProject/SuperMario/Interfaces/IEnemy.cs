using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public interface IEnemy
    {
        Rectangle DestinationRectangle { get; set; }
        IEnemyState CurrentState { get; set; }
        Boolean IsDead { get; set; }
        double xVelocity { get; set; }
        void KillEnemy(IMarioState marioState);
        void BumpUp(int blockSide);
        void BumpDown(int blockSide);
        void BumpLeft(int blockSide);
        void BumpRight(int blockSide);
        void Update(GameTime gameTime, Camera camera);
        void Draw(SpriteBatch spriteBatch);
    }
}
