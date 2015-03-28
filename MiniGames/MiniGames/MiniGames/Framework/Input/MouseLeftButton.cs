using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace MiniGames.Framework.Input
{
    public class MouseRightButton : IDigitalInput
    {
        bool b;
        public bool IsPressed()
        {
            return b;
        }

        public void Update()
        {
            b =  Mouse.GetInstance().GetState().RightButton == ButtonState.Pressed;
        }
    }
}