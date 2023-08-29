using osu.Framework.Testing;

namespace osu1progressbar.Game.Tests.Visual
{
    public partial class osu1progressbarTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new osu1progressbarTestSceneTestRunner();

        private partial class osu1progressbarTestSceneTestRunner : osu1progressbarGameBase, ITestSceneTestRunner
        {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete()
            {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}
