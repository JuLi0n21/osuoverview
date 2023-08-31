using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using System.Data.SQLite;
using osu.Framework.Logging;
using Markdig.Extensions.Tables;
using OsuMemoryDataProvider.OsuMemoryModels;

namespace osu1progressbar.Game.Database
{
    public class DatabaseController
    {
        private readonly string dbname = null;
        private readonly string connectionString = "Data Source=osu!progress.db;Version=3;";

        public DatabaseController()
        {

        }

        public bool Init()
        {


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    createTables(connection);

                }
                catch (Exception e)
                {
                    Logger.Log(e.ToString());
                    return false;
                }
                finally
                {
                    connection.Close();
                }


                return true;
            }

        }

        public bool SaveScore()
        {
            //saving a score and specific hit events, consider calling everytime user stops playing a map 
            return true;
        }

        public bool LoadScore()
        {
            // for datavisulisation idk maybe
            return true;
        }

        public void Updateplaytimes()
        {
            //updaste times user spend in a specific mode based on RawStatus or OsuStatus. 
        }

        private void createTables(SQLiteConnection connection)
        {

            //Hiterros should be recalculated into UR
            string createScoreTableQuery = @"
                CREATE TABLE IF NOT EXISTS ScoreData (
                    BeatmapSetid TEXT,
                    Beatmapid TEXT,
                    Osufilename TEXT,
                    Ar TEXT,
                    Cs TEXT,
                    Hp TEXT,
                    Od TEXT,
                    Username TEXT,
                    Accuracy TEXT,
                    MaxCombo TEXT,
                    Score TEXT,
                    Combo TEXT,
                    Hit50 TEXT,
                    Hit100 TEXT,
                    Hit300 TEXT,
                    Ur TEXT,
                    HitMiss TEXT,
                    Mode TEXT,
                    Mods TEXT
                );
            ";

            using (var command = new SQLiteCommand(createScoreTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            Logger.Log("Database Created: " + dbname);

            string timeSpendTableQuery = @"
                CREATE TABLE IF NOT EXISTS ";

            string query = "SELECT name FROM sqlite_master WHERE type='table';";
            using (var command = new SQLiteCommand(query, connection))
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tableName = reader.GetString(0);
                    Logger.Log(tableName);
                }
            }

        }

        public void InsertScore(OsuBaseAddresses baseAddresses)
        {

            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertQuery = @"
                    INSERT INTO ScoreData ( BeatmapSetid,
                    Beatmapid,
                    Osufilename,
                    Ar,
                    Cs,
                    Hp,
                    Od,
                    Username,
                    Accuracy,
                    MaxCombo,
                    Score,
                    Combo,
                    Hit50,
                    Hit100,
                    Hit300,
                    Ur,
                    HitMiss,
                    Mode,
                    Mods
                    ) VALUES (
                            @BeatmapSetid,
                            @Beatmapid,
                            @Osufilename,
                            @Ar,
                            @Cs,
                            @Hp,
                            @Od,
                            @Username,
                            @Accuracy,
                            @MaxCombo,
                            @Score,
                            @Combo,
                            @Hit50,
                            @Hit100,
                            @Hit300,
                            @Ur,
                            @HitMiss,
                            @Mode,
                            @Mods
                        );
                    ";

                    float ur = 100; // calculate ur here.

                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@BeatmapSetid", baseAddresses.Beatmap.SetId);
                        command.Parameters.AddWithValue("@Beatmapid", baseAddresses.Beatmap.Id);
                        command.Parameters.AddWithValue("@Osufilename", baseAddresses.Beatmap.OsuFileName);
                        command.Parameters.AddWithValue("@Ar", baseAddresses.Beatmap.Ar);
                        command.Parameters.AddWithValue("@Cs", baseAddresses.Beatmap.Cs);
                        command.Parameters.AddWithValue("@Hp", baseAddresses.Beatmap.Hp);
                        command.Parameters.AddWithValue("@Od", baseAddresses.Beatmap.Od);
                        command.Parameters.AddWithValue("@Username", baseAddresses.Player.Username);
                        command.Parameters.AddWithValue("@Accuracy", baseAddresses.Player.Accuracy);
                        command.Parameters.AddWithValue("@MaxCombo", baseAddresses.Player.MaxCombo);
                        command.Parameters.AddWithValue("@Score", baseAddresses.Player.Score);
                        command.Parameters.AddWithValue("@Combo", baseAddresses.Player.Combo);
                        command.Parameters.AddWithValue("@Hit50", baseAddresses.Player.Hit50);
                        command.Parameters.AddWithValue("@Hit100", baseAddresses.Player.Hit100);
                        command.Parameters.AddWithValue("@Hit300", baseAddresses.Player.Hit300);
                        command.Parameters.AddWithValue("@Ur", ur.ToString());
                        command.Parameters.AddWithValue("@HitMiss", baseAddresses.Player.HitMiss);
                        command.Parameters.AddWithValue("@Mode", baseAddresses.Player.Mode);
                        command.Parameters.AddWithValue("@Mods", baseAddresses.Player.Mods);

                        command.ExecuteNonQuery();
                    }

                    Logger.Log("Saved Score: ");

                }
                catch (Exception e)
                {
                    Logger.Log(e.ToString());

                }
                finally
                {
                    connection.Close();
                }
            }

        }

    }
}
