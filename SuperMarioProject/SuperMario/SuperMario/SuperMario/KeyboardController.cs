using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> commands;

        public KeyboardController(Game1 game)
        {
            commands = new Dictionary<Keys, ICommand>();

            //Commands is a directory containing each action state, for now
            commands.Add(Keys.Q, new Commands.SmallLeftMarioCommand(game));
            commands.Add(Keys.W, new Commands.SmallRightMarioCommand(game));
            commands.Add(Keys.E, new Commands.BigLeftMarioCommand(game));
            commands.Add(Keys.R, new Commands.BigRightMarioCommand());
            commands.Add(Keys.T, new Commands.FireLeftMarioCommand());
            commands.Add(Keys.Y, new Commands.FireRightMarioCommand());
            commands.Add(Keys.A, new Commands.SmallLeftJumpingMarioCommand(game));
            commands.Add(Keys.S, new Commands.SmallRightJumpingMarioCommand(game));
            commands.Add(Keys.D, new Commands.BigLeftJumpingMarioCommand());
            commands.Add(Keys.F, new Commands.BigRightJumpingMarioCommand());
            commands.Add(Keys.G, new Commands.FireLeftJumpingMarioCommand());
            commands.Add(Keys.H, new Commands.FireRightJumpingMarioCommand());
            commands.Add(Keys.Z, new Commands.SmallLeftRunningMarioCommand(game));
            commands.Add(Keys.X, new Commands.SmallRightRunningMarioCommand(game));
            commands.Add(Keys.C, new Commands.BigLeftRunningMarioCommand());
            commands.Add(Keys.V, new Commands.BigRightRunningMarioCommand());
            commands.Add(Keys.B, new Commands.FireLeftRunningMarioCommand());
            commands.Add(Keys.N, new Commands.FireRightRunningMarioCommand());
            commands.Add(Keys.D1, new Commands.MarioDeathStateCommand());
            commands.Add(Keys.D2, new Commands.BigLeftCrouchMarioCommand());
            commands.Add(Keys.D3, new Commands.BigRightCrouchMarioCommand());
            commands.Add(Keys.D4, new Commands.FireLeftCrouchMarioCommand());
            commands.Add(Keys.D5, new Commands.FireRightCrouchMarioCommand());
            commands.Add(Keys.P, new Commands.QuestionBlockCommand());
            commands.Add(Keys.O, new Commands.UsedBlockCommand());
            commands.Add(Keys.I, new Commands.BrickBlockCommand());
            commands.Add(Keys.L, new Commands.FloorBlockCommand());
            commands.Add(Keys.K, new Commands.StairBlockCommand());
            commands.Add(Keys.J, new Commands.HiddenBlockCommand());

        }

        public void Update()
        {
            var keyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            Keys[] keys = keyboard.GetPressedKeys();

            foreach (Keys i in keys)
            {
                if (commands.ContainsKey(i))
                {
                    commands[i].Execute();
                }
            }
            
        }
    }
}