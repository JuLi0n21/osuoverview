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
 *   "KeyOverlay": {
    "Enabled": false,
    "K1Pressed": false,
    "K1Count": 0,
    "K2Pressed": false,
    "K2Count": 0,
    "M1Pressed": false,
    "M1Count": 0,
    "M2Pressed": false,
    "M2Count": 0
  }
*/

//AUTO GENERATED WITH CHAT GPT!!!
namespace osu1progressbar.Game.MemoryProvider.Elements
{
    partial class KeyOverlay: CompositeDrawable
    {
        public SpriteText EnabledSpriteText { get; private set; }
        public SpriteText K1PressedSpriteText { get; private set; }
        public SpriteText K1CountSpriteText { get; private set; }
        public SpriteText K2PressedSpriteText { get; private set; }
        public SpriteText K2CountSpriteText { get; private set; }
        public SpriteText M1PressedSpriteText { get; private set; }
        public SpriteText M1CountSpriteText { get; private set; }
        public SpriteText M2PressedSpriteText { get; private set; }
        public SpriteText M2CountSpriteText { get; private set; }

        private int offset = 0;
        private int offsetdistance = 15;

        public KeyOverlay()
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
                new SpriteText { Text = "KeyOverlay:", Colour = Color4.Goldenrod },
                EnabledSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Font = FontUsage.Default.With(size: 20),
                    Text = "Enabled: "
                },
                K1PressedSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "K1Pressed: ",
                },
                K1CountSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "K1Count: ",
                },
                K2PressedSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "K2Pressed: ",
                },
                K2CountSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "K2Count: ",
                },
                M1PressedSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "M1Pressed: ",
                },
                M1CountSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "M1Count: ",
                },
                M2PressedSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "M2Pressed: ",
                },
                M2CountSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "M2Count: ",
                },
                }
            };
        }
    }

}
