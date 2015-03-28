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

namespace FlyingTako
{
    public static class Resource
    {
        public static Texture2D[] TimeLimitBar = new Texture2D[3];
        public static Texture2D[] MaterialBar = new Texture2D[3];
        public static Texture2D[] Customer = new Texture2D[9];
        public static Texture2D[] Takoyaki = new Texture2D[9];
        public static Texture2D[] Tako = new Texture2D[3];
        public static Texture2D[] Fune = new Texture2D[2];
        public static Texture2D Hole;
        public static Texture2D Teppan;
        public static Texture2D Hukidashi;
        public static void Load(ContentManager Content)
        {
            TimeLimitBar[0] = Content.Load<Texture2D>("Image\\TimeLimitBar0");
            TimeLimitBar[1] = Content.Load<Texture2D>("Image\\TimeLimitBar1");
            TimeLimitBar[2] = Content.Load<Texture2D>("Image\\TimeLimitBar2");
            MaterialBar[0] = Content.Load<Texture2D>("Image\\MaterialBar0");
            MaterialBar[1] = Content.Load<Texture2D>("Image\\MaterialBar1");
            MaterialBar[2] = Content.Load<Texture2D>("Image\\MaterialBar2");
            Customer[0] = Content.Load<Texture2D>("Image\\Face0_0");
             Customer[1] = Content.Load<Texture2D>("Image\\Face1_0");
             Customer[2] = Content.Load<Texture2D>("Image\\Face2_0");
             Customer[3] = Content.Load<Texture2D>("Image\\Face0_1");
             Customer[4] = Content.Load<Texture2D>("Image\\Face1_1");
             Customer[5] = Content.Load<Texture2D>("Image\\Face2_1");
             Customer[6] = Content.Load<Texture2D>("Image\\Face0_2");
             Customer[7] = Content.Load<Texture2D>("Image\\Face1_2");
             Customer[8] = Content.Load<Texture2D>("Image\\Face2_2");
            Takoyaki[0] = Content.Load<Texture2D>("Image\\takoyaki_0");
            Takoyaki[1] = Content.Load<Texture2D>("Image\\takoyaki_1");
            Takoyaki[2] = Content.Load<Texture2D>("Image\\takoyaki_2");
            Takoyaki[3] = Content.Load<Texture2D>("Image\\takoyaki_3");
            Takoyaki[4] = Content.Load<Texture2D>("Image\\takoyaki_4");
            Takoyaki[5] = Content.Load<Texture2D>("Image\\takoyaki_5");
            Takoyaki[6] = Content.Load<Texture2D>("Image\\takoyaki_6");
            Takoyaki[7] = Content.Load<Texture2D>("Image\\takoyaki_7");
            Takoyaki[8] = Content.Load<Texture2D>("Image\\takoyaki_8");
            Tako[0] = Content.Load<Texture2D>("Image\\takoyaki_tako0");
            Tako[1] = Content.Load<Texture2D>("Image\\takoyaki_tako1");
            Tako[2] = Content.Load<Texture2D>("Image\\takoyaki_tako2");
            Fune[0] = Content.Load<Texture2D>("Image\\Fune0");
            Fune[1] = Content.Load<Texture2D>("Image\\Fune1");
            Hole = Content.Load<Texture2D>("Image\\takoyaki_hole");
            Teppan = Content.Load<Texture2D>("Image\\takoyaki_teppan");
            Hukidashi = Content.Load<Texture2D>("Image\\hukidashi1");
        }
    }
}
