using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniGames.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Net;
using ReaniszWorks.Framework.XNA.Graphics;
using Microsoft.Xna.Framework;

namespace MiniGames.SampleGame
{
    class SampleGame : MiniGames.Framework.Game<GameState, PlayerGameState>
    {
        public SampleGame(GraphicsDevice graphicsDevice, GameServiceContainer services, int NumberOfPlayer, int seed)
            : base(graphicsDevice, services, NumberOfPlayer, seed)
        {
        }

        SpriteBatch spriteBatch;
        SpriteFont font;

        Vector2 pos = new Vector2(100, 0);

        public override void Initialize()
        {
            spriteBatch = new SpriteBatch(graphicsDevice);
            font = Content.Load<SpriteFont>(@"Font/UI");
            GameState.Initialize();

        }

        protected override void UpdateLocalPlayer(PlayerGameState state, GameTime gameTime)
        {
            if (GameState.State == Framework.GameState.EnumState.Running)
            {
                pos += new Vector2(0, -3);
            }
        }

        protected override void UpdateRemotePlayer(PlayerGameState state, GameTime gameTime)
        {
            
        }

        protected override void DrawPlayersView(PlayerGameState state)
        {
            graphicsDevice.Clear(Color.Blue);
            using (var sb = new UseSpriteBatch(spriteBatch))
            {
                var p = pos;
                foreach (var s in GameState.Stream)
                {
                    var pp = font.MeasureString(s);
                    spriteBatch.DrawString(font, s, p, Color.White);
                    p.Y += pp.Y;
                }
            }
        }

        public override void DrawUI()
        {
        }

        public override void Dispose()
        {
        }
    }

}
