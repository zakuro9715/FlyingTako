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
    public class Hole
    {
        public Vector2 Position;
        public Texture2D Texture;
        public Takoyaki Takoyaki;
        public Rectangle Range;

        public void Initialize(Vector2 pos)
        {
            Position = pos;
            Texture = Resource.Hole;
            Range = new Rectangle((int)Position.X, (int)Position.Y, 128, 128);
        }

        public void Update(GameTime gameTime)
        {
            if (Takoyaki != null)
                Takoyaki.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            if (Takoyaki != null)
                Takoyaki.Draw(spriteBatch);
        }
    }
}
