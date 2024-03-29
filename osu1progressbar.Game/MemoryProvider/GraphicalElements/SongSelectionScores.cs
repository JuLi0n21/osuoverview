﻿using System;
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

/*  "SongSelectionScores": {
    "RankingType": 0,
    "TotalScores": 0,
    "MainPlayerScore": null,
    "AmountOfScores": null,
    "Scores": []
*/

//AUTO GENERATED WITH CHAT GPT!!!
namespace osu1progressbar.Game.MemoryProvider.Elements
{
    partial class SongSelectionScores: CompositeDrawable
    {
        public SpriteText RankingTypeSpriteText { get; private set; }
        public SpriteText TotalScoresSpriteText { get; private set; }
        public SpriteText AmountOfScoresSpriteText { get; private set; }

        public SpriteText MainPlayerScoreSpriteText { get; private set; }
        public SpriteText ScoresSpriteText { get; private set; }

        private int offset = 0;
        private int offsetdistance = 15;

        public SongSelectionScores()
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
                new SpriteText { Text = "SongSelectionScores:", Colour = Color4.Goldenrod },
                RankingTypeSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Font = FontUsage.Default.With(size: 20),
                    Text = "RankingType: "
                },
                TotalScoresSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "TotalScores: ",
                },
                AmountOfScoresSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "AmountOfScores: ",
                },
                 MainPlayerScoreSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "MainPlayerScore: ",
                },
                ScoresSpriteText = new SpriteText //is representated as an array rethink some other time TEHEE
                {
                       Y = offset += offsetdistance,
                       Text = "Scores: "
                },
                }
            };
        }
    }

}
