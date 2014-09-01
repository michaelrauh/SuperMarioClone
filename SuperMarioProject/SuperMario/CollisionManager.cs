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

namespace SuperMario
{
    public class CollisionManager
    {
        Mario mario;
        List<IEnemy> enemies;
        List<IBlock> blocks;
        List<IItem> items;
        List<IPipe> pipes;
        CollisionDetector collision;
        int bumpOutDistance;
        
        public CollisionManager(Mario mario, List<IEnemy> _enemies, List<IBlock> _blocks, List<IItem> _items, List<IPipe> _pipes)
        {
            this.mario = mario;
            enemies = _enemies;
            blocks = _blocks;
            items = _items;
            pipes = _pipes;
            collision = new CollisionDetector();
            bumpOutDistance = 1;
        }

        public void HandleGameCollision()
        {
            HandleMarioBlockCollision();
            HandleMarioEnemyCollision();
            HandleMarioItemCollision();
            HandleMarioPipeCollision();
            HandleItemBlockCollision();
            HandleItemPipeCollision();
            HandleEnemyBlockCollision();
            HandleEnemyPipeCollision();
        }

        void HandleMarioEnemyCollision()
        {
            bumpOutDistance = 5;
            foreach (IEnemy enemy in enemies)
            {
                var enemyRectangle = enemy.DestinationRectangle;

                if (!enemy.IsDead)
                {
                    if((collision.DetectCollision(mario.MarioRectangle, enemy.DestinationRectangle) 
                        && mario.CurrentState is MarioStates.StarMarioState))
                    {
                        enemy.CurrentState.GetKilledByStar();
                    }
                    else if (collision.TopCollision(this.mario.MarioRectangle, enemyRectangle))
                    {
                        enemy.CurrentState.TakeDamage();
                        this.mario.currentLocation.Y -= bumpOutDistance;
                    }
                    else if (collision.BottomCollision(this.mario.MarioRectangle, enemyRectangle))
                    {
                        this.mario.CurrentState.TakeDamage();
                        mario.currentLocation.Y += bumpOutDistance;
                    }
                    else if (collision.LeftCollision(this.mario.MarioRectangle, enemyRectangle))
                    {
                        this.mario.CurrentState.TakeDamage();
                        this.mario.currentLocation.X -= bumpOutDistance;
                    }
                    else if (collision.RightCollision(this.mario.MarioRectangle, enemyRectangle))
                    {
                        this.mario.CurrentState.TakeDamage();
                        this.mario.currentLocation.X += bumpOutDistance;
                    }
                }
            }
        }

        void HandleMarioItemCollision()
        {
            foreach (IItem item in items)
            {
                var itemRectangle = item.DestinationRectangle;

                if (collision.DetectCollision(this.mario.MarioRectangle, itemRectangle))
                {
                    if (item is Items.Flower)
                    {
                        this.mario.CurrentState.GetFlower();
                        item.HitByMario();
                    }
                    else if (item is Items.Star)
                    {
                        this.mario.CurrentState.GetStar();
                        item.HitByMario();
                    }
                    else if (item is Items.GetBigMushroom)
                    {
                        this.mario.CurrentState.GetMushroom();
                        item.HitByMario();
                    }
                    else
                    {
                        this.mario.CurrentState.GetCoin();
                        item.HitByMario();
                    }
                }
            }
        }

        void HandleMarioBlockCollision()
        {
            bumpOutDistance = 1;
            foreach (IBlock block in blocks)
            {
                var blockRectangle = block.DestinationRectangle;

                if (collision.BottomCollision(this.mario.MarioRectangle, blockRectangle))
                {
                    mario.currentLocation.Y += bumpOutDistance;
                    if (mario.CurrentState is MarioStates.SmallLeftJumpingMarioState ||
                        mario.CurrentState is MarioStates.SmallRightJumpingMarioState)
                        block.HitBySmallMario();
                    else if (mario.CurrentState is MarioStates.BigLeftJumpingMarioState ||
                        mario.CurrentState is MarioStates.BigRightJumpingMarioState ||
                        mario.CurrentState is MarioStates.FireLeftJumpingMarioState ||
                        mario.CurrentState is MarioStates.FireRightJumpingMarioState)
                        block.HitByBigMario();
                }
                if (collision.LeftCollision(this.mario.MarioRectangle, blockRectangle))
                {
                    //bumpOutDistance = mario.MarioRectangle.Right - blockRectangle.Left + CollisionDetector.BUFFER_AREA;
                    mario.currentLocation.X -= bumpOutDistance;
                }

                if (collision.RightCollision(this.mario.MarioRectangle, blockRectangle))
                {
                    //bumpOutDistance = blockRectangle.Right - mario.MarioRectangle.Left - CollisionDetector.BUFFER_AREA;
                    mario.currentLocation.X += bumpOutDistance;
                }

                if (collision.TopCollision(this.mario.MarioRectangle, blockRectangle))
                {
                    //bumpOutDistance = mario.MarioRectangle.Bottom - blockRectangle.Top + CollisionDetector.BUFFER_AREA;
                    mario.currentLocation.Y -= bumpOutDistance;
                }
                
            }
        }

        void HandleMarioPipeCollision()
        {
            bumpOutDistance = 1;
            foreach (IPipe pipe in pipes)
            {
                var pipeRectangle = pipe.DestinationRectangle;

                if (collision.BottomCollision(this.mario.MarioRectangle, pipeRectangle))
                {
                    
                    mario.currentLocation.Y += bumpOutDistance;
                }

                if (collision.LeftCollision(this.mario.MarioRectangle, pipeRectangle))
                {
                    mario.currentLocation.X -= bumpOutDistance;
                }

                if (collision.RightCollision(this.mario.MarioRectangle, pipeRectangle))
                {
                    mario.currentLocation.X += bumpOutDistance;
                }

                if (collision.TopCollision(this.mario.MarioRectangle, pipeRectangle))
                {
                    mario.currentLocation.Y -= bumpOutDistance;
                }
            }
        }

        void HandleItemBlockCollision()
        {
            foreach (IItem item in items)
            {
                foreach (IBlock block in blocks)
                {
                    if (collision.TopCollision(item.DestinationRectangle, block.DestinationRectangle))
                    {
                        item.BumpUp(block.DestinationRectangle.Top);
                        if (block is FloorBlock) item.JumpFromGround();
                    }
                    else if (collision.LeftCollision(item.DestinationRectangle, block.DestinationRectangle))
                    {
                        item.ChangeDirection();
                        item.BumpLeft(block.DestinationRectangle.Left);
                    }
                    else if (collision.RightCollision(item.DestinationRectangle, block.DestinationRectangle))
                    {
                        item.ChangeDirection();
                        item.BumpRight(block.DestinationRectangle.Right);
                    }
                    else if (collision.BottomCollision(item.DestinationRectangle, block.DestinationRectangle))
                        item.BumpDown(block.DestinationRectangle.Bottom);
                }
                
            }
        }

        void HandleItemPipeCollision()
        {
            foreach (IItem item in items)
            {
                foreach (IPipe pipe in pipes)
                {
                    if (collision.TopCollision(item.DestinationRectangle, pipe.DestinationRectangle))
                    {
                        item.BumpUp(pipe.DestinationRectangle.Top);
                        item.JumpFromGround();
                    }
                    else if (collision.LeftCollision(item.DestinationRectangle, pipe.DestinationRectangle))
                    {
                        item.ChangeDirection();
                        item.BumpLeft(pipe.DestinationRectangle.Left);
                    }
                    else if (collision.RightCollision(item.DestinationRectangle, pipe.DestinationRectangle))
                    {
                        item.ChangeDirection();
                        item.BumpRight(pipe.DestinationRectangle.Right);
                    }
                    else if (collision.BottomCollision(item.DestinationRectangle, pipe.DestinationRectangle))
                        item.BumpDown(pipe.DestinationRectangle.Bottom);
                }
                
            }
            
        }

        void HandleEnemyBlockCollision()
        {
            foreach (IEnemy enemy in enemies)
            {
                foreach (IBlock block in blocks)
                {
                    if (collision.TopCollision(enemy.DestinationRectangle, block.DestinationRectangle))
                    {
                        enemy.BumpUp(block.DestinationRectangle.Top);
                    }
                    else if (collision.LeftCollision(enemy.DestinationRectangle, block.DestinationRectangle))
                    {
                        enemy.BumpLeft(block.DestinationRectangle.Left);
                    }
                    else if (collision.RightCollision(enemy.DestinationRectangle, block.DestinationRectangle))
                    {
                        enemy.BumpRight(block.DestinationRectangle.Right);
                    }
                    else if (collision.BottomCollision(enemy.DestinationRectangle, block.DestinationRectangle))
                        enemy.BumpDown(block.DestinationRectangle.Bottom);
                }

            }
        }

        void HandleEnemyPipeCollision()
        {
            foreach (IEnemy enemy in enemies)
            {
                foreach (IPipe pipe in pipes)
                {
                    if (collision.TopCollision(enemy.DestinationRectangle, pipe.DestinationRectangle))
                    {
                        enemy.BumpUp(pipe.DestinationRectangle.Top);
                    }
                    else if (collision.LeftCollision(enemy.DestinationRectangle, pipe.DestinationRectangle))
                    {
                        enemy.BumpLeft(pipe.DestinationRectangle.Left);
                    }
                    else if (collision.RightCollision(enemy.DestinationRectangle, pipe.DestinationRectangle))
                    {
                        enemy.BumpRight(pipe.DestinationRectangle.Right);
                    }
                    else if (collision.BottomCollision(enemy.DestinationRectangle, pipe.DestinationRectangle))
                        enemy.BumpDown(pipe.DestinationRectangle.Bottom);
                }

            }
        }
    }
}
