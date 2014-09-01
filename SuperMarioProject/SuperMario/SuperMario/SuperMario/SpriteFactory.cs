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
    // This should be treated as a singleton
   public class SpriteFactory
    {
       private static SpriteFactory instance;

       // Global functionality will go here. Obviously, information will be passed in
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

       //Helper for each specific sprite
       public static IAnimatedSprite BigLeftMarioLoad(Texture2D texture)
       {
           int rows = 1;
           int columns = 7;
           int firstFrame = 0;
           int lastFrame = 0;

           IAnimatedSprite mySprite = new BigLeftMarioSprite(texture, rows, columns, firstFrame, lastFrame);
           return mySprite;

       }

       public static IAnimatedSprite SmallRightRunningMarioLoad(Texture2D texture)
       {
           IAnimatedSprite mySprite = new SmallMarioRunningRightSprite(texture,0,4,1,6);
           return mySprite;
       }

       public static IAnimatedSprite SmallRightJumpingMarioLoad(Texture2D texture)
       {
           IAnimatedSprite mySprite = new SmallMarioJumpingRightSprite(texture, 0, 4, 1, 6);
           return mySprite;
       }

       public static IAnimatedSprite SmallRightMarioLoad(Texture2D texture)
       {
           IAnimatedSprite mySprite = new SmallMarioRightSprite(texture, 0, 4, 1, 6);
           return mySprite;
       }

       public static IAnimatedSprite SmallLeftRunningMarioLoad(Texture2D texture)
       {
           IAnimatedSprite mySprite = new SmallMarioRunningLeftSprite(texture, 0, 4, 1, 6);
           return mySprite;
       }

       public static IAnimatedSprite SmallLeftJumpingMarioLoad(Texture2D texture)
       {
           IAnimatedSprite mySprite = new SmallMarioJumpingLeftSprite(texture, 0, 4, 1, 6);
           return mySprite;
       }

       public static IAnimatedSprite SmallLeftMarioLoad(Texture2D texture)
       {
           IAnimatedSprite mySprite = new SmallMarioLeftSprite(texture, 0, 4, 1, 6);
           return mySprite;
       }

       public static IAnimatedSprite SmallMarioDeadLoad(Texture2D texture)
       {
           IAnimatedSprite mySprite = new SmallMarioDeadSprite(texture, 0, 4, 1, 6);
           return mySprite;
       }


    }
}
