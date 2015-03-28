using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniGames.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReaniszWorks.Framework.XNA.Graphics;
using Microsoft.Xna.Framework;

namespace FlyingTako
{
    public class GameState : MiniGames.Framework.GameState
    {
        public TimeSpan TimeLimit;
        public TimeSpan MaxTimeLimit;

        public GameState()
        {
        }

        public override void Initialize()
        {
            TimeLimit = new TimeSpan(0, 2, 0);
            MaxTimeLimit = TimeLimit;
            
        }
    }
}
