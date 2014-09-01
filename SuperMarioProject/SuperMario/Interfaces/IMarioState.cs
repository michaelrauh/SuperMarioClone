using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace SuperMario
{
    public interface IMarioState
    {

        IAnimatedSprite Sprite { get; set; }
        void ToLeft();
        void ToRight();
        void Jump();
        void Crouch();
        void GetStar();
        void GetFlower();
        void GetMushroom();
        void GetCoin();
        void TakeDamage();
        void Update(GameTime gameTime);
        void RunRight();
        void RunLeft();
        void Idle();
        void Walk();
        void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle);
    }
}
