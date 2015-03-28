using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MiniGames.Framework.UI
{
    class Button
    {
        public delegate void ButtonEvent();

        /// <summary>
        /// ボタンを描画する左上座標です。
        /// </summary>
        public Vector2 Position { get; set; }
        /// <summary>
        /// レンダーターゲットの原点の座標です。
        /// </summary>
        public Vector2 Origin { get; set; }

        public Vector2 Size { get; set; }

        public Texture2D Texture { get; set; }
        public Texture2D HoverTexture { get; set; }
        public Texture2D PushedTexture { get; set; }

        public float depth;

        bool IsHover()
        {
            var mouse = MiniGames.Framework.Input.Mouse.GetInstance();
            var pos = Position + Origin;
            return mouse.Contains(
                new Rectangle(
                        (int)pos.X, (int)pos.Y,
                        (int)Size.X, (int)Size.Y
                    )
                    );
        }

        bool pressing = false;

        public void Draw(SpriteBatch spriteBatch)
        {
            var tex = IsHover() ? HoverTexture : Texture;
            spriteBatch.Draw(tex, Position, null, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, depth);
        }
        public void Update()
        {
            var mouse = MiniGames.Framework.Input.Mouse.GetInstance();
            if (pressing)
            {
                if (!mouse.LeftButton.IsPressed)
                {
                    if (IsHover())
                    {
                        Click();
                    }
                    else
                    {
                        pressing = false;
                    }
                }
            }
            else
            {
                if (mouse.LeftButton.IsBeingPressed && IsHover())
                {
                    pressing = true;
                }
            }
        }


        public void Click()
        {
            OnClick();
        }

        public event ButtonEvent OnClick;
        

    }
}
