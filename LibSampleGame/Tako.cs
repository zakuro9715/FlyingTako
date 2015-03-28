using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniGames.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReaniszWorks.Framework.XNA.Graphics;
using Microsoft.Xna.Framework;

namespace FlyingTako
{
    public class Tako
    {
        public bool isFlying = false;
        public float rotation = 0;
        public Texture2D Texture;
        public Vector2 Position;

        public void Initialize(Vector2 pos)
        {
            Texture = Resource.Tako[0];
            Position = pos;
        }

        public void Update()
        {
            if (isFlying && Position.Y > -100)
            {
                Position += new Vector2(0, -8);
                rotation += 0.2f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isFlying)
                spriteBatch.Draw(Texture, Position, Color.White);
            else
                spriteBatch.Draw(Resource.Tako[2], Position + new Vector2(24, 24), null, Color.White, rotation, new Vector2(24), new Vector2(1), SpriteEffects.None, 0);
        }
    }
}
