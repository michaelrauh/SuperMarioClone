using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SuperMario
{
    public class GamepadController : IController
    {
        private Dictionary<string, ICommand> commands;

        public GamepadController(IAnimatedSprite sprite, Game game)
        {
            commands = new Dictionary<string, ICommand>();
        }

        public void Update()
        {
           var state = GamePad.GetState(PlayerIndex.One);
           var buttons = state.Buttons;
        }
    }
}
