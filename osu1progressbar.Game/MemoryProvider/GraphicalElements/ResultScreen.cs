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

/*    "ResultsScreen": {
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
  }
*/

//AUTO GENERATED WITH CHAT GPT!!!
namespace osu1progressbar.Game.MemoryProvider.Elements
{
    partial class ResultsScreen: CompositeDrawable
    {
        public SpriteText UsernameSpriteText { get; private set; }
        public SpriteText MaxComboSpriteText { get; private set; }
        public SpriteText ModsSpriteText { get; private set; }
        public SpriteText ModeSpriteText { get; private set; }
        public SpriteText ScoreSpriteText { get; private set; }
        public SpriteText ScoreV2SpriteText { get; private set; }
        public SpriteText ComboSpriteText { get; private set; }
        public SpriteText Hit100SpriteText { get; private set; }
        public SpriteText Hit300SpriteText { get; private set; }
        public SpriteText Hit50SpriteText { get; private set; }
        public SpriteText HitGekiSpriteText { get; private set; }
        public SpriteText HitKatuSpriteText { get; private set; }
        public SpriteText HitMissSpriteText { get; private set; }

        private int offset = 0;
        private int offsetdistance = 15;

        public ResultsScreen()
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
                new SpriteText { Text = "ResultsScreen:", Colour = Color4.Goldenrod },
                UsernameSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Font = FontUsage.Default.With(size: 20),
                    Text = "Username: "
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
                ScoreV2SpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "ScoreV2: ",
                },
                ComboSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Combo: ",
                },
                ModsSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Mods: ",
                },
                ModeSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Mode: ",
                },
                Hit100SpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Hit100: ",
                },
                Hit300SpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Hit300: ",
                },
                Hit50SpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Hit50: ",
                },
                HitGekiSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "HitGeki: ",
                },
                HitKatuSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "HitKatu: ",
                },
                HitMissSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "HitMiss: ",
                },
                }
            };
        }
    }

}
