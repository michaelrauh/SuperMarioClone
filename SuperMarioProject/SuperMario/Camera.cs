using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SuperMario
{
    public class Camera
    {
        //The viewport we want the camera to use (holds dimensions and so on)
        public Viewport View
        {
            get;
            private set;
        }

        //Where to point the center of the camera (0x0 will be the center of the viewport)
        public Vector2 Position;
 
        //Copy of the old position when we start to shake
        public Vector2 SavedPosition
        {
            get;
            private set;
        }

        //center of focus for the camera
        public Vector2 FocusPoint
        {
            get;
            private set;
        }

        //Our camera's transform matrix
        public Matrix Transform
        {
            get;
            private set;
        }

        //The source object to follow
        public Mario Source
        {
            get;
            private set;
        }

        public Camera(Viewport view, Vector2 position)
        {
            View = view;
            Position = position;
            FocusPoint = new Vector2(0,0);
        }

        public Camera(Viewport view, Vector2 position, Vector2 focus)
        {
            View = view;
            Position = position;
            FocusPoint = focus;
        }

        public void Update(GameTime gametime)
        {


            Vector2 objectPosition = Source != null ? Source.currentLocation : Position;

            Transform = Matrix.CreateTranslation(new Vector3(-objectPosition.X, 0, 0)) *
                Matrix.CreateTranslation(new Vector3(FocusPoint.X, FocusPoint.Y, 0));
            this.Position.X = objectPosition.X;
            this.Position.Y = objectPosition.Y;
        }


        public void Follow(Mario source)
        {
            Source = source;
        }

    }
}
