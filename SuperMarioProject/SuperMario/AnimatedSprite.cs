using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SuperMario.Blocks;
using XMLInput;

namespace SuperMario
{
    class AnimatedSprite : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }
        private int rows;
        public int Columns { get; set; }
        public int CurrentFrame { get; set; }
        private int firstFrame;
        private int lastFrame;
        public int Width { get; set; }
        public int Height { get; set; }
        

        public AnimatedSprite(Texture2D texture, int rows, int columns, int firstFrame, int lastFrame)
        {
            this.Texture = texture;
            Width = texture.Width / columns;
            Height = texture.Height / rows;
            this.rows = rows;
            this.Columns = columns;
            CurrentFrame = firstFrame;
            this.firstFrame = firstFrame;
            this.lastFrame = lastFrame;
            
            
        }

        public void Update()
        {
            CurrentFrame++;
            if (CurrentFrame > lastFrame)
                CurrentFrame = firstFrame;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle)
        {
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, Width, Height);

            if (spriteBatch != null)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }


        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color tint)
        {
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, Width, Height);

            if (spriteBatch != null)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, tint);
                spriteBatch.End();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, float rotation)
        {

            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;
            Vector2 origin = new Vector2(0.0f);
            Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, Width, Height);
            
            if (spriteBatch != null)
            {
                spriteBatch.Begin();

                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, rotation, origin, SpriteEffects.None, 0.0f);
                spriteBatch.End();
            }
        }
    }
}
