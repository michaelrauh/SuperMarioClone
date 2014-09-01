using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SuperMario
{
   sealed class SpriteFactory
    {
       private static Texture2D BigLeftMarioTexture;
       private static Texture2D BigRightMarioTexture;
       private static Texture2D SmallLeftMarioTexture;
       private static Texture2D SmallRightMarioTexture;
       private static Texture2D FireLeftMarioTexture;
       private static Texture2D FireRightMarioTexture;
       private static Texture2D DeadMarioTexture;
       private static Texture2D BlockTexture;
       private static Texture2D GoombaTexture;
       private static Texture2D KoopaTexture;
       private static Texture2D CoinTexture;
       private static Texture2D FlowerTexture;
       private static Texture2D StarTexture;
       private static Texture2D ShroomTexture;
       private static Texture2D SmallPipeTexture;
       private static Texture2D MediumPipeTexture;
       private static Texture2D BigPipeTexture;

       private static SpriteFactory instance;

       private SpriteFactory()
       {
       }

       public static SpriteFactory Instance
       {
           get
           {
               if (instance == null)
               {
                   instance = new SpriteFactory();
               }
               return instance;
           }
       }

       public void LoadTextures(Game1 game)
       {
           /* Content is a property not a type, so to access Content in this method we must pass in Game1 */
           BigLeftMarioTexture = game.Content.Load<Texture2D>("BigMarioLeft");
           BigRightMarioTexture = game.Content.Load<Texture2D>("BigMarioRight");
           SmallLeftMarioTexture = game.Content.Load<Texture2D>("SmallMarioLeft");
           SmallRightMarioTexture = game.Content.Load<Texture2D>("SmallMarioRight");
           FireLeftMarioTexture = game.Content.Load<Texture2D>("FireMarioLeft");
           FireRightMarioTexture = game.Content.Load<Texture2D>("FireMarioRight");
           DeadMarioTexture = game.Content.Load<Texture2D>("DeadMario");
           BlockTexture = game.Content.Load<Texture2D>("Blocks");
           GoombaTexture = game.Content.Load<Texture2D>("Goomba");
           KoopaTexture = game.Content.Load<Texture2D>("KoopaAndShell");
           CoinTexture = game.Content.Load<Texture2D>("Coin");
           FlowerTexture = game.Content.Load<Texture2D>("Flower");
           StarTexture = game.Content.Load<Texture2D>("Star");
           ShroomTexture = game.Content.Load<Texture2D>("Shrooms");
           SmallPipeTexture = game.Content.Load<Texture2D>("SmallPipe");
           MediumPipeTexture = game.Content.Load<Texture2D>("MediumPipe");
           BigPipeTexture = game.Content.Load<Texture2D>("BigPipe");
       }

       //Helper for each specific sprite
       public static IAnimatedSprite CreateBigLeftMario()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(BigLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateBigLeftRunningMario()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(BigLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateBigLeftWalkingMario()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(BigLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateBigLeftJumpingMario()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 5;
           int lastFrame = 5;

           return new AnimatedSprite(BigLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateBigLeftCrouchMario()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 6;
           int lastFrame = 6;

           return new AnimatedSprite(BigLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateBigRightMario()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(BigRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateBigRightRunningMario()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(BigRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateBigRightWalkingMario()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(BigRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateBigRightJumpingMario()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 5;
           int lastFrame = 5;

           return new AnimatedSprite(BigRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateBigRightCrouchMario()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 6;
           int lastFrame = 6;

           return new AnimatedSprite(BigRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateSmallLeftMario()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(SmallLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateSmallLeftRunningMario()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(SmallLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateSmallLeftWalkingMario()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(SmallLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateSmallLeftJumpingMario()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 5;
           int lastFrame = 5;

           return new AnimatedSprite(SmallLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateSmallRightMario()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(SmallRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateSmallRightRunningMario()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(SmallRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateSmallRightWalkingMario()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(SmallRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateSmallRightJumpingMario()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 5;
           int lastFrame = 5;

           return new AnimatedSprite(SmallRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateFireLeftMario()
       {
           int rows = 1;
           int columns = 8;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(FireLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateFireLeftRunningMario()
       {
           int rows = 1;
           int columns = 8;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(FireLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateFireLeftWalkingMario()
       {
           int rows = 1;
           int columns = 8;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(FireLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateFireLeftJumpingMario()
       {
           int rows = 1;
           int columns = 8;
           int firstFrame = 6;
           int lastFrame = 6;

           return new AnimatedSprite(FireLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateFireLeftCrouchMario()
       {
           int rows = 1;
           int columns = 8;
           int firstFrame = 7;
           int lastFrame = 7;

           return new AnimatedSprite(FireLeftMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateFireRightMario()
       {
           int rows = 1;
           int columns = 8;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(FireRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateFireRightRunningMario()
       {
           int rows = 1;
           int columns = 8;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(FireRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateFireRightWalkingMario()
       {
           int rows = 1;
           int columns = 8;
           int firstFrame = 1;
           int lastFrame = 3;

           return new AnimatedSprite(FireRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateFireRightJumpingMario()
       {
           int rows = 1;
           int columns = 8;
           int firstFrame = 6;
           int lastFrame = 6;

           return new AnimatedSprite(FireRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateFireRightCrouchMario()
       {
           int rows = 1;
           int columns = 8;
           int firstFrame = 7;
           int lastFrame = 7;

           return new AnimatedSprite(FireRightMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       

       public static IAnimatedSprite CreateDeadMario()
       {
           int rows = 1;
           int columns = 1;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(DeadMarioTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateBrickBlock()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(BlockTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateUsedBlock()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 1;
           int lastFrame = 1;

           return new AnimatedSprite(BlockTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateFloorBlock()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 2;
           int lastFrame = 2;

           return new AnimatedSprite(BlockTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateStairBlock()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 3;
           int lastFrame = 3;

           return new AnimatedSprite(BlockTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateQuestionBlock()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 4;
           int lastFrame = 5;

           return new AnimatedSprite(BlockTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateHiddenBlock()
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 6;
           int lastFrame = 6;

           return new AnimatedSprite(BlockTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateWalkingGoomba()
       {
           int rows = 1;
           int columns = 3;
           int firstFrame = 0;
           int lastFrame = 1;

           return new AnimatedSprite(GoombaTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateDeadGoomba()
       {
           int rows = 1;
           int columns = 3;
           int firstFrame = 2;
           int lastFrame = 2;

           return new AnimatedSprite(GoombaTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateMovingLeftKoompa()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 0;
           int lastFrame = 1;

           return new AnimatedSprite(KoopaTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateMovingRightKoompa()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 2;
           int lastFrame = 3;

           return new AnimatedSprite(KoopaTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateKoompaShellWithLegs()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 4;
           int lastFrame = 4;

           return new AnimatedSprite(KoopaTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateKoompaShell()
       {
           int rows = 1;
           int columns = 6;
           int firstFrame = 5;
           int lastFrame = 5;

           return new AnimatedSprite(KoopaTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateCoin()
       {
           int rows = 1;
           int columns = 4;
           int firstFrame = 0;
           int lastFrame = 3;

           return new AnimatedSprite(CoinTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateGetBigMushroom()
       {
           int rows = 1;
           int columns = 2;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(ShroomTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateOneUpMushroom()
       {
           int rows = 1;
           int columns = 2;
           int firstFrame = 1;
           int lastFrame = 1;

           return new AnimatedSprite(ShroomTexture, rows, columns, firstFrame, lastFrame);
       }
       public static IAnimatedSprite CreateFireFlower()
       {
           int rows = 1;
           int columns = 4;
           int firstFrame = 0;
           int lastFrame = 3;

           return new AnimatedSprite(FlowerTexture, rows, columns, firstFrame, lastFrame);
       
       }
       public static IAnimatedSprite CreateStar()
       {
           int rows = 1;
           int columns = 4;
           int firstFrame = 0;
           int lastFrame = 3;

           return new AnimatedSprite(StarTexture, rows, columns, firstFrame, lastFrame);


       
       }
       public static IAnimatedSprite CreateSmallPipe()
       {
           int rows = 1;
           int columns = 1;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(SmallPipeTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateMediumPipe()
       {
           int rows = 1;
           int columns = 1;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(MediumPipeTexture, rows, columns, firstFrame, lastFrame);
       }

       public static IAnimatedSprite CreateBigPipe()
       {
           int rows = 1;
           int columns = 1;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(BigPipeTexture, rows, columns, firstFrame, lastFrame);
       }
       public static IAnimatedSprite CreateSteadyGoomba()
       {
           int rows = 1;
           int columns = 3;
           int firstFrame = 0;
           int lastFrame = 0;

           return new AnimatedSprite(GoombaTexture, rows, columns, firstFrame, lastFrame);

       }
   
   }
}
