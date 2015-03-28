using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using ReaniszWorks.Framework.XNA.Graphics;

namespace MiniGames.Framework.Scenes
{
    class Lobby : NetworkScene
    {

        ContentManager content;
        SpriteFont font;
        SpriteBatch spriteBatch;

        public Lobby(NetworkSession networkSession, GraphicsDevice graphicsDevice, GameServiceContainer services)
            : base(networkSession, graphicsDevice, services)
        {
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void LoadContent()
        {
            content = new ContentManager(GameServices, "Content/");
            font = content.Load<SpriteFont>(@"Font/UI");
            spriteBatch = new SpriteBatch(graphicsDevice);
        }
        public override void UnloadContent()
        {
            content.Dispose();
        }
        public override void Update(GameTime gameTime)
        {
            networkSession.Update();
            if (networkSession.IsHost)
            {
                UpdateAsHost();
            }
            else
            {
                UpdateAsClient();
            }
        }
        public void UpdateAsHost()
        {
        }
        public void UpdateAsClient()
        {
        }

        public override void Draw()
        {
            using (new UseSpriteBatch(spriteBatch, SpriteSortMode.BackToFront, BlendState.AlphaBlend))
            {
                var position = new Vector2(30,30);
                position.Y += Utility.DrawAndMeasureString(spriteBatch,font,"[Members]",position,Color.Black).Y;
                
                foreach (var m in networkSession.AllGamers)
                {
                    string text = m.IsReady ? "[o] " : "[ ] ";
                    text += m.Gamertag + " : " + m.DisplayName;
                    position.Y += Utility.DrawAndMeasureString(spriteBatch, font, text, position, Color.Black).Y;
                }
            }
        }
        public override void Dispose()
        {
            base.Dispose();
        }
        public override void OnGameStarted(object sender, GameStartedEventArgs e)
        {
        }
        public override void OnGameEnded(object sender, GameEndedEventArgs e)
        {
        }
        public override void OnGamerJoined(object sender, GamerJoinedEventArgs e)
        {
        }
        public override void OnGamerLeft(object sender, GamerLeftEventArgs e)
        {
        }
        public override void OnHostChanged(object sender, HostChangedEventArgs e)
        {
        }
        public override void OnSessionEnded(object sender, NetworkSessionEndedEventArgs e)
        {
        }

    }
}
