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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public IAnimatedSprite marioSprite;
        IController keyboard;
        public Texture2D bigLeftMarioTexture, bigRightMarioTexture, smallLeftMarioTexture, smallRightMarioTexture;
        public int counter = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            bigLeftMarioTexture = Content.Load<Texture2D>("BigMarioLeft");
            smallLeftMarioTexture = Content.Load<Texture2D>("SmallMarioLeft");
            bigRightMarioTexture = Content.Load<Texture2D>("BigMarioRight");
            smallRightMarioTexture = Content.Load<Texture2D>("SmallMarioRight");
            marioSprite = SpriteFactory.BigLeftMarioLoad(bigLeftMarioTexture); // default sprite
            //command = new Commands.BigLeftMarioCommand(this);
            keyboard = new KeyboardController(this);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            counter++;
            keyboard.Update();
            if (counter % 5 == 0)
            {
                marioSprite.Update();
            }
            //command.Execute();
            //marioSprite = SpriteFactory.BigLeftMarioLoad(bigLeftMarioTexture);
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            if (marioSprite != null)
                marioSprite.Draw(spriteBatch, new Vector2(400, 200));

            base.Draw(gameTime);
        }
    }
}
