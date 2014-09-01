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

namespace SuperMario.MarioStates
{
    public class MarioConstants
    {
        private static MarioConstants instance;

       private MarioConstants()
       {
       }

       public static MarioConstants Instance
       {
           get
           {
               if (instance == null)
               {
                   instance = new MarioConstants();
               }
               return instance;
           }
       }

       public float SmallMarioDX=9;
       public float SmallMarioRunDX = 6;
       public float BigMarioDX = 2;
       public float BigMarioRunDX = 4;
       public double SmallMarioTimer = 0.05;
       public double SmallMarioTimerRun = 0.02;
       public double BigMarioTimer = 0.02;
       public double BigMarioTimerRun = 0.02;
       public float SmallMarioJump = -25;
       public float SmallMarioFall = 2;
       public float BigMarioJump = -35;
       public float BigMarioFall = 2;
       public double decayFactor = 0.9;
       public float growthFactor = 1.1F;
       public float zeroDisplacementEquivalent = 1;
       public float StarMarioTimer = 10;
       public float StarMarioFlashTimer = 0.02F;
    }
}