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

/*   "BanchoUser": {
    "IsLoggedIn": true,
    "Username": "JuLi0n_",
    "UserId": 14100399,
    "UserCountry": "Germany",
    "UserPpAccLevel": "Performance:5,405pp\nAccuracy:99.12%\nLv100",
    "BanchoStatus": 0
  },
*/

//AUTO GENERATED WITH CHAT GPT!!!
namespace osu1progressbar.Game.MemoryProvider.Elements
{
    public partial class BanchoUser : CompositeDrawable
    {
        public SpriteText IsLoggedInSpriteText { get; set; }
        public SpriteText UsernameSpriteText { get; set; }
        public SpriteText UserIdSpriteText { get; set; }
        public SpriteText UserCountrySpriteText { get; set; }
        public SpriteText UserPpAccLevelSpriteText { get; set; }
        public SpriteText BanchoStatusSpriteText { get; set; }

        private int offset = 0;
        private int offsetdistance = 15;

        public BanchoUser()
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
                    Colour = Color4.Teal,
                    RelativeSizeAxes = Axes.Both,
                },
                
                new SpriteText { Text = "BanchoUser:", Colour = Color4.Goldenrod },
                IsLoggedInSpriteText = new SpriteText { Text = "IsLoggedIn: ",  Y = offset += offsetdistance },
                UsernameSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Font = FontUsage.Default.With(size: 20),
                    Text = "Username: "
                },
                UserIdSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "UserId: ",
                },
                UserCountrySpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "UserCountry: ",
                },
                UserPpAccLevelSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "UserPpAccLevel: ",
                },
                BanchoStatusSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Text = "BanchoStatus: ",
                },
                }
            };
        }
    }

}
