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
        public SpriteText UsernameSpriteText { get; private set; }
        public SpriteText HPSmoothSpriteText { get; private set; }
        public SpriteText HPSpriteText { get; private set; }
        public SpriteText AccuracySpriteText { get; private set; }
        public SpriteText MaxComboSpriteText { get; private set; }
        public SpriteText ScoreSpriteText { get; private set; }
        public SpriteText ScoreV2SpriteText { get; private set; }
        public SpriteText ComboSpriteText { get; private set; }
        public SpriteText Hit50SpriteText { get; private set; }
        public SpriteText Hit100SpriteText { get; private set; }
        public SpriteText Hit300SpriteText { get; private set; }
        public SpriteText HitErrorsSpriteText { get; private set; }
        public SpriteText HitGekiSpriteText { get; private set; }
        public SpriteText HitKatuSpriteText { get; private set; }
        public SpriteText HitMissSpriteText { get; private set; }
        public SpriteText IsReplaySpriteText { get; private set; }
        public SpriteText ModeSpriteText { get; private set; }
        public SpriteText ModsSpriteText { get; private set; }


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
                UsernameSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Username: ",
                },
                ScoreV2SpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Scorev2: ",
                },
                Hit50SpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Hit50: ",
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
                HitMissSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "HitMiss: ",
                },
                HitErrorsSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "HitErros: ",
                },
                HitKatuSpriteText= new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "HitKatu: ",
                },
                HitGekiSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "HitGeki: ",
                },
                IsReplaySpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "IsReplay: ",
                },
                HPSmoothSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
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
                ModeSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "Mode: "
                },
                ModsSpriteText = new SpriteText
                {
                    Y= offset += offsetdistance,
                    Text = "Mods: "
                },
                }
            };
        }
    }

}
