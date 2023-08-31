using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using OsuMemoryDataProvider;
using OsuMemoryDataProvider.OsuMemoryModels;
using osuTK.Graphics;


/* 
   "LeaderBoard": {
    "HasLeaderBoard": false,
    "MainPlayer": null,
    "AmountOfPlayers": null,
    "Players": []
  },
*/

//AUTO GENERATED WITH CHAT GPT!!!
namespace osu1progressbar.Game.MemoryProvider.Elements
{
    public partial class LeaderBoard: CompositeDrawable
    {
        public SpriteText HasLeaderBoardSpriteText { get; private set; }
        public SpriteText MainPlayerSpriteText { get; private set; }
        public SpriteText AmountOfPlayersSpriteText { get; private set; }

        private int offset = 0;
        private int offsetdistance = 15;

        public LeaderBoard()
        {
        }

        [BackgroundDependencyLoader]
        private void Load()
        {
            InternalChild = new Container
            {
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Masking = true,
                Children = new Drawable[]
                {
                new Box
                {
                    Colour = Color4.SteelBlue,
                    RelativeSizeAxes = Axes.Both,
                },
                new SpriteText { Text = "LeaderBoard:", Colour = Color4.Goldenrod },
                HasLeaderBoardSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Font = FontUsage.Default.With(size: 20),
                    Text = "HasLeaderBoard: "
                },
                MainPlayerSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "MainPlayer: ",
                },
                AmountOfPlayersSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "AmountOfPlayers: ",
                },
                }
            };
        }
    }

}
