using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public interface IAnimatedSprite
    {
        Texture2D Texture { get; set; }
        int Columns { get; set; }
        int CurrentFrame { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle);
        void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color tint);
        void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, float rotation);
    }
}
