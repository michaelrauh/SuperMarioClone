using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace SuperMario
{
    public class GamePadController : IController
    {
         private Dictionary<Buttons, ICommand> commands;

        public GamePadController(Mario mario)
        {
           commands = new Dictionary<Buttons, ICommand>();
           commands.Add(Buttons.LeftThumbstickLeft, new Commands.WalkLeftCommand(mario));
           commands.Add(Buttons.LeftThumbstickDown, new Commands.CrouchingCommand(mario));
           commands.Add(Buttons.LeftThumbstickRight, new Commands.WalkRightCommand(mario));
           commands.Add(Buttons.A, new Commands.JumpingCommand(mario));
           commands.Add(Buttons.B, new Commands.CrouchingCommand(mario));
           commands.Add(Buttons.Y, new Commands.IdleCommand(mario)); 
        }
        public void Update()
        {
            GamePadState currentState = GamePad.GetState(PlayerIndex.One);

            if (currentState.ThumbSticks.Left.X == -1.0f)
            {
                commands[Buttons.LeftThumbstickLeft].Execute();
            }
            if (currentState.ThumbSticks.Left.Y == -1.0f)
            {
                commands[Buttons.LeftThumbstickDown].Execute();
            }
            if (currentState.ThumbSticks.Left.X == 1.0f)
            {
                commands[Buttons.LeftThumbstickRight].Execute();
            }
            if (currentState.Buttons.A == ButtonState.Pressed)
            {
                commands[Buttons.A].Execute();
            }
            if (currentState.Buttons.B == ButtonState.Pressed)
            {
                commands[Buttons.B].Execute();
            }
            
        }
    }
}
