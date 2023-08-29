using osu.Framework.Platform;
using osu.Framework;
using osu1progressbar.Game;

namespace osu1progressbar.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost(@"osu1progressbar"))
            using (osu.Framework.Game game = new osu1progressbarGame())
                host.Run(game);
        }
    }
}
