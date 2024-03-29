﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    class BigLeftMarioSprite : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int firstFrame;
        private int lastFrame;

        public BigLeftMarioSprite(Texture2D texture, int rows, int columns, int firstFrame, int lastFrame)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = firstFrame;
            this.firstFrame = firstFrame;
            this.lastFrame = lastFrame;
        }
 
        public void Update()
        {
            currentFrame++;
            if (currentFrame == lastFrame)
                currentFrame = firstFrame;
        }
 
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
 
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
 
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

    }
}
