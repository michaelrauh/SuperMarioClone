using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using XMLInput;

namespace SuperMario.Levels
{
    public class Level1 : ILevel
    {
        public Mario CurrentMario { get; set; }
        List<IItem> items;
        List<IBlock> blocks;
        List<IEnemy> enemies;
        List<IPipe> pipes;
        Texture2D backgroundTexture;
        IAnimatedSprite background;
        Rectangle backgroundDestination;
        ItemRecord[] itemRecord;
        Microsoft.Xna.Framework.Content.ContentManager Content;
        CollisionManager collisionManager;
        List<IController> controllers;
        
        

        public Level1(Microsoft.Xna.Framework.Content.ContentManager Content, List<IController> controllers)
        {
            this.Content = Content;
            enemies = new List<IEnemy>();
            blocks = new List<IBlock>();
            items = new List<IItem>();
            pipes = new List<IPipe>();
            this.controllers = controllers;
            
        }
        
        public void LoadContent()
        {
            
            backgroundTexture = Content.Load<Texture2D>("MarioBackground");
            backgroundDestination = new Rectangle(0, 0, backgroundTexture.Width, backgroundTexture.Height);
            background = new AnimatedSprite(backgroundTexture, 1, 1, 0, 0);
            CurrentMario = new Mario(new Vector2(0, 0));
            itemRecord = Content.Load<ItemRecord[]>("Level1");

            foreach (ItemRecord gameObject in itemRecord)
            {
                if (gameObject.Type == "Mario")
                {
                    CurrentMario = new Mario(new Vector2(gameObject.xlocation, gameObject.ylocation));
                }
                //else if (gameObject.Type == "QuestionBlock")
                //{
                  //  IBlock block = new Blocks.QuestionBlockWithCoin(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    //blocks.Add(block);
                //}
                else if (gameObject.Type == "QuestionBlock")
                {
                    IItem mushroom = new Items.GetBigMushroom(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    items.Add(mushroom);
                    IItem flower = new Items.Flower(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    items.Add(flower);
                    IBlock block = new Blocks.QuestionBlockWithMushroom(new Vector2(gameObject.xlocation, gameObject.ylocation), mushroom, flower);
                    blocks.Add(block);
                }
                /*else if (gameObject.Type == "BrickBlock")
                {
                    IBlock item = new Blocks.BrickBlock(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    blocks.Add(item);
                }*/
                /*else if (gameObject.Type == "BrickBlock")
                {
                    IBlock item = new Blocks.BrickBlockWithCoins(new Vector2(gameObject.xlocation, gameObject.ylocation), 1);
                    blocks.Add(item);
                }*/
                else if (gameObject.Type == "BrickBlock")
                {
                    IItem star = new Items.Star(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    items.Add(star);
                    IBlock item = new Blocks.BrickBlockWithStar(new Vector2(gameObject.xlocation, gameObject.ylocation), star);
                    blocks.Add(item);
                }
                else if (gameObject.Type == "FloorBlock")
                {
                    IBlock item = new Blocks.FloorBlock(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    blocks.Add(item);
                }
                else if (gameObject.Type == "StairBlock")
                {
                    IBlock item = new Blocks.StairBlock(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    blocks.Add(item);
                }
                else if (gameObject.Type == "HiddenBlock")
                {
                    IItem mushroom = new Items.OneUpMushroom(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    items.Add(mushroom);
                    IBlock block = new Blocks.HiddenBlock(new Vector2(gameObject.xlocation, gameObject.ylocation), mushroom);
                    blocks.Add(block);
                }
                else if (gameObject.Type == "Goomba")
                {
                    IEnemy item = new Enemies.Goomba(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    enemies.Add(item);
                }
                else if (gameObject.Type == "Koopa")
                {
                    IEnemy item = new Enemies.Koopa(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    enemies.Add(item);
                }
                else if (gameObject.Type == "KoopaShell")
                {
                    IEnemy item = new Enemies.Koopa(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    item.CurrentState.TakeDamage();
                    enemies.Add(item);
                }
                else if (gameObject.Type == "Pipe")
                {
                    IPipe item = new Pipes.SmallPipe(new Vector2(gameObject.xlocation, gameObject.ylocation));
                    pipes.Add(item);
                }
                collisionManager = new CollisionManager(CurrentMario, enemies, blocks, items, pipes);
            }
        }

        public void UnloadContent()
        {
            
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime, Camera camera)
        {
            collisionManager.HandleGameCollision();
            foreach (IEnemy enemy in enemies) enemy.Update(gameTime, camera);
            foreach (IBlock block in blocks) block.Update(gameTime);
            foreach (IItem item in items) item.Update(gameTime);
            foreach (IPipe pipe in pipes) pipe.Update();
            CurrentMario.Update(gameTime, camera);
            
            foreach (IController controller in controllers) controller.Update();
        }

        public void Draw(Microsoft.Xna.Framework.GameTime gameTime, SpriteBatch spriteBatch)
        {

            background.Draw(spriteBatch, backgroundDestination);

            foreach (IItem item in items) item.Draw(spriteBatch);
            foreach (IPipe pipe in pipes) pipe.Draw(spriteBatch);
            foreach (IBlock block in blocks) block.Draw(spriteBatch);
            foreach (IEnemy enemy in enemies) enemy.Draw(spriteBatch);
            CurrentMario.Draw(spriteBatch);
        }
    }
}
