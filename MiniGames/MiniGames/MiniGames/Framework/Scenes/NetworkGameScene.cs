using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;

namespace MiniGames.Framework.Scenes
{
    class NetworkGameScene : MiniGames.Scenes.Scene
    {
        NetworkSession networkSession;
        SceneManager sceneManager = new SceneManager();


        public NetworkGameScene(NetworkSession networkSession, GraphicsDevice graphicsDevice, GameServiceContainer services,
            NetworkScene scene)
            : base(graphicsDevice, services)
        {
            this.networkSession = networkSession;
            sceneManager.nextScene = scene;
        }
        public override void Initialize()
        {
            networkSession.GameStarted += OnGameStarted;
            networkSession.GameEnded += OnGameEnded;
            networkSession.GamerJoined += OnGamerJoined;
            networkSession.GamerLeft += OnGamerLeft;
            networkSession.HostChanged += OnHostChanged;
            networkSession.SessionEnded += OnSessionEnded;
        }
        public override void Update(GameTime gameTime)
        {
            sceneManager.Update(gameTime);
        }
        public override void Draw()
        {
            sceneManager.Draw();
        }


        public void OnGameStarted(object sender, GameStartedEventArgs e)
        {
        }
        public void OnGameEnded(object sender, GameEndedEventArgs e)
        {
        }
        public void OnGamerJoined(object sender, GamerJoinedEventArgs e)
        {
        }
        public void OnGamerLeft(object sender, GamerLeftEventArgs e)
        {
        }
        public void OnHostChanged(object sender, HostChangedEventArgs e)
        {
        }
        public void OnSessionEnded(object sender, NetworkSessionEndedEventArgs e)
        {
            Guide.BeginShowMessageBox("切断されました","NetworkSessionから切断されました。\n理由:" + e.EndReason.ToString(),
                new string[]{"OK"}, 0, MessageBoxIcon.Alert, null, null
                );
            NextScene = new MiniGames.Scenes.Title(graphicsDevice, GameServices);
        }
    }
}
