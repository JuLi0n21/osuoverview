using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.ObjectExtensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Framework.Localisation;
using Veldrid;
using static System.Net.Mime.MediaTypeNames;

namespace osu1progressbar.Game.MemoryProvider.Elements
{

    public partial class MemoryText : CompositeDrawable
    {
        private Container box;
        private OsuMemoryProvider memoryProvider;
        private Bindable<OsuMemoryProvider> memoryproviderbindable;
        private SpriteText memoryText;

        private string datatext = "Text";

        public MemoryText()
        {
            memoryProvider = new OsuMemoryProvider("UHHhhH");
            memoryproviderbindable = new Bindable<OsuMemoryProvider>(memoryProvider);
            AutoSizeAxes = Axes.Both;
            Origin = Anchor.Centre;

            InternalChild = box = new Container
            {
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
               {
                memoryText = new SpriteText
                    {
                    Y = 200,
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Font = FontUsage.Default.With(size: 20),
                    Text = datatext,
                    }
               },

            };

            datatext = "Text 3";
            memoryText.Text = datatext;

        }

        [BackgroundDependencyLoader]
        private void Load(TextureStore textures)
        {

            memoryproviderbindable.Value.Run();

        }

        protected override void LoadComplete()
        {
            base.LoadComplete();


            datatext = "Text 2";

        }

        int i = 0;
        protected override bool OnScroll(ScrollEvent e)
        {
            // memoryproviderbindable.ValueChanged += change => memoryText.Text = change.NewValue.GetJsonData();

            memoryproviderbindable.TriggerChange();
            memoryText.Text = memoryproviderbindable.Value.GetJsonData() + i++;

            return base.OnScroll(e);
        }
    }
}
