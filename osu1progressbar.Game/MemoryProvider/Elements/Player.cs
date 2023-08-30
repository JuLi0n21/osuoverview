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
     "Player": {
    "HPSmooth": 0.0,
    "HP": 0.0,
    "Accuracy": 0.0,
    "HitErrors": null,
    "IsReplay": false,
    "Username": null,
    "Mods": {
      "ModsXor1": 0,
      "ModsXor2": 0,
      "Value": 0
    },
    "Mode": 0,
    "MaxCombo": 0,
    "Score": 0,
    "ScoreV2": 0,
    "Hit100": 0,
    "Hit300": 0,
    "Hit50": 0,
    "HitGeki": 0,
    "HitKatu": 0,
    "HitMiss": 0,
    "Combo": 0
  },
*/

//AUTO GENERATED WITH CHAT GPT!!!
namespace osu1progressbar.Game.MemoryProvider.Elements
{
    partial class Player : CompositeDrawable
    {
        public SpriteText HPSmoothSpriteText { get; private set; }
        public SpriteText HPSpriteText { get; private set; }
        public SpriteText AccuracySpriteText { get; private set; }
        public SpriteText MaxComboSpriteText { get; private set; }
        public SpriteText ScoreSpriteText { get; private set; }
        public SpriteText ComboSpriteText { get; private set; }

        private int offset = 0;
        private int offsetdistance = 15;

        public Player()
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
                new SpriteText { Text = "Player:", Colour = Color4.Goldenrod },
                HPSmoothSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Font = FontUsage.Default.With(size: 20),
                    Text = "HPSmooth: "
                },
                HPSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "HP: ",
                },
                AccuracySpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Accuracy: ",
                },
                MaxComboSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "MaxCombo: ",
                },
                ScoreSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Score: ",
                },
                ComboSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Combo: ",
                },
                }
            };
        }
    }

}
