using System;

namespace FinalGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MainGames())
                game.Run();
        }
    }
}
