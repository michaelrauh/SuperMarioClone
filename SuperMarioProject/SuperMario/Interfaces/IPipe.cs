using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public interface IPipe
    {
        Rectangle DestinationRectangle { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
