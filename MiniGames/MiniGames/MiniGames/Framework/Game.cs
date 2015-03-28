using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MiniGames.Framework
{
    public abstract class Game<GameStateType, PlayerStateType> : IGame
        where GameStateType : GameState , new()
        where PlayerStateType : PlayerState , new()
    {
        protected GraphicsDevice graphicsDevice;
        protected GameServiceContainer GameServices;
        protected GameStateType GameState;
        protected List<PlayerStateType> PlayerState;

        protected ContentManager Content;

        protected MiniGames.Framework.Input.Mouse Mouse
        {
            get;
            private set;
        }

        protected PlayerStateType GetPlayerStateByID(byte id)
        {
            foreach (var p in PlayerState)
            {
                if (p.PlayerID == id) { return p; }
            }
            throw new Exception();
        }

        public Game(GraphicsDevice graphicsDevice, GameServiceContainer services, int NumberOfPlayer, int seed)
        {
            this.graphicsDevice = graphicsDevice;
            this.GameServices = services;
            Content = new ContentManager(services, @"Content");
            PlayerState = new List<PlayerStateType>();
            for (int i = 0; i < NumberOfPlayer; i++)
            {
                PlayerState.Add(new PlayerStateType());
            }
            GameState = new GameStateType();
            GameState.InitializeRandom(seed);
            GameState.State = Framework.GameState.EnumState.Ready;
        }

        /// <summary>
        /// ゲームの初期化をします。ゲーム開始時に一度だけ呼ばれます。
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// ゲームの更新をします。
        /// </summary>
        /// <param name="mouse">現在のマウスの状態です。</param>
        public void Update(GameTime gameTime, MiniGames.Framework.Input.Mouse mouse)
        {
            Mouse = mouse;
            foreach (var p in PlayerState)
            {
                UpdatePlayer(p, gameTime);
            }
        }

        /// <summary>
        /// PlayerStateを使って、プレーヤの状態を更新します。
        /// </summary>
        /// <param name="state">更新するプレーヤのPlayerStateです。</param>
        void UpdatePlayer(PlayerStateType state, GameTime gameTime)
        {
            if (state.IsRemote)
            {
                UpdateRemotePlayer(state, gameTime);
            }
            else
            {
                UpdateLocalPlayer(state, gameTime);
            }
        }

        /// <summary>
        /// ローカルでゲームをプレーしているプレーヤの状態を更新します。
        /// </summary>
        /// <param name="state">更新するプレーヤのPlayerStateです。</param>
        protected abstract void UpdateLocalPlayer(PlayerStateType state, GameTime gameTime);

        /// <summary>
        /// ネットワーク越しにプレーしているプレーヤの状態を更新します。
        /// </summary>
        /// <param name="state">更新するプレーヤのPlayerStateです。</param>
        protected abstract void UpdateRemotePlayer(PlayerStateType state, GameTime gameTime);

        /// <summary>
        /// PlayerID番のプレーヤの画面を描画します。
        /// </summary>
        /// <param name="PlayerID">描画するプレーヤのIDです。</param>
        public void Draw(byte PlayerID)
        {
            DrawPlayersView(GetPlayerStateByID(PlayerID));
        }

        /// <summary>
        /// PlayerStateを使って、画面の描画をします。
        /// </summary>
        /// <param name="state">描画する対象のプレーヤです。</param>
        protected abstract void DrawPlayersView(PlayerStateType state);

        /// <summary>
        /// 画面にオーバーラップして表示するUIなどを描画します。
        /// </summary>
        public abstract void DrawUI();

        /// <summary>
        /// ゲームで使用されているリソースなどを解放します。ゲーム終了時に1度だけ呼ばれます。
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// ゲームのスタートを指示します。
        /// </summary>
        public void GameStart()
        {
            GameState.State = Framework.GameState.EnumState.Running;
            OnGameStart();
        }

        /// <summary>
        /// ゲームの終了を指示します。
        /// </summary>
        public void GameEnd()
        {
            GameState.State = Framework.GameState.EnumState.Waiting;
            OnGameEnd();
        }

        public virtual void OnGameStart()
        {
        }

        public virtual void OnGameEnd()
        {
        }

        public GameState GetGameState()
        {
            return GameState;
        }

    }
}