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

/*to add   "Beatmap": {
"Id": 2527236,
    "SetId": 1214274,
    "MapString": "Yamamoto Mineko - Cadena [Insane]",
    "FolderName": "1214274",
    "OsuFileName": "Yamamoto Mineko - Cadena (Kazato Asa) [Insane].osu",
    "Md5": "df4c60d0af3ac34681e79d3027a0b776",
    "Ar": 9.0,
    "Cs": 3.8,
    "Hp": 5.5,
    "Od": 8.0,
    "Status": 4

give box a max size as to not draw over the entire screen when shit goes japanese;
*/

namespace osu1progressbar.Game.MemoryProvider.Elements
{
    public partial class Beatmap : CompositeDrawable
    {
        private OsuBaseAddresses beatmap;
        private Container dragContainer;
        private Container beatmapContainer;


        private int offset = 0;
        private int offsetdistance = 15;

        public SpriteText SetidSpriteText { get;  set; }
        public SpriteText MapstringSpriteText { get; set; }
        public SpriteText FoldernameSpriteText { get; set; } //localliszed?
        public SpriteText OsufilenameSpriteText { get; set; }
        public SpriteText Md5SpriteText { get; set; } //hash?
        public SpriteText ArSpriteText { get; set; }
        public SpriteText CsSpriteText { get; set; }
        public SpriteText HpSpriteText { get; set; }
        public SpriteText OdSpriteText { get; set; }
        public SpriteText StatusSpriteText { get; set; } //ranked status

        public Beatmap()
        { 

        }

        [BackgroundDependencyLoader]
        private void load()
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
                    new SpriteText { Text = "Beatmap:", Colour = Color4.Goldenrod },
                    SetidSpriteText = new SpriteText
                    {
                    Y = offset += offsetdistance,
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Font = FontUsage.Default.With(size: 20),
                    Text = "Setid: "
                    },
                    MapstringSpriteText = new SpriteText
                    {
                        Y = offset += offsetdistance, Text = "MapString: ",
                    },
                    FoldernameSpriteText = new SpriteText
                    {
                        Y = offset += offsetdistance,
                        Text = "Foldername: ",
                    },
                    OsufilenameSpriteText = new SpriteText
                    {
                        Y = offset += offsetdistance,
                        Text = "Osufilename: ",
                    },
                    Md5SpriteText = new SpriteText
                    {
                        Y = offset += offsetdistance,
                        Text = "MD5: ",
                    },
                    ArSpriteText = new SpriteText
                    {
                        Y = offset += offsetdistance,
                        Text = "AR: ",
                    },
                    CsSpriteText = new SpriteText
                    {
                        Y = offset += offsetdistance,
                        Text = "CS: ",
                    },
                    HpSpriteText = new SpriteText
                    {
                        Y = offset += offsetdistance,
                        Text = "HP: ",
                    },
                    OdSpriteText = new SpriteText
                    {
                        Y = offset += offsetdistance,
                        Text = "OD: ",
                    },
                    StatusSpriteText = new SpriteText
                    {
                        Y = offset += offsetdistance,
                        Text = "Status",
                    },
                }
            };
        }
    }
}
