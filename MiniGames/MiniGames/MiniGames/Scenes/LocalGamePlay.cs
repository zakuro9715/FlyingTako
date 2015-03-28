using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using ReaniszWorks.Framework.XNA.Graphics;

namespace MiniGames.Scenes
{
    class LocalGamePlay : Scene
    {
        ContentManager content;
        SpriteFont font;
        SpriteBatch spriteBatch;

        Texture2D tex_back;

        MiniGames.Framework.LocalGP LGP;

        int frame = 0;

        public LocalGamePlay(GraphicsDevice graphicsDevice, GameServiceContainer services, MiniGames.Framework.IGame game)
            : base(graphicsDevice, services)
        {
            LGP = new Framework.LocalGP(game, graphicsDevice, services);
        }

        override public void Initialize()
        {
            LGP.Initialize();
        }
        override public void LoadContent()
        {
        }
        override public void UnloadContent()
        {
        }
        override public void Update(GameTime gameTime)
        {
            LGP.Update(gameTime);
        }

        override public void Draw()
        {
            LGP.Draw();
        }

        override public void Dispose()
        {
            UnloadContent();
        }
    }
}