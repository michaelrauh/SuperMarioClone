using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public interface ILevel
    {
        Mario CurrentMario { get; set; }
        void LoadContent();
        void UnloadContent();
        void Update(GameTime gameTime, Camera camera);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
