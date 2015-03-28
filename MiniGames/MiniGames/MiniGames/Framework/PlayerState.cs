using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniGames.Framework
{
    public class PlayerState
    {
        public byte PlayerID
        {
            get;
            set;
        }
        public int Score
        {
            get;
            set;
        }
        public int GetScoreAsPoint()
        {
            return Score;
        }
        public bool IsRemote
        {
            get;
            set;
        }
        public TimeSpan GetScoreAsTime()
        {
            throw new NotImplementedException();
        }
    }
}
