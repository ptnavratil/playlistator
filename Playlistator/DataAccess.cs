using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using Windows.Storage;
using System.IO;
using System.Diagnostics;

namespace Playlistator
{
    public static class DataAccess
    {
        //FIXME neotvirat DB connection pri kazde akci na novo, ale udrzovat po celou dobu behu aplikace

        private const string DatabaseFilename = "Playlistator.db";
        private static readonly string DatabasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseFilename);

        //FIXME potreba tyto metody predelat aby neco vracely

        public async static void InsertSong() { }
        public async static void UpdateSong() { }
        public async static void DeleteSong() { }

        public static bool InsertTag(string name, string description)
        {

            using (SqliteConnection db = new SqliteConnection($"Filename={DatabasePath}"))
            {
                db.Open();

                SqliteCommand insertTagCommand = new SqliteCommand(SqliteExpressions.InsertTag, db);
                insertTagCommand.Parameters.AddWithValue("$name", name);
                insertTagCommand.Parameters.AddWithValue("$description", description);

                try
                {
                    int numOfAffectedRows = insertTagCommand.ExecuteNonQuery();
                    if (numOfAffectedRows == 1)
                    {
                        Debug.WriteLine("Tag successfully inserted.", "OK");
                        return true;
                    }
                }
                catch (SqliteException e)
                {
                    Debug.WriteLine($"{e.SqliteErrorCode}:{e.Message}", "ERROR");
                    return false;
                }
                return false;
            }
        }

        public async static void UpdateTag() { }
        public async static void DeleteTag() { }

        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync(DatabaseFilename, CreationCollisionOption.OpenIfExists);
            //string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseFilename);
            using (SqliteConnection db = new SqliteConnection($"Filename={DatabasePath}"))
            {
                db.Open();

                SqliteCommand createTableTags = new SqliteCommand(SqliteExpressions.CreateTableTags, db);
                createTableTags.ExecuteReader();

                SqliteCommand createTableSongs = new SqliteCommand(SqliteExpressions.CreateTableSongs, db);
                createTableSongs.ExecuteReader();

                SqliteCommand createTableSongsHasTags = new SqliteCommand(SqliteExpressions.CreateTableSongsHasTags, db);
                createTableSongsHasTags.ExecuteReader();
            }
        }

        public async static void CheckTables()
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseFilename);
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand createTableTags = new SqliteCommand(SqliteExpressions.CreateTableTags, db);
                //TODO nedokonceno - melo by otestovat jesli soubor s databazi obsahuje pozadovane tabulky
            }

        }

    }
}
