using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniGames.Framework
{
    public abstract class GameState
    {
        public enum EnumState { Ready, Running, Waiting }
        public EnumState State
        {
            get;
            set;
        }
        public Random Random
        {
            get;
            private set;
        }

        /// <summary>
        /// 難易度(0～255の256段階)
        /// </summary>
        public byte Difficulity
        {
            get;
            set;
        }
        

        public GameState()
        {
            Difficulity = 128;
        }

        public abstract void Initialize();

        public void InitializeRandom(int seed)
        {
            Random = new Random(seed);
        }
    }
}
