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
    public class GameManager
    {
        GameState GameState;
        PlayerGameState PlayerGameState;
        List<PlayerGameState> PlayerGameStates;
        Teppan Teppan = new Teppan();
        Sky Sky = new Sky();

        Takoyaki HavingTakoyaki;
        Mouse Mouse;
        Vector2 StartPosition;
        Rectangle StartRange;

        public void Initialize(GameState gameState, SpriteFont font, List<PlayerGameState> state)
        {
            GameState = gameState;
            PlayerGameStates = state;
            Sky.Initialize(font);
            Teppan.Initialize();
        }

        public void Update(GameTime gameTime, PlayerGameState state, Mouse mouse)
        {
            Mouse = mouse;
            PlayerGameState = state;



            //得点の計算など
            if (GameState.State == MiniGames.Framework.GameState.EnumState.Running)
            {
                GameState.TimeLimit = GameState.TimeLimit.Subtract(gameTime.ElapsedGameTime);

                Sky.Update(PlayerGameState, gameTime);
                Teppan.Update(gameTime);

                if (Mouse.LeftButton.IsBeingPressed)
                    BeingPressedLeftButton();
                if (Mouse.LeftButton.IsBeingReleased)
                    BeingReleasedLeftButton();
                if (Mouse.LeftButton.IsPressed)
                    PressingLeftButton();

            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont Font)
        {
            if (GameState.State == GameState.EnumState.Running)
                Sky.Draw(spriteBatch);
            Teppan.Draw(spriteBatch);
            if (HavingTakoyaki != null)
                HavingTakoyaki.Draw(spriteBatch);
            foreach (var item in Sky.Takoyaki)
            {
                item.Draw(spriteBatch);
            }

            spriteBatch.Draw(Resource.TimeLimitBar[0], new Vector2(0, 0), Color.White);
            spriteBatch.Draw(Resource.TimeLimitBar[1], new Vector2(0, 0), new Rectangle(0, 0, (int)(96 * (GameState.TimeLimit.TotalMilliseconds / GameState.MaxTimeLimit.TotalMilliseconds)), 12), Color.White);
            spriteBatch.Draw(Resource.TimeLimitBar[2], new Vector2(0, 0), Color.White);
            spriteBatch.Draw(Resource.MaterialBar[0], new Vector2(0, 16), Color.White);
            spriteBatch.Draw(Resource.MaterialBar[1], new Vector2(0, 16), new Rectangle(0, 0, (int)(96 * (Sky.Customer[0].NumberOfBuying / (float)Sky.Customer[0].MaxBring)), 12), Color.White);
            spriteBatch.Draw(Resource.MaterialBar[2], new Vector2(0, 16), Color.White);

            Vector2 pos = new Vector2(0, 536); ;

            spriteBatch.DrawString(Font, "売上:" + PlayerGameState.Score + "円", new Vector2(0, 32), Color.White);
        }



        void BeingPressedLeftButton()
        {

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Mouse.Contains(Teppan.Hole[i, j].Range))
                    {
                        if (Teppan.Hole[i, j].Takoyaki != null && (Teppan.Hole[i, j].Takoyaki.TextureNo >= 3 && Teppan.Hole[i, j].Takoyaki.TextureNo <= 5))
                        {
                            HavingTakoyaki = Teppan.Hole[i, j].Takoyaki;
                            Teppan.Hole[i, j].Takoyaki = null;
                            StartPosition = Mouse.Position;
                        }
                        else //クリック準備
                        {
                            StartRange = Teppan.Hole[i, j].Range;
                            StartPosition = Mouse.Position;
                        }
                    }
                }
            }
        }

        void BeingReleasedLeftButton()
        {
            if (HavingTakoyaki != null)
            {
                Vector2 v = Vector2.Normalize(Mouse.Position - StartPosition);
                HavingTakoyaki.Vector = v;
                HavingTakoyaki.TextureNo += 3;
                Sky.Takoyaki.Add(HavingTakoyaki);
                HavingTakoyaki = null;

            }
            else
            {
                foreach (var item in Teppan.Hole)
                {

                    Vector2 v = Mouse.Position - StartPosition;
                    if (item.Range == StartRange && v.X * v.Y < 10 * 10)
                    {
                        if (item.Takoyaki == null)
                        {
                            item.Takoyaki = new Takoyaki();
                            item.Takoyaki.Initialize(item.Position);
                        }
                        else if (item.Takoyaki.TextureNo == 0)
                            item.Takoyaki.Tako.isFlying = true;
                        else if (item.Takoyaki.TextureNo == 1)
                            item.Takoyaki.TextureNo = 3;
                        else if (item.Takoyaki.TextureNo == 2)
                            item.Takoyaki = null;
                    }
                }
            }
        }
        void PressingLeftButton()
        {
        }
    }
}