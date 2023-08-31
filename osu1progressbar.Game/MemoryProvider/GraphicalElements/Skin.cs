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

/*   "Skin": {
    "Folder": "Badeu 2018-09-05"
  },
*/

//AUTO GENERATED WITH CHAT GPT!!!
namespace osu1progressbar.Game.MemoryProvider.Elements
{
    partial class Skin: CompositeDrawable
    {
        public SpriteText FolderSpriteText { get; private set; }

        public Box Box;

        private int offset = 0;
        private int offsetdistance = 15;

        public Skin()
        {
             
        }

        [BackgroundDependencyLoader]
        private void Load()
        {
            InternalChild = new Container
            {
                AutoSizeAxes = Axes.Both,
                //RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Masking = true,
                Children = new Drawable[]
                {
                Box = new Box
                {
                    Colour = Color4.SteelBlue,
                    RelativeSizeAxes = Axes.Both,
                },
                new SpriteText { Text = "Skin:", Colour = Color4.Goldenrod },
                FolderSpriteText = new SpriteText
                {
                    Y = offset += offsetdistance,
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Font = FontUsage.Default.With(size: 20),
                    Text = "Folder: "
                },
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
           // box.Colour = Color4.White;

        }

        //something something with the axes maybe idk not sure why not workies
        protected override bool OnHover(HoverEvent e)
        {
            Box.Colour = Color4.Green;  
            return base.OnHover(e);
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            Box.Colour = Color4.Red;
            base.OnHoverLost(e);
        }
    }

}
