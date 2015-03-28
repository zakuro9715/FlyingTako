using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MiniGames.Framework.Scenes
{
    abstract class NetworkScene : MiniGames.Scenes.Scene
    {
        protected NetworkSession networkSession;
        public NetworkScene(NetworkSession networkSession, GraphicsDevice graphicsDevice, GameServiceContainer services)
            : base(graphicsDevice, services)
        {
            this.networkSession = networkSession;
        }
        public override MiniGames.Scenes.Scene NextScene
        {
            get
            {
                return base.NextScene;
            }
            protected set
            {
                if (!(value is NetworkScene))
                {
                    throw new ArgumentException("NetworkSceneのNextSceneはNetworkSceneの派生クラスを指定してください。");
                }
                base.NextScene = value;
            }
        }
        public virtual void OnGameStarted(object sender, GameStartedEventArgs e)
        {
        }
        public virtual void OnGameEnded(object sender, GameEndedEventArgs e)
        {
        }
        public virtual void OnGamerJoined(object sender, GamerJoinedEventArgs e)
        {
        }
        public virtual void OnGamerLeft(object sender, GamerLeftEventArgs e)
        {
        }
        public virtual void OnHostChanged(object sender, HostChangedEventArgs e)
        {
        }
        public virtual void OnSessionEnded(object sender, NetworkSessionEndedEventArgs e)
        {
        }
    }
}
