using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MiniGames.Framework
{
    public interface IGame
    {
        /// <summary>
        /// ゲームの初期化をします。ゲーム開始時に一度だけ呼ばれます。
        /// </summary>
        void Initialize();

        /// <summary>
        /// ゲームの更新をします。
        /// </summary>
        /// <param name="mouse">現在のマウスの状態です。</param>
        void Update(GameTime gameTime, MiniGames.Framework.Input.Mouse mouse);

        /// <summary>
        /// PlayerID番のプレーヤの画面を描画します。
        /// </summary>
        /// <param name="PlayerID">描画するプレーヤのIDです。</param>
        void Draw(byte PlayerID);

        /// <summary>
        /// ゲームで使用されているリソースなどを解放します。ゲーム終了時に1度だけ呼ばれます。
        /// </summary>
        void Dispose();

        /// <summary>
        /// 画面にオーバーラップして表示するUIなどを描画します。
        /// </summary>
        void DrawUI();

        /// <summary>
        /// ゲームのスタートを指示します。
        /// </summary>
        void GameStart();

        /// <summary>
        /// ゲームの終了を指示します。
        /// </summary>
        void GameEnd();

        /// <summary>
        /// GameStateを取得します。
        /// </summary>
        /// <returns></returns>
        GameState GetGameState();
    }
}
