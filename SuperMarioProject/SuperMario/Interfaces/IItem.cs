using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public interface IItem
    {
        Rectangle DestinationRectangle { get; set; }
        void Activate();
        void HitByMario();
        void ChangeDirection();
        void BumpUp(int blockSide);
        void BumpDown(int blockSide);
        void BumpLeft(int blockSide);
        void BumpRight(int blockSide);
        void JumpFromGround();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
