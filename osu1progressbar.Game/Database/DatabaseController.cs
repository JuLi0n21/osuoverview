using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace osu1progressbar.Game.Database
{
    internal class DatabaseController
    {
        public DatabaseController() {


        }

        public bool SaveScore() {
            //saving a score and specific hit events, consider calling everytime user stops playing a map 
            return true; }

        public bool LoadScore() {
            // for datavisulisation idk maybe
            return true; }

        public void Updateplaytimes() {
            //updaste times user spend in a specific mode based on RawStatus or OsuStatus. 
        }
    }
}
