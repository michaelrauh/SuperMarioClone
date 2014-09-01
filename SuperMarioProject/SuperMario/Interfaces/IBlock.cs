using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public interface IBlock
    {
        Rectangle DestinationRectangle { get; set; }
        void HitBySmallMario();
        void HitByBigMario();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
