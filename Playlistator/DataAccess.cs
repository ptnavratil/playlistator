using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using Windows.Storage;
using System.IO;

namespace Playlistator
{
    public static class DataAccess
    {
        private const string DatabaseFilename = "Playlistator.db";

        public async static void InsertSong() { }
        public async static void UpdateSong() { }
        public async static void DeleteSong() { }

        public async static void InsertTag() { }
        public async static void UpdateTag() { }
        public async static void DeleteTag() { }

        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync(DatabaseFilename, CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseFilename);
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
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

            }

        }

    }
}
