using System;

namespace MiniGames
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリー ポイントです。
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                using (MiniGame game = new MiniGame())
                {
                    game.Run();
                }
            }
            catch (Microsoft.Xna.Framework.GamerServices.GamerServicesNotAvailableException e)
            {
                System.Windows.Forms.MessageBox.Show("hoge");

            }
        }
    }
#endif
}

