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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        SpriteBatch spriteBatch;
        ILevel level;
        List<IController> controllers;
        Camera camera;
        static int ScreenHeight = 500;
        static int ScreenWidth = 800;
        Rectangle screenRectangle;
        GraphicsDeviceManager graphics;

        public Game1()
        {
            screenRectangle = new Rectangle(0, 0, ScreenWidth, ScreenHeight);
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 500;
            Content.RootDirectory = "Content";
            controllers = new List<IController>();
            level = new Levels.Level1(Content, controllers);
            var temp = new Vector2(0,0);  
        }

        protected override void Initialize()
        {
            base.Initialize();
            camera = new Camera(graphics.GraphicsDevice.Viewport, Vector2.Zero); 
            
            IController controller = new KeyboardController(level.CurrentMario);
            controllers.Add(controller);
            controller = new GamePadController(level.CurrentMario);
            controllers.Add(controller);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.Instance.LoadTextures(this);
            level.LoadContent();
            
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            camera.Update(gameTime);
            level.Update(gameTime, camera);
            Vector2 movement = Vector2.Zero;
            camera.Follow(level.CurrentMario);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            level.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
    }
}
