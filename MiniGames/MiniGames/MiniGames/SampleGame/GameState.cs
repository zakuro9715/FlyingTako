using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniGames.SampleGame
{
    class GameState : MiniGames.Framework.GameState
    {
        readonly string[] Text = new string[]{
            "Tweet1",
            "Tweet2",
            "Tweet3",
            "Tweet4",
            "Tweet5",
            "Tweet6",
            "Tweet7",
            "Tweet8",
            "Tweet9",
            "Tweet10",
            "ふぁぼれよ",
            "#ふぁぼれよ",
        };

        public string[] Stream;
        public GameState()
        {
        }

        public void SetText()
        {
            const int stream_max = 256;
            Stream = new string[stream_max];
            for (int i = 0; i < stream_max; i++)
            {
                Stream[i] = Text[Random.Next(Text.Length)];
            }
        }

        public override void Initialize()
        {
            SetText();
        }
    }

}
