using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniGames.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ReaniszWorks.Framework.XNA.Graphics;
using Microsoft.Xna.Framework;

namespace FlyingTako
{
    public class Sky
    {
        public List<Takoyaki> Takoyaki = new List<Takoyaki>();
        public Customer[] Customer;
        PlayerGameState PlayerGameState;

        public void Initialize(SpriteFont font)
        {
            Customer = new Customer[9];
            int seed = DateTime.Now.Millisecond;
            for (int i = 0; i < Customer.Length; i++)
            {
                Customer c = new Customer();
                c.Initialize(new Vector2(i * 64 + 512, 163), font, seed += 5);
                c.isNext = i == 0 ? true : false;
                Customer[i] = c;
            }
        }

        public void Update(PlayerGameState state,GameTime gameTime)
        {
            PlayerGameState = state;
            Takoyaki[] copy = new Takoyaki[Takoyaki.Count];
            Takoyaki.CopyTo(copy);
            foreach (var item in copy)
            {
                item.Update(gameTime);
                item.Position += item.Vector * 10;
                if (item.Position.Y > 800)
                    Takoyaki.Remove(item);

                if (new Rectangle((int)item.Position.X, (int)item.Position.Y, 128, 128).Contains((int)Customer[0].Position.X, (int)Customer[0].Position.Y))
                {
                    if (Customer[0].TextureNo < 3)
                    {
                        if (item.TextureNo == 7 && item.isRiddenTako)
                            Customer[0].TextureNo += 6;
                        else
                            Customer[0].TextureNo += 3;
                    }
                    else if(Customer[0].TextureNo < 6)
                    {
                        if (item.TextureNo == 7 && item.isRiddenTako)
                            Customer[0].TextureNo += 3;
                    }
                    else if (Customer[0].TextureNo < 9)
                    {
                        if (item.TextureNo != 7 || !item.isRiddenTako)
                            Customer[0].TextureNo -= 3;
                    }
                    Takoyaki.Remove(item);
                    Customer[0].NumberOfBuying--;
                    PlayerGameState.Score += item.TextureNo == 7 ? 50 : 25;
                    PlayerGameState.Score -= item.isRiddenTako ? 0 : 25;
                    if (Customer[0].NumberOfBuying == 0)
                    {
                        for (int i = 0; i <= Customer.Length - 2; i++)
                        {
                            Customer[i] = Customer[i + 1];
                            Customer[i].Position.X -= 64;
                        }
                        Customer[Customer.Length - 1] = new Customer();
                        Customer[Customer.Length - 1].Initialize(new Vector2(64 * (Customer.Length - 1) +512, 163), Customer[Customer.Length - 2].Font, DateTime.Now.Millisecond);
                        Customer[0].isNext = true;
                    }
                }
            }
            Customer[0].Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = Customer.Length - 1; i >= 0; i--)
            {
                Customer[i].Draw(spriteBatch);
            }
        }
    }

    public class Customer
    {
        public Vector2 Position;
        public int NumberOfBuying;
        public int PurchaseMoney;
        public int MaxBring;
        public Texture2D Texture;
        public SpriteFont Font;
        int flame;
        int startFlame;
        public bool isNext;

        int _TextureNo;
        public int TextureNo
        {
            set
            {
                _TextureNo = value;
                Texture = Resource.Customer[value];
                startFlame = flame;
            }
            get { return _TextureNo; }
        }

        public void Initialize(Vector2 pos, SpriteFont font,int seed)
        {
            Position = pos;
            Font = font;
            NumberOfBuying = MaxBring = new Random(seed++).Next(1, 9);
            TextureNo = new Random(seed++).Next(3);
        }

        public void Update()
        {
            flame++;
            if (TextureNo > 2)
            {
                if (flame - startFlame > 300)
                {
                    if (TextureNo > 5)
                        TextureNo -= 6;
                    else
                        TextureNo -= 3;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position - new Vector2(Texture.Width / 2, Texture.Height / 2), Color.White);
            if (isNext && flame < 300)
            {
                spriteBatch.Draw(Resource.Hukidashi, new Vector2(480, 0), Color.White);
                spriteBatch.DrawString(Font, MaxBring + "個ください", new Vector2(508, 12), Color.Black);
            }
            //spriteBatch.DrawString(Font, "a", Position, Color.White);
        }

        public Customer Clone()
        {
            Customer c = new Customer();
            c.Position = Position;
            c.NumberOfBuying = NumberOfBuying;
            c.PurchaseMoney = PurchaseMoney;
            c.Texture = Texture;
            c.TextureNo = TextureNo;
            c.Font = Font;
            return c;
        }
    }
}