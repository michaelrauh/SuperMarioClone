using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class Mario
    {
      
        public Vector2 currentLocation;
        public IMarioState CurrentState { get; set; }
        public bool leftBlocked, rightBlocked, topBlocked, bottomBlocked; 
        public Rectangle MarioRectangle { get; set; }
        public Boolean isDead;
        public float marioDX;
        public float marioDY;
        public bool isJumping = false;
        public bool isFalling = false;
        public bool isStanding = true;
       

        
        public Mario(Vector2 location)
        {
            currentLocation = location; // default locations
            CurrentState = new MarioStates.SmallRightMarioState(this); // default state             
            isDead = false;
            MarioRectangle = new Rectangle((int)location.X, (int)location.Y, CurrentState.Sprite.Width, CurrentState.Sprite.Height);
            
        }

        public void Update(GameTime gameTime, Camera camera)
        {
            
            CurrentState.Update(gameTime);
            MarioRectangle = new Rectangle((int)(currentLocation.X), (int)(currentLocation.Y), CurrentState.Sprite.Width, CurrentState.Sprite.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentState.Draw(spriteBatch, MarioRectangle);
        }
    }
}