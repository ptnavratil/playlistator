using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlistator
{
    class SqliteExpressions
    {
        public static readonly string[] TableNames = { "songs", "tags", "songs_has_tags" };

        public const string CreateTableSongs = "CREATE TABLE IF NOT EXISTS `songs` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `song_name` TEXT NOT NULL UNIQUE, `author_name` TEXT NOT NULL, `filesystem_path` TEXT NOT NULL, `created` INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP )";
        public const string CreateTableTags = "CREATE TABLE IF NOT EXISTS `tags` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `name` TEXT NOT NULL UNIQUE, `description` TEXT, `created` INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP )";
        public const string CreateTableSongsHasTags = "CREATE TABLE IF NOT EXISTS `songs_has_tags` ( `song_id` INTEGER NOT NULL, `tag_id` INTEGER NOT NULL, `created` INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP, PRIMARY KEY(`song_id`,`tag_id`) )";

        public const string CheckTableSongs = "SELECT name FROM sqlite_master WHERE type='table' AND name='songs'";
        public const string CheckTableTags = "SELECT name FROM sqlite_master WHERE type='table' AND name='songs'";
        public const string CheckTableSongsHasTags = "SELECT name FROM sqlite_master WHERE type='table' AND name='songs'";
    }
}
