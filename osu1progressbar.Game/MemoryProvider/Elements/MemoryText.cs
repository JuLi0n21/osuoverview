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
using OsuMemoryDataProvider.OsuMemoryModels.Direct;
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
        private BanchoUser banchoUser;
        private GeneralData generalData;
        private KeyOverlay keyOverlay;
        private LeaderBoard leaderBoard;
        private Player player;
        private ResultsScreen resultsScreen;
        private Skin skin;
        private SongSelectionScores songSelectionScores;


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
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                //Masking = true,
                Children = new Drawable[]
                {
                    beatmap = new Beatmap()
                    {
                        Y = 600,
                      Anchor = Anchor.TopLeft,
                      Origin = Anchor.TopLeft,
                    },

                    banchoUser = new BanchoUser()
                    {
                        Y = 0,
                        X = 1000,
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft,
                    },
                    generalData = new GeneralData()
                    {
                         Y = 0,
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft,
                    },
                    keyOverlay = new KeyOverlay()
                    {
                        Y = 200,
                        X = 0,
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft,
                    },
                    leaderBoard = new LeaderBoard()
                    {
                         X = 300,
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft,
                    },
                    player = new Player() {
                        X = 300,
                         Y = 100,
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft,
                    },
                    resultsScreen   = new ResultsScreen() {
                        X = 300,
                         Y = 300,
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft,
                    },
                    skin    = new Skin() {
                        X = 300,
                         Y = 250,
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft,
                    },
                    songSelectionScores = new SongSelectionScores() {
                        X = 600,
                         Y = 0,
                        Anchor = Anchor.TopLeft,
                        Origin = Anchor.TopLeft,
                    },
                }
            };
        }

        
        private void updateText()
        {

            // Consider updating freqently changing parts in a seperate call to not do uselesss shit mulitple times.

            // SOME ARE MISSING WHY U STUPID BOT

            
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

            banchoUser.IsLoggedInSpriteText.Text = "IsLoggedIn: " + OsuBaseAddressesBindable.Value.BanchoUser.IsLoggedIn;
            banchoUser.UsernameSpriteText.Text = "Username: " + OsuBaseAddressesBindable.Value.BanchoUser.Username;
            banchoUser.UserIdSpriteText.Text = "UserId: " + OsuBaseAddressesBindable.Value.BanchoUser.UserId;
            banchoUser.UserCountrySpriteText.Text = "UserCountry: " + OsuBaseAddressesBindable.Value.BanchoUser.UserCountry;
            banchoUser.UserPpAccLevelSpriteText.Text = "UserPpAccLevel: " + OsuBaseAddressesBindable.Value.BanchoUser.UserPpAccLevel;
            banchoUser.BanchoStatusSpriteText.Text = "BanchoStatus: " + OsuBaseAddressesBindable.Value.BanchoUser.BanchoStatus;

            generalData.RawStatusSpriteText.Text = "RawStatus: " + OsuBaseAddressesBindable.Value.GeneralData.RawStatus;
            generalData.GameModeSpriteText.Text = "GameMode: " + OsuBaseAddressesBindable.Value.GeneralData.GameMode;
            generalData.RetriesSpriteText.Text = "Retries: " + OsuBaseAddressesBindable.Value.GeneralData.Retries;
            generalData.AudioTimeSpriteText.Text = "AudioTime: " + OsuBaseAddressesBindable.Value.GeneralData.AudioTime;
            generalData.TotalAudioTimeSpriteText.Text = "TotalAudioTime: " + OsuBaseAddressesBindable.Value.GeneralData.TotalAudioTime;
            generalData.ChatIsExpandedSpriteText.Text = "ChatIsExpanded: " + OsuBaseAddressesBindable.Value.GeneralData.ChatIsExpanded;
            generalData.ModsSpriteText.Text = "Mods: " + OsuBaseAddressesBindable.Value.GeneralData.Mods;
            generalData.ShowPlayingInterfaceSpriteText.Text = "ShowPlayingInterface: " + OsuBaseAddressesBindable.Value.GeneralData.ShowPlayingInterface;
            generalData.OsuVersionSpriteText.Text = "OsuVersion: " + OsuBaseAddressesBindable.Value.GeneralData.OsuVersion;
            generalData.OsuStatusSpriteText.Text = "OsuStatus: " + OsuBaseAddressesBindable.Value.GeneralData.OsuStatus;

            keyOverlay.EnabledSpriteText.Text = "Enabled: " + OsuBaseAddressesBindable.Value.KeyOverlay.Enabled;
            keyOverlay.K1PressedSpriteText.Text = "K1Pressed: " + OsuBaseAddressesBindable.Value.KeyOverlay.K1Pressed;
            keyOverlay.K1CountSpriteText.Text = "K1Count: " + OsuBaseAddressesBindable.Value.KeyOverlay.K1Count;
            keyOverlay.K2PressedSpriteText.Text = "K2Pressed: " + OsuBaseAddressesBindable.Value.KeyOverlay.K2Pressed;
            keyOverlay.K2CountSpriteText.Text = "K2Count: " + OsuBaseAddressesBindable.Value.KeyOverlay.K2Count;
            keyOverlay.M1PressedSpriteText.Text = "M1Pressed: " + OsuBaseAddressesBindable.Value.KeyOverlay.M1Pressed;
            keyOverlay.M1CountSpriteText.Text = "M1Count: " + OsuBaseAddressesBindable.Value.KeyOverlay.M1Count;
            keyOverlay.M2PressedSpriteText.Text = "M2Pressed: " + OsuBaseAddressesBindable.Value.KeyOverlay.M2Pressed;
            keyOverlay.M2CountSpriteText.Text = "M2Count: " + OsuBaseAddressesBindable.Value.KeyOverlay.M2Count;

            player.HPSmoothSpriteText.Text = "HPSmooth: " + OsuBaseAddressesBindable.Value.Player.HPSmooth;
            player.HPSpriteText.Text = "HP: " + OsuBaseAddressesBindable.Value.Player.HP;
            player.AccuracySpriteText.Text = "Accuracy: " + OsuBaseAddressesBindable.Value.Player.Accuracy;
            player.MaxComboSpriteText.Text = "MaxCombo: " + OsuBaseAddressesBindable.Value.Player.MaxCombo;
            player.ScoreSpriteText.Text = "Score: " + OsuBaseAddressesBindable.Value.Player.Score;
            player.ComboSpriteText.Text = "Combo: " + OsuBaseAddressesBindable.Value.Player.Combo;

            resultsScreen.UsernameSpriteText.Text = "Username: " + OsuBaseAddressesBindable.Value.ResultsScreen.Username;
            resultsScreen.MaxComboSpriteText.Text = "MaxCombo: " + OsuBaseAddressesBindable.Value.ResultsScreen.MaxCombo;
            resultsScreen.ScoreSpriteText.Text = "Score: " + OsuBaseAddressesBindable.Value.ResultsScreen.Score;
            resultsScreen.ComboSpriteText.Text = "Combo: " + OsuBaseAddressesBindable.Value.ResultsScreen.Combo;
            resultsScreen.Hit100SpriteText.Text = "Hit100: " + OsuBaseAddressesBindable.Value.ResultsScreen.Hit100;
            resultsScreen.Hit300SpriteText.Text = "Hit300: " + OsuBaseAddressesBindable.Value.ResultsScreen.Hit300;
            resultsScreen.Hit50SpriteText.Text = "Hit50: " + OsuBaseAddressesBindable.Value.ResultsScreen.Hit50;
            resultsScreen.HitGekiSpriteText.Text = "HitGeki: " + OsuBaseAddressesBindable.Value.ResultsScreen.HitGeki;
            resultsScreen.HitKatuSpriteText.Text = "HitKatu: " + OsuBaseAddressesBindable.Value.ResultsScreen.HitKatu;
            resultsScreen.HitMissSpriteText.Text = "HitMiss: " + OsuBaseAddressesBindable.Value.ResultsScreen.HitMiss;



            skin.FolderSpriteText.Text = "Folder: " + OsuBaseAddressesBindable.Value.Skin.Folder;

            songSelectionScores.RankingTypeSpriteText.Text = "RankingType: " + OsuBaseAddressesBindable.Value.SongSelectionScores.RankingType;
            songSelectionScores.TotalScoresSpriteText.Text = "TotalScores: " + OsuBaseAddressesBindable.Value.SongSelectionScores.TotalScores;
            songSelectionScores.AmountOfScoresSpriteText.Text = "AmountOfScores: " + OsuBaseAddressesBindable.Value.SongSelectionScores.AmountOfScores;

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
