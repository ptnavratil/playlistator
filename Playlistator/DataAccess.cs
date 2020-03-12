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
    // Tutorial SQLite in UWP https://docs.microsoft.com/en-us/windows/uwp/data-access/sqlite-databases
    public static class DataAccess
    {
        private const string CreateTableSongs = "";
        private const string CreateTableTags = "";
        private const string CreateTableSongsTagsRel = "";

        public async static void InsertSong() { }
        public async static void UpdateSong() { }
        public async static void DeleteSong() { }

        public async static void InsertTag() { }
        public async static void UpdateTag() { }
        public async static void DeleteTag() { }

        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("sqliteSample.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(2048) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
    }
}
