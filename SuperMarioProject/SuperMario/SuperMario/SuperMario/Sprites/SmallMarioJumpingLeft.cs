using System;

namespace SuperMario
{
    public class SmallMarioJumpingLeft
    {
        // The way these implementations work is that the constructor gets the Texture2D containing the sprites assuming they are all in consecutive rectangular frames,
        // and the method also takes the rows and columns in the passed sprite atlas.  Also, the user passes the start and end frame "coordinates" of the texture.
        // Sprite coordinates are based on the idea that frames are numbered from 0 to |sprites|-1 starting from the upper left and going across and down.
        // For example if the SmallMarioRunningRight sprites are such that the starting frame is in the upper left corner and there are four rows in the sprite atlas
        // and the animation lasts six frames, then when the SmallMarioRunningRight is constructed you would pass 0 and 5 as the frame coordinates, and on the sprite
        // atlas they would be laid out like:
        // 0 1 2 3
        // 4 5 ...
        // and so on.
        // Apart from that it works exactly like the tutorial.  Even static sprites (like dead Mario or Mario standing still) implement animation logic in case
        // later we decide to create sprites where Mario breathes or something when standing still.  We can just change these "stationary" Mario sprites to
        // have no animation  logic, just a blank Update() and a simple Draw()
        public class SmallMarioJumpingLeft : IAnimatedSprite
        {
            public Texture2D Texture { get; set; }
            public int Rows { get; set; }
            public int Columns { get; set; }
            private int currentFrame;
            private int totalFrames;
            private int initialFrame;

            public IAnimatedSprite SmallMarioJumpingLeft(Texture2D texture, int startFrameCoordinate, int endFrameCoordinate, int rows, int columns, int xRes, int yRes)
            {
                this.Texture = texture;
                this.totalFrames = endFrameCoordinate - startFrameCoordinate; // rows*columns==total number of frames in sprite atlas including empties
                this.Rows = rows;
                this.Columns = columns;
                this.currentFrame = startFrameCoordinate; // treating the first frame in the atlas (upper left) as frame zero
                this.initialFrame = startFrameCoordinate;
            }

            public void Update()
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = initialFrame;
                }
            }

            public void Draw(SpriteBatch spriteBatch, Vector2D location)
            {
                // this method may need optimization later, may need to put the width and height stuff in the constructor and
                // rejigger the sourceRectangle and destinationRectangle math
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
}