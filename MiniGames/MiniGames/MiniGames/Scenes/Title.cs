using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using ReaniszWorks.Framework.XNA.Graphics;
using Microsoft.Xna.Framework.GamerServices;

namespace MiniGames.Scenes
{
    class Title : Scene
    {
        ContentManager content;
        SpriteFont font;
        SpriteBatch spriteBatch;

        Texture2D tex_back;

        int frame = 0;

        public Title(GraphicsDevice graphicsDevice, GameServiceContainer services)
            : base(graphicsDevice, services)
        {
        }

        override public void Initialize()
        {
            LoadContent();
        }
        override public void LoadContent()
        {
            content = new ContentManager(GameServices);
            content.RootDirectory = "Content";
            tex_back = content.Load<Texture2D>(@"Title/TitleImage");
            spriteBatch = new SpriteBatch(graphicsDevice);
            font = content.Load<SpriteFont>(@"Font/UI");
        }
        override public void UnloadContent()
        {
        }
        override public void Update(GameTime gameTime)
        {
            var mouse = Framework.Input.Mouse.GetInstance();
            if (mouse.LeftButton.IsPressed)
            {
                NextScene = new Scenes.MainMenu(graphicsDevice, GameServices);
            }

            frame++;
        }

        override public void Draw()
        {
            using (var usb = new UseSpriteBatch(spriteBatch))
            {
                spriteBatch.Draw(tex_back, new Vector2(0, 0), Color.White);
                const string text = "Left Click";
                var pos = new Vector2(1024 / 2, 768 * 3 / 4);
                pos -= new Vector2(font.MeasureString(text).X / 2, 0);
                var op = (frame / 30) % 2 == 0 ? 1 : 0;
                spriteBatch.DrawString(font, "Left Click", pos, Color.Black * op);
            }
        }

        override public void Dispose()
        {
            UnloadContent();
        }
    }
}
