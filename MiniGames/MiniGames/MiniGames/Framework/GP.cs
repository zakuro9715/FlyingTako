using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Content;
using ReaniszWorks.Framework.XNA.Graphics;

namespace MiniGames.Framework
{
    class GP
    {

        public bool IsRunning
        {
            get;
            protected set;
        }
        IGame game;

        GraphicsDevice graphicsDevice;
        GameServiceContainer GameServices;
        SpriteBatch spriteBatch;
        NetworkSession networkSession;

        ContentManager Content;

        MiniGames.Framework.Input.VirtualMouse vmouse = new Input.VirtualMouse();

        Texture2D tex_infoview;
        Texture2D tex_dot;
        SpriteFont font_StartCount;

        int CountDown = 0;


        RenderTarget2D mainGameViewRenderTarget;
        RenderTarget2D UIViewRenderTarget;
        RenderTarget2D InfoRenderTarget;

        public GP(MiniGames.Framework.IGame game, GraphicsDevice graphicsDevice, GameServiceContainer services, NetworkSession networkSession)
        {
            
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.GameServices = services;
            this.networkSession = networkSession;
            PacketReader pk;
            
        }

        public void Initialize()
        {
            spriteBatch = new SpriteBatch(graphicsDevice);
            mainGameViewRenderTarget = new RenderTarget2D(graphicsDevice, 1024, 576);
            UIViewRenderTarget = new RenderTarget2D(graphicsDevice, 1024, 576);
            InfoRenderTarget = new RenderTarget2D(graphicsDevice, 1024, 768 - 576);
            Content = new ContentManager(GameServices, @"Content");
            tex_infoview = Content.Load<Texture2D>(@"Game/InfoView");
            tex_dot = Content.Load<Texture2D>(@"Dot");
            font_StartCount = Content.Load<SpriteFont>(@"Font/StartCount");
            game.Initialize();
        }

        public void Update(GameTime gameTime)
        {
            var mouse = MiniGames.Framework.Input.Mouse.GetInstance();
            vmouse.Update();
            if (mouse.LeftButton.IsPressed) { vmouse.VirtualLeftButton.Press(); }
            if (mouse.RightButton.IsPressed) { vmouse.VirtualRightButton.Press(); }
            CountDown++;
            if (CountDown == 240)
            {
                game.GameStart();
            }
            game.Update(gameTime, vmouse);
        }
        public void Draw()
        {
            using (var rendertarget = new ChangeRenderTarget(graphicsDevice, mainGameViewRenderTarget))
            {
                graphicsDevice.Clear(Color.LawnGreen);
                game.Draw(0);
            }
            //using (var rendertarget = new ChangeRenderTarget(graphicsDevice, UIViewRenderTarget))
            //{
            //    graphicsDevice.Clear(Color.Transparent);
            //    game.DrawUI();
            //}
            using (var rendertarget = new ChangeRenderTarget(graphicsDevice, InfoRenderTarget))
            {
                graphicsDevice.Clear(Color.Transparent);
                using (var sb = new UseSpriteBatch(spriteBatch))
                {
                    spriteBatch.Draw(tex_infoview, Vector2.Zero, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
                }
            }
            using (var sb = new UseSpriteBatch(spriteBatch, SpriteSortMode.BackToFront, BlendState.AlphaBlend))
            {
                spriteBatch.Draw(mainGameViewRenderTarget, Vector2.Zero, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.5f);
                //spriteBatch.Draw(UIViewRenderTarget, Vector2.Zero, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.4f);
                spriteBatch.Draw(InfoRenderTarget, new Vector2(0, 576), null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.4f);
                if (game.GetGameState().State == GameState.EnumState.Ready && CountDown < 60 * 4)
                {
                    int c = CountDown;
                    var str = c < 60 * 3 ? ((60 * 3 - c) / 60 + 1).ToString() : "Go!";
                    var pp = new Vector2(1024, 576) / 2 - font_StartCount.MeasureString(str) / 2;
                    spriteBatch.DrawString(font_StartCount, str, pp, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                    spriteBatch.Draw(tex_dot, Vector2.Zero, null, Color.White * 0.4f, 0, Vector2.Zero, new Vector2(1024, 576), SpriteEffects.None, 0.1f);
                }
            }
        }
    }
}
