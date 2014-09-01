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

        public KeyboardController(Mario mario)
        {
            commands = new Dictionary<Keys, ICommand>();
            commands.Add(Keys.Down, new Commands.CrouchingCommand(mario));
            commands.Add(Keys.Z, new Commands.JumpingCommand(mario));
           // commands.Add(Keys.X, new Commands.RunRightCommand(mario));
            commands.Add(Keys.Left, new Commands.WalkLeftCommand(mario));
            commands.Add(Keys.Right, new Commands.WalkRightCommand(mario));
            commands.Add(Keys.I, new Commands.IdleCommand(mario));
            commands.Add(Keys.Y, new Commands.RunRightCommand(mario));
            commands.Add(Keys.U, new Commands.RunLeftCommand(mario));
            
        }

        public void Update()
        {
            var keyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            var keys = keyboard.GetPressedKeys().ToList();

            if (keys.Count() == 0 || (keys.Count() == 1 && keys.Contains(Keys.X)))
            {
                commands[Keys.I].Execute();
            }
            else
            {
                if (keys.Contains(Keys.X))
                {
                    keys.Remove(Keys.X);
                    if (keys.Contains(Keys.Left))
                    {
                        keys.Remove(Keys.Left);
                        commands[Keys.U].Execute();

                    }
                    if (keys.Contains(Keys.Right))
                    {
                        keys.Remove(Keys.Right);
                        commands[Keys.Y].Execute();

                    }
                }
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
}