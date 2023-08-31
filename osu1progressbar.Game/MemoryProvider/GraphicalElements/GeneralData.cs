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
       "GeneralData": {
    "RawStatus": 0,
    "GameMode": 0,
    "Retries": 0,
    "AudioTime": 34146,
    "TotalAudioTime": 252841.42857142858,
    "ChatIsExpanded": false,
    "Mods": 0,
    "ShowPlayingInterface": true,
    "OsuVersion": "b20230814cuttingedge",
    "OsuStatus": 0
  },
*/

//AUTO GENERATED WITH CHAT GPT!!!
namespace osu1progressbar.Game.MemoryProvider.Elements
{
    partial class GeneralData : CompositeDrawable
    {
        public SpriteText RawStatusSpriteText { get; private set; }
        public SpriteText GameModeSpriteText { get; private set; }
        public SpriteText RetriesSpriteText { get; private set; }
        public SpriteText AudioTimeSpriteText { get; private set; }
        public SpriteText TotalAudioTimeSpriteText { get; private set; }
        public SpriteText ChatIsExpandedSpriteText { get; private set; }
        public SpriteText ModsSpriteText { get; private set; }
        public SpriteText ShowPlayingInterfaceSpriteText { get; private set; }
        public SpriteText OsuVersionSpriteText { get; private set; }
        public SpriteText OsuStatusSpriteText { get; private set; }

        private int offset = 0;
        private int offsetdistance = 15;

        public GeneralData()
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
                new SpriteText { Text = "GeneralData:", Colour = Color4.Goldenrod },
                RawStatusSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Font = FontUsage.Default.With(size: 20),
                    Text = "RawStatus: "
                },
                GameModeSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "GameMode: ",
                },
                RetriesSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Retries: ",
                },
                AudioTimeSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "AudioTime: ",
                },
                TotalAudioTimeSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "TotalAudioTime: ",
                },
                ChatIsExpandedSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "ChatIsExpanded: ",
                },
                ModsSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Mods: ",
                },
                ShowPlayingInterfaceSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "ShowPlayingInterface: ",
                },
                OsuVersionSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "OsuVersion: ",
                },
                OsuStatusSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "OsuStatus: ",
                },
                }
            };
        }
    }

}
