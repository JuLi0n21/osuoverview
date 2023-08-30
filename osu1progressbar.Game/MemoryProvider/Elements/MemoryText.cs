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
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Framework.Localisation;
using osu.Framework.Logging;
using osu.Game.Resources;
using OsuMemoryDataProvider.OsuMemoryModels;
using osuTK.Graphics;
using osuTK.Platform.Egl;
using Veldrid;
using static System.Net.Mime.MediaTypeNames;

namespace osu1progressbar.Game.MemoryProvider.Elements
{

    public partial class MemoryText : CompositeDrawable
    {
        private Container box;
        private OsuMemoryProvider memoryProvider;
        Bindable<OsuBaseAddresses> OsuBaseAddressesBindable;

        private SpriteText memoryText;
        private Beatmap beatmap;


        private TextFlowContainer textFlowContainer;

        private string datatext = "Text";
        private string ar = "";

        public MemoryText()
        {
            memoryProvider = new OsuMemoryProvider("osu!");
            memoryProvider.ReadDelay = 1;
            OsuBaseAddressesBindable = memoryProvider.OsuBaseAddressesBindable;
            RelativeSizeAxes = Axes.Both;
            Origin = Anchor.Centre;
            // Masking = true;

            InternalChild = box = new Container
            {
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopLeft,
                //Masking = true,
                Children = new Drawable[]
                {
                    new Box
                    {
                        Colour = Color4.Black,
                        RelativeSizeAxes = Axes.Both,
                    },
                    textFlowContainer = new TextFlowContainer
                    {
                        Text = memoryProvider.GetAllDataJson(),
                         Anchor = Anchor.TopLeft,
                    },

                    beatmap = new Beatmap()
                    {
                        Y = 20,
                      Anchor = Anchor.TopLeft,
                      Origin = Anchor.Centre,
                    },
                },
                

            };

            datatext = "Text 3";
            textFlowContainer.Text = datatext;

        }

        
        private void updateText()
        {
            beatmap.SetidSpriteText.Text = "Setid: " + OsuBaseAddressesBindable.Value.Beatmap.MapString;
            beatmap.MapstringSpriteText.Text = "Mapstring: " + OsuBaseAddressesBindable.Value.Beatmap.MapString;
            beatmap.FoldernameSpriteText.Text = "Foldername: " + OsuBaseAddressesBindable.Value.Beatmap.FolderName;
            beatmap.OsufilenameSpriteText.Text = "Osufilename: " + OsuBaseAddressesBindable.Value.Beatmap.OsuFileName;
            beatmap.Md5SpriteText.Text = "Md5: " + OsuBaseAddressesBindable.Value.Beatmap.Md5;
            beatmap.ArSpriteText.Text = "Ar: " + OsuBaseAddressesBindable.Value.Beatmap.Ar.ToString();
            beatmap.CsSpriteText.Text = "Cs: " + OsuBaseAddressesBindable.Value.Beatmap.Cs;
            beatmap.HpSpriteText.Text = "Hp: " + OsuBaseAddressesBindable.Value.Beatmap.Hp;
            beatmap.OdSpriteText.Text = "Od: " + OsuBaseAddressesBindable.Value.Beatmap.Od;
            beatmap.StatusSpriteText.Text = "Status: " + OsuBaseAddressesBindable.Value.Beatmap.Status;
        }

        [BackgroundDependencyLoader]
        private void Load(TextureStore textures)
        {

            memoryProvider.Run();
           // Logger.Log(OsuBaseAddressesBindable.Value.BanchoUser.Username);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            OsuBaseAddressesBindable.BindValueChanged(change => updateText(), true);
           // OsuBaseAddressesBindable.ValueChanged += chane => textFlowContainer.Text = chane.NewValue.ToString();
            
            
        }

    }
}
