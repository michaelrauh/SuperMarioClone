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

namespace SuperMario
{
    class CollisionDetector
    {
        public static int BUFFER_AREA = 3;
        public CollisionDetector()
        {
        }

        public bool DetectCollision(Rectangle a, Rectangle b)
        {
            return (TopCollision(a, b) || BottomCollision(a, b) || LeftCollision(a, b) || RightCollision(a, b));
        }

        public bool TopCollision(Rectangle a, Rectangle b)
        {
            return (a.Right - BUFFER_AREA > b.Left && a.Left + BUFFER_AREA < b.Right &&
                a.Bottom >= b.Top + BUFFER_AREA && a.Bottom <= b.Bottom);
        }

        public bool BottomCollision(Rectangle a, Rectangle b)
        {
            return (a.Right - BUFFER_AREA > b.Left && a.Left + BUFFER_AREA < b.Right &&
                a.Top <= b.Bottom - BUFFER_AREA && a.Top >= b.Top);
        }

        public bool LeftCollision(Rectangle a, Rectangle b)
        {
            return (a.Bottom - BUFFER_AREA > b.Top && a.Top + BUFFER_AREA < b.Bottom &&
                a.Right >= b.Left + BUFFER_AREA && a.Right <= b.Right);
        }

        public bool RightCollision(Rectangle a, Rectangle b)
        {
            return (a.Bottom - BUFFER_AREA > b.Top && a.Top + BUFFER_AREA < b.Bottom &&
                a.Left <= b.Right - BUFFER_AREA && a.Left >= b.Left);
        }
    }
}
