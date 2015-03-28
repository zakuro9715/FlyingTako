using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace MiniGames.Framework.Input
{
    public class Key : IDigitalInput
    {
        bool b;
        public Keys TargetKey
        {
            get;
            set;
        }        
        public bool IsPressed()
        {
            return b;
        }
        public void Update()
        {
            var k = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            b = k.IsKeyDown(TargetKey);
        }
    }
}
