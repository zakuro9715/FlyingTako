using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using ReaniszWorks.Framework.XNA.Graphics;
using MiniGames.Framework.UI;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.GamerServices;

namespace MiniGames.Scenes
{
    class MainMenu : Scene
    {
        ContentManager content;
        SpriteFont font;
        SpriteBatch spriteBatch;

        Texture2D tex_back;


        Button OnlinePlay;

        int frame = 0;

        public MainMenu (GraphicsDevice graphicsDevice, GameServiceContainer services) : base(graphicsDevice,services)
        {
        }
        
        override public void Initialize()
        {
            OnlinePlay = new Button()
            {
                Origin = Vector2.Zero,
                Position = new Vector2(10,10),
                depth = 0.2f
            };
            OnlinePlay.OnClick += StartOnlinePlay;
            LoadContent();
        }
        override public void LoadContent()
        {
            content = new ContentManager(GameServices);
            content.RootDirectory = "Content";
            tex_back = content.Load<Texture2D>(@"MainMenu/BackGround");
            spriteBatch = new SpriteBatch(graphicsDevice);
            font = content.Load<SpriteFont>(@"Font/UI");
            OnlinePlay.Texture = content.Load<Texture2D>(@"MainMenu/Button_OnlinePlay");
            OnlinePlay.HoverTexture = content.Load<Texture2D>(@"MainMenu/Button_OnlinePlay_Hover");
            OnlinePlay.Size = new Vector2(OnlinePlay.Texture.Width, OnlinePlay.Texture.Height);
        }
        override public void UnloadContent()
        {
        }
        override public void Update(GameTime gameTime)
        {
            if (Gamer.SignedInGamers.Count == 0)
            {
                Guide.ShowSignIn(1, false);
                return;
            }
            var mouse = Framework.Input.Mouse.GetInstance();
            var k = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            if (k.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.H))
            {
                StartOnlinePlayAsHost();
            }

            OnlinePlay.Update();
            
            frame++;
        }

        void StartOnlinePlay()
        {
            var sl = NetworkSession.Find(NetworkSessionType.SystemLink, 1, new NetworkSessionProperties());
            if (sl.Count == 0)
            {
                Guide.BeginShowMessageBox("Error", "有効なNetwork Sessionが見つかりません。\nこの画面を開いたままスタッフをお呼びください。", new string[] { "OK" }, 0, MessageBoxIcon.Error, null, null);
                return;
            }

            var session = NetworkSession.Join(sl[0]);
            NextScene = new MiniGames.Framework.Scenes.NetworkGameScene(
                session, graphicsDevice, GameServices,
                new MiniGames.Framework.Scenes.Lobby(session, graphicsDevice, GameServices)
                );

            
        }

        void StartOnlinePlayAsHost()
        {
            var session = NetworkSession.Create(NetworkSessionType.SystemLink, 1, 31);
            NextScene = new MiniGames.Framework.Scenes.NetworkGameScene(
                session, graphicsDevice, GameServices,
                new MiniGames.Framework.Scenes.Lobby(session, graphicsDevice, GameServices)
                );
        }

        override public void Draw()
        {
            using (var usb = new UseSpriteBatch(spriteBatch))
            {
                spriteBatch.Draw(tex_back, new Vector2(0, 0), Color.White);
                OnlinePlay.Draw(spriteBatch);
            }
        }


        override public void Dispose()
        {
            UnloadContent();
        }
    }
}
