using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniGames.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ReaniszWorks.Framework.XNA.Graphics;
using Microsoft.Xna.Framework;

namespace FlyingTako
{
    public class FlyingTako : MiniGames.Framework.Game<GameState, PlayerGameState>
    {
        public FlyingTako(GraphicsDevice graphicsDevice, GameServiceContainer services, int NumberOfPlayer, int seed)
            : base(graphicsDevice, services, NumberOfPlayer, seed)
        {
        }

        const byte DataID = 252;

        SpriteBatch spriteBatch;
        SpriteFont font;

        Texture2D tex_dot;
        SpriteFont font_StartCount;

        TimeSpan sendTime = new TimeSpan(); 

        GameManager GameManager = new GameManager();

        public override void Initialize()
        {
            Microsoft.Xna.Framework.Input.MouseState m = Microsoft.Xna.Framework.Input.Mouse.GetState();
            
            spriteBatch = new SpriteBatch(graphicsDevice);
            Resource.Load(Content);
            font = Content.Load<SpriteFont>(@"Font/UI");
            font_StartCount = Content.Load<SpriteFont>("Font\\StartCount");
            tex_dot = Content.Load<Texture2D>("Dot");

            GameManager.Initialize(GameState,font, PlayerState);
            GameState.Initialize();
        }

        protected override void UpdateLocalPlayer(PlayerGameState state, GameTime gameTime)
        {
            var str = state.PlayerName;
            if (str == null) state.PlayerName = "Null";


            GameManager.Update(gameTime, state, Mouse);
            if (GameState.TimeLimit.Ticks < 0)
                this.GameEnd();


            ////データ送信
            //sendTime += gameTime.ElapsedGameTime;
            //if(sendTime.TotalMilliseconds > 500)
            //{
            //    sendTime -= new TimeSpan(0, 0, 0, 0, 500);
            //    PacketWriter.Write(DataID);
            //    PacketWriter.Write(state.Score);
            //    GameNetwork.SendData(PacketWriter, Microsoft.Xna.Framework.Net.SendDataOptions.InOrder);
            //}
        }

        protected override void UpdateRemotePlayer(PlayerGameState state, GameTime gameTime)
        {
            var str = state.PlayerName;
            if (str == null) str = "Null";
            //foreach (var p in GameNetwork.Receive())
            //{
            //    switch (p.DataType)
            //    {
            //        case DataID:
            //            if (GetPacketSender(p).PlayerID == state.PlayerID)
            //            {
            //                state.Score = p.PacketReader.ReadInt32();
            //            }
            //            break;
            //    }
            //}
        }

        protected override void DrawPlayersView(PlayerGameState state)
        {
            graphicsDevice.Clear(Color.Blue);

            spriteBatch.Begin();
            GameManager.Draw(spriteBatch,font);
            if (GameState.State == MiniGames.Framework.GameState.EnumState.Waiting)
            {
                spriteBatch.Draw(tex_dot, Vector2.Zero, null, Color.White * 0.4f, 0, Vector2.Zero, new Vector2(1024, 576), SpriteEffects.None, 0.1f);
                var pp = new Vector2(1024, 576) / 2 - font_StartCount.MeasureString("Please Wait") / 2;
                spriteBatch.DrawString(font_StartCount, "Please Wait", pp, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }
            spriteBatch.End();
        }

        public override void DrawUI()
        {
        }

        public override void Dispose()
        {
        }
    }

}
