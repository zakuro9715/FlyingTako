using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace MiniGames.Framework.Input
{
    public class Keybord
    {
        static public KeyboardState KeyboardState
        {
            get;
            set;
        }
        static public void Update()
        {
            KeyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }
        static public bool IsKeyDown(Keys key)
        {
            return KeyboardState.IsKeyDown(key);
        }
        static public bool IsKeyUp(Keys key)
        {
            return KeyboardState.IsKeyUp(key);
        }
    }
}
