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
using NuGet.Protocol.Plugins;
using System.ComponentModel.Design;
using osu.Framework.Graphics.UserInterface;


//Add proper debug messages and levels...
//make it possible to retrive data 1. prepared stuff like, betweewn dates and or costuem request as a bonus maybe...
//refactor sometime to make it proper data types instead of text, maybe....
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
                    Logger.Log(e.ToString(), LoggingTarget.Database);
                    return false;
                }
                finally
                {
                    connection.Close();
                }


                return true;
            }

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

            Logger.Log("Database Created: " + dbname, LoggingTarget.Database);

            //think should be the times be based hourly or dayli?
            //how many rows of data is accpetable for this? needs test data 
            string timeSpendTableQuery = @"
                CREATE TABLE IF NOT EXISTS TimeWasted (Date TEXT ,RawStatus INTEGER, Time REAL)";

            using (var command = new SQLiteCommand(timeSpendTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            string query = "SELECT name FROM sqlite_master WHERE type='table';";
            using (var command = new SQLiteCommand(query, connection))
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tableName = reader.GetString(0);
                    Logger.Log(tableName, LoggingTarget.Database);
                }
            }

        }

        public void UpdateTimeWasted(OsuBaseAddresses baseAddresses, float timeElapsed) {
            DateTime time = DateTime.UtcNow;
            string date = time.Year + "-" + time.Month + "-" + time.Day + "-" + time.Hour;
            //Logger.Log(time.Hour.ToString(), LoggingTarget.Database);

            using (var connection = new SQLiteConnection(connectionString))
            {

                    connection.Open();
                 
                    using (SQLiteCommand command = new SQLiteCommand(connection)) {

                        command.CommandText = @"
                        Update TimeWasted Set Time = Time + @timeElapsed WHERE Date = @Date AND RawStatus = @RawStatus";
                        command.Parameters.AddWithValue("@timeElapsed", timeElapsed);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@RawStatus", baseAddresses.GeneralData.RawStatus);

                    int rowsUpdated = command.ExecuteNonQuery();

                        if (rowsUpdated == 0) {
                            using (SQLiteCommand insertCommand = new SQLiteCommand(connection))
                            {

                                insertCommand.CommandText = @"
                                INSERT INTO TimeWasted (Date ,RawStatus, Time
                                    ) VALUES (
                                        @Date, @RawStatus, @Time
                                    );
                                ";
    
                                insertCommand.Parameters.AddWithValue("@Date", date);
                                insertCommand.Parameters.AddWithValue("@RawStatus", baseAddresses.GeneralData.RawStatus);
                                insertCommand.Parameters.AddWithValue("@Time", timeElapsed);

                                insertCommand.ExecuteNonQuery();
                                Logger.Log("New TimeWasted Added for this hour", LoggingTarget.Database);
                            }
                        } else
                        {
                            Logger.Log("Updated TimeWasted in: " + baseAddresses.GeneralData.RawStatus + " time: " + timeElapsed, LoggingTarget.Database);
                        }
                    }
       
                connection.Close();
            }
        }

        //maybe consider passed or failed/canceld
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
                    //add DATE IMPORTANT POSSIBLY ALSO RETRY COUNT
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
                        command.Parameters.AddWithValue("@Mods", baseAddresses.Player.Mods.Value);

                        command.ExecuteNonQuery();
                    }

                    Logger.Log("Saved Score: ", LoggingTarget.Database,LogLevel.Debug);

                }
                catch (Exception e)
                {
                    Logger.Log(e.ToString(),LoggingTarget.Database);

                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public List<string> GetScores(DateTime from, DateTime to)
        {
            List<string> scores = new List<string>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                using (var command = new SQLiteCommand(connection))
                {

                    connection.Open();
                    //date is stroed as YYYY-MM-DD-HH -> turn into math somewhow and calculate if bettwen something
                    //uhhh change this sometimes no workies
                    command.CommandText = "SELECT * FROM TimeWasted WHERE datetime(Date, '%Y%m%d%H') BETWEEN @from AND @to;";

                    Logger.Log(from + " " + to);

                    command.Parameters.AddWithValue("@from", from.ToString());
                    command.Parameters.AddWithValue("@to", to.ToString());


                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        Logger.Log(reader.HasRows.ToString());

                        while (reader.Read())
                        {
                            string tableName = reader.GetString(0);
                            Logger.Log(tableName, LoggingTarget.Database);
                        }
                    }

                    connection.Close();

                }
                return scores;
            }
        }
    }
}
