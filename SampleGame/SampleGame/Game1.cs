using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GamePlay 
{
    /// <summary>
    /// 基底 Game クラスから派生した、ゲームのメイン クラスです。
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MiniGames.Framework.LocalGP GP;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            this.IsMouseVisible = true;


            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// ゲームの開始前に実行する必要がある初期化を実行できるようにします。
        /// ここで、要求されたサービスを問い合わせて、非グラフィック関連のコンテンツを読み込むことができます。
        /// base.Initialize を呼び出すと、任意のコンポーネントが列挙され、
        /// 初期化もされます。
        /// </summary>
        protected override void Initialize()
        {
            var game = new FlyingTako.FlyingTako (GraphicsDevice, Services, 1, new Random().Next());
            game.Content.RootDirectory = @"Content/";
            GP = new MiniGames.Framework.LocalGP(game, GraphicsDevice, Services);
            
            GP.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent はゲームごとに 1 回呼び出され、ここですべてのコンテンツを
        /// 読み込みます。
        /// </summary>
        protected override void LoadContent()
        {
        }

        /// <summary>
        /// UnloadContent はゲームごとに 1 回呼び出され、ここですべてのコンテンツを
        /// アンロードします。
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// ワールドの更新、衝突判定、入力値の取得、オーディオの再生などの
        /// ゲーム ロジックを、実行します。
        /// </summary>
        /// <param name="gameTime">ゲームの瞬間的なタイミング情報</param>
        protected override void Update(GameTime gameTime)
        {
            MiniGames.Framework.Input.Mouse.GetInstance().Update();
            GP.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// ゲームが自身を描画するためのメソッドです。
        /// </summary>
        /// <param name="gameTime">ゲームの瞬間的なタイミング情報</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GP.Draw();

            base.Draw(gameTime);
        }
    }
}
