﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public interface  IEnemyState
    {
        IAnimatedSprite Sprite { get; set; }
        void ToLeft();
        void ToRight();
        void TakeDamage();
        void GetKilledByStar();
        void Update(GameTime gameTime, Camera camera);
        void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle);
    
    }
}
