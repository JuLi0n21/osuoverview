using osu.Framework;
using osu.Framework.Platform;

namespace osu1progressbar.Game.Tests
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableDesktopHost("visual-tests"))
            using (var game = new osu1progressbarTestBrowser())
                host.Run(game);
        }
    }
}
