using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniGames.Framework;
using MiniGames.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ReaniszWorks.Framework.XNA.Graphics;
using Microsoft.Xna.Framework;

namespace FlyingTako
{
    public class Teppan
    {
        Texture2D Texture;
        public Hole[,] Hole = new Hole[2, 8];

        public void Initialize()
        {
            Texture = Resource.Teppan;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Vector2 pos = new Vector2(j * 128, i * 128 + 258);

                    Hole[i, j] = new Hole();  
                    Hole[i, j].Initialize(pos);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in Hole)
            {
                item.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Vector2(0, 288), Color.White);
            foreach (var item in Hole)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
