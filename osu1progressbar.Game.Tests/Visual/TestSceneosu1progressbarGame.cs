using osu.Framework.Allocation;
using osu.Framework.Platform;
using NUnit.Framework;

namespace osu1progressbar.Game.Tests.Visual
{
    [TestFixture]
    public partial class TestSceneosu1progressbarGame : osu1progressbarTestScene
    {
        // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
        // You can make changes to classes associated with the tests and they will recompile and update immediately.

        private osu1progressbarGame game;

        [BackgroundDependencyLoader]
        private void load(GameHost host)
        {
            game = new osu1progressbarGame();
            game.SetHost(host);

            AddGame(game);
        }
    }
}
