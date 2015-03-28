using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MiniGames.Scenes
{
    abstract class Scene : IDisposable
    {
        protected GraphicsDevice graphicsDevice;
        protected GameServiceContainer GameServices;

        public Scene(GraphicsDevice graphicsDevice, GameServiceContainer GameServices)
        {
            this.graphicsDevice = graphicsDevice;
            this.GameServices = GameServices;
        }

        public virtual Scene NextScene
        {
            get;
            protected set;
        }
        virtual public void Initialize()
        {
            LoadContent();
        }
        virtual public void LoadContent()
        {
        }
        virtual public void UnloadContent()
        {
        }
        virtual public void Update(GameTime gameTime)
        {
        }
        virtual public void Draw()
        {
        }
        virtual public void Dispose()
        {
            UnloadContent();
        }
    }
}
