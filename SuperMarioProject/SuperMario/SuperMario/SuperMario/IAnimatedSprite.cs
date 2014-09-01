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
        // The way these implementations' constructors should work is that the constructor gets the Texture2D containing the sprites assuming they are all in consecutive rectangular frames,
        // and the method also takes the rows and columns in the passed sprite atlas.  Also, the user passes the start and end frame "coordinates" of the texture.
        // Sprite coordinates are based on the idea that frames are numbered from 0 to |sprites|-1 starting from the upper left and going across and down.
        // For example if the SmallMarioRunningRight sprites are such that the starting frame is in the upper left corner and there are four rows in the sprite atlas
        // and the animation lasts six frames, then when the SmallMarioRunningRight is constructed you would pass 0 and 5 as the frame coordinates, and on the sprite
        // atlas they would be laid out like:
        // 0 1 2 3
        // 4 5 ...
        // and so on.
        // The constructor is also passed the SpriteBatch being used, not Draw()
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
