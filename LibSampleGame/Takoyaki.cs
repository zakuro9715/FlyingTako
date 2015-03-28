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
    public class Takoyaki
    {

        public bool isRiddenTako = true;
        public Tako Tako = new Tako();
        public float Movement;
        public Vector2 Position;

        long Time;
        Texture2D Texture;
        DateTime StartTime = new DateTime();
        static TimeSpan Interval;

        int _TextureNo;
        public int TextureNo
        {
            set
            {
                _TextureNo = value;
                Texture = Resource.Takoyaki[value];
                if (value < 3)
                    Tako.Texture = Resource.Tako[value];
                else
                    Tako.Texture = Resource.Tako[2];
                StartTime = DateTime.Now;
            }
            get { return _TextureNo; }
        }

        public Vector2 Vector
        {
            set;
            get;
        }
        

        public void Initialize(Vector2 pos)
        {
            Texture = Resource.Takoyaki[0];
            Position = pos;
            TextureNo = 0;
            Vector = Vector2.Zero;
            Interval = new TimeSpan(0, 0, 8);
            Tako.Initialize(Position + new Vector2(40));
        }

        public void Update(GameTime gameTime)
        {
            Time += gameTime.ElapsedGameTime.Ticks;
            if (Time > Interval.Ticks && TextureNo != 2 && TextureNo < 5)
            {
                TextureNo++;
                Time = 0;
            }
            else if (Movement > 1000 && TextureNo == 1)
            {
                TextureNo = 3;
                Movement = 0;
            }
            Tako.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White);
            if (TextureNo < 3)
                Tako.Draw(spriteBatch);
        }

        
        public Takoyaki Clone()
        {
            Takoyaki takoyaki = new Takoyaki();
            takoyaki.Initialize(Position);
            takoyaki.isRiddenTako = isRiddenTako;
            takoyaki.Tako = Tako;
            takoyaki.Movement = Movement;
            takoyaki.Texture = Texture;
            takoyaki.TextureNo = TextureNo;
            takoyaki.StartTime = StartTime;
            takoyaki.Vector = Vector;
            return takoyaki;
        }
    }
}
