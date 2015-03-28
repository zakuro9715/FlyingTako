using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniGames.Scenes;
using Microsoft.Xna.Framework;

namespace MiniGames.Framework
{
    /// <summary>
    /// シーン制御を管理するクラスです。
    /// </summary>
    class SceneManager : IDisposable
    {
        public MiniGames.Scenes.Scene CurrentScene
        {
            get;
            set;
        }
        public MiniGames.Scenes.Scene nextScene;

        public void Initialize()
        {
            CurrentScene.Initialize();
        }
        public void Update(GameTime gameTime)
        {
            var ns = nextScene != null ? nextScene : (CurrentScene != null && CurrentScene.NextScene != null ? CurrentScene.NextScene : null);
            if (ns != null)
            {
                if (CurrentScene != null)
                {
                    CurrentScene.Dispose();
                }
                CurrentScene = ns;
                CurrentScene.Initialize();
            }
            CurrentScene.Update(gameTime);
        }
        public void Draw()
        {
            CurrentScene.Draw();
        }
        public void Dispose()
        {
            if (CurrentScene != null)
            {
                CurrentScene.Dispose();
            }
        }
    }
}
