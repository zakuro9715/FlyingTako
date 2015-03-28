using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniGames.Framework.Input
{
    public class VirtualButton : IDigitalInput
    {
        bool press = false;
        public bool IsPressed()
        {
            return press;
        }

        public void Update()
        {
            press = false;
        }

        public void Press()
        {
            press = true;
        }
    }
}
