using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniGames.Framework.Input
{
    public interface IDigitalInput
    {
        bool IsPressed();
        void Update();
    }
}
