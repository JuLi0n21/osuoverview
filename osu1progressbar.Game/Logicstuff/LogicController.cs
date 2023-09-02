using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet.Protocol;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osu.Framework.Logging;
using osu1progressbar.Game.Database;
using osu1progressbar.Game.MemoryProvider;
using OsuMemoryDataProvider.OsuMemoryModels;


//add retry detection and save scroe
namespace osu1progressbar.Game.Logicstuff
{
    public class LogicController
    {
        private DatabaseController db;

        string CurrentScreen = null;
        int oldRawStatus = -1;
        string BanchoUserStatus = null;

        private Stopwatch screenTimeStopWatch;
        private Stopwatch userTimeStopWatch;
        Stopwatch stopwatch;
        public LogicController()
        {
            db = new DatabaseController();
            db.Init();

            screenTimeStopWatch = new Stopwatch();
            screenTimeStopWatch.Start();

            userTimeStopWatch = new Stopwatch();
            userTimeStopWatch.Start();

            stopwatch = Stopwatch.StartNew();
        }

        public void Logiccheck(OsuBaseAddresses NewValues) {

            string oldvalue = NewValues.ToString();

           // Logger.Log(NewValues.GeneralData.OsuStatus.ToString());

            if (CurrentScreen == "Playing" && NewValues.GeneralData.OsuStatus.ToString() == "SongSelect")
            {
                Logger.Log("Song Failed detected");
               // Logger.Log(NewValues.Beatmap.ToJson().ToString());
                //Logger.Log(NewValues.Player.ToJson().ToString());
                db.InsertScore(NewValues);
            }

            if (CurrentScreen == "Playing" && NewValues.GeneralData.OsuStatus.ToString() == "ResultsScreen")
            {
                Logger.Log("Song Passed detected");
               // Logger.Log(NewValues.Beatmap.ToJson().ToString());
               // Logger.Log(NewValues.Player.ToJson().ToString());
                db.InsertScore(NewValues);

            }

            if(CurrentScreen != NewValues.GeneralData.OsuStatus.ToString())
            {
                Logger.Log("Spend: " + (DateTime.Now + " :" + screenTimeStopWatch.ElapsedMilliseconds) + "ms in: " + CurrentScreen);
                //     Logger.Log("Spend: " + (System.DateTime.Now + " :" + screenTimeStopWatch.ElapsedMilliseconds / 1000) + "s in: " + CurrentScreen
                // pass old value not new one
                db.UpdateTimeWasted(oldRawStatus, screenTimeStopWatch.ElapsedMilliseconds);
                screenTimeStopWatch.Restart();
            }

            //BANCHO TIMES
            if (BanchoUserStatus != NewValues.BanchoUser.BanchoStatus.ToString())
            {
                //is a bit "inkonsistent" maybe using audio time is a better idea.

                //loading screens get added as playing time 
                Logger.Log("Spend: " + (DateTime.Now + " :" +  screenTimeStopWatch.ElapsedMilliseconds) + "ms as: " + BanchoUserStatus);
                // Logger.Log("Spend: " + (System.DateTime.Now + " :" + screenTimeStopWatch.ElapsedMilliseconds / 1000) + "s as: " + BanchoUserStatus);
                userTimeStopWatch.Restart();
                //db.UpdateBanchoTime(NewValues, screenTimeStopWatch.ElapsedMilliseconds);
            }

            CurrentScreen = NewValues.GeneralData.OsuStatus.ToString();
            BanchoUserStatus = NewValues.BanchoUser.BanchoStatus.ToString();
            oldRawStatus = NewValues.GeneralData.RawStatus;

                if (stopwatch.ElapsedMilliseconds > 1000)
                {
                    DateTime from = DateTime.Now;
                   from = from.Subtract(TimeSpan.FromDays(2));
                    DateTime to = DateTime.Now;
                   //  Logger.Log(from.ToString("yyyy-MM-dd HH:mm"));
                   //  Logger.Log(to.ToString("yyyy-MM-dd HH:mm"));
                   db.GetScores(from, to).ForEach(score =>
                    {
                        Logger.Log(score.ToJson().ToString());
                    });

                    stopwatch.Restart();
                }
            
        }
    }
}
