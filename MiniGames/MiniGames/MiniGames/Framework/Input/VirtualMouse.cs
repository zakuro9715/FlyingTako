using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniGames.Framework.Input
{
    public class VirtualMouse : Mouse
    {
        public VirtualButton VirtualLeftButton = new VirtualButton();
        public VirtualButton VirtualRightButton = new VirtualButton();

        public VirtualMouse()
        {
            PreviousState = State;
            State = Microsoft.Xna.Framework.Input.Mouse.GetState();
            LeftButton = new Button(VirtualLeftButton);
            RightButton = new Button(VirtualRightButton);
        }
    }
}
