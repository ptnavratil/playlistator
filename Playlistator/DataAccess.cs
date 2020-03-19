using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;
using System.Diagnostics;

using Playlistator.Model;

namespace Playlistator
{
    public static class DataAccess
    {
        //FIXME neotvirat DB connection pri kazde akci na novo, ale udrzovat po celou dobu behu aplikace

        private const string DatabaseFilename = "Playlistator.db";
        private static readonly string DatabasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseFilename);

        //FIXME potreba tyto metody predelat aby neco vracely

        public async static void InsertSong() { throw new NotImplementedException(); }
        public async static void UpdateSong() { throw new NotImplementedException(); }
        public async static void DeleteSong() { throw new NotImplementedException(); }

        public static IList<Tag> SelectAllTags()
        {
            IList<Tag> listOfTags = new List<Tag>();
            using (SqliteConnection db = new SqliteConnection($"Filename={DatabasePath}"))
            {
                db.Open();

                SqliteCommand selectAllTagsCommand = new SqliteCommand(SqliteExpressions.SelectAllTags, db);

                try
                {
                    SqliteDataReader reader = selectAllTagsCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        long tagId = (long)reader["id"];
                        string tagName = (string)reader["name"];
                        string tagDescription = (string)reader["description"];
                        long tagCreated = (long)reader["created"];

                        listOfTags.Add(new Tag(tagId, tagName, tagDescription, tagCreated));
                    }
                    reader.Close();
                }
                catch (SqliteException e)
                {
                    Debug.WriteLine($"{e.SqliteErrorCode}:{e.Message}", "ERROR");
                }
            }
            return listOfTags;
        }

        public static IList<Song> SelectAllSongs()
        {
            IList<Song> listOfSongs = new List<Song>();
            using (SqliteConnection db = new SqliteConnection($"Filename={DatabasePath}"))
            {
                db.Open();

                SqliteCommand selectAllSongsCommand = new SqliteCommand(SqliteExpressions.SelectAllSongs, db);

                try
                {
                    SqliteDataReader reader = selectAllSongsCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        long songId = (long)reader["id"];
                        string songName = (string)reader["name"];
                        string authorName = (string)reader["description"];
                        string filesystemPath = (string)reader["filesystem_path"];
                        long songCreated = (long)reader["created"];

                        listOfSongs.Add(new Song(songId, songName, authorName, filesystemPath, songCreated));
                    }
                    reader.Close();
                }
                catch (SqliteException e)
                {
                    Debug.WriteLine($"{e.SqliteErrorCode}:{e.Message}", "ERROR");
                }
            }
            return listOfSongs;

        }

        public static bool InsertTag(Tag tag)
        {

            using (SqliteConnection db = new SqliteConnection($"Filename={DatabasePath}"))
            {
                db.Open();

                SqliteCommand insertTagCommand = new SqliteCommand(SqliteExpressions.InsertTag, db);
                insertTagCommand.Parameters.AddWithValue("$name", tag.Name);
                insertTagCommand.Parameters.AddWithValue("$description", tag.Description);

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

        public static bool InsertSong(Song song)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename={DatabasePath}"))
            {
                db.Open();

                SqliteCommand insertSongCommand = new SqliteCommand(SqliteExpressions.InsertSong, db);
                insertSongCommand.Parameters.AddWithValue("$song_name", song.SongName);
                insertSongCommand.Parameters.AddWithValue("$author_name", song.AuthorName);
                insertSongCommand.Parameters.AddWithValue("$filesystem_path", song.FilesystemPath);

                try
                {
                    int numOfAffectedRows = insertSongCommand.ExecuteNonQuery();
                    if (numOfAffectedRows == 1)
                    {
                        Debug.WriteLine("Song successfully inserted.", "OK");
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

        public static bool AddTagToSong(Song song)
        {
            throw new NotImplementedException();
        }



        public async static void UpdateTag() { throw new NotImplementedException(); }
        public async static void DeleteTag() { throw new NotImplementedException(); }

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
