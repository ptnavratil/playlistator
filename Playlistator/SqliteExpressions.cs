namespace Playlistator
{
    class SqliteExpressions
    {
        public static readonly string[] TableNames = { "songs", "tags", "songs_has_tags" };

        public const string CreateTableSongs = "CREATE TABLE IF NOT EXISTS `songs` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `song_name` TEXT NOT NULL UNIQUE, `author_name` TEXT NOT NULL, `filesystem_path` TEXT NOT NULL, `created` INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP )";
        public const string CreateTableTags = "CREATE TABLE IF NOT EXISTS `tags` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `name` TEXT NOT NULL UNIQUE, `description` TEXT, `created` INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP )";
        public const string CreateTableSongsHasTags = "CREATE TABLE IF NOT EXISTS `songs_has_tags` ( `song_id` INTEGER NOT NULL, `tag_id` INTEGER NOT NULL, `created` INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP, PRIMARY KEY(`song_id`,`tag_id`) )";

        public const string InsertTag = "INSERT INTO `tags` (name, description, created) VALUES ($name, $description, strftime('%s','now'))";
        public const string SelectAllTags = "SELECT id, name, description, created FROM `tags`;";

        public const string InsertSong = "INSERT INTO `songs` (song_name, author_name, filesystem_path, created) VALUES ($song_name, $author_name, $filesystem_path, strftime('%s','now'))";
        public const string SelectAllSongs = "select id, song_name, author_name, filesystem_path, created FROM `songs`";

        public const string InsertSongHasTag = "INSERT INTO `songs_has_tags` (song_id, tag_id, created) VALUES ($song_id, $tag_id, strftime('%s','now'))";
        public const string DeleteSongHasTag = "DELETE FROM `songs_has_tags` WHERE `song_id`=$song_id AND `tag_id`=$tag_id";

        public const string SelectTagIdsOfSelectedSong = "SELECT tag_id FROM songs_has_tags WHERE song_id = $song_id";

        /*
        public const string CheckTableSongs = "SELECT name FROM sqlite_master WHERE type='table' AND name='songs'";
        public const string CheckTableTags = "SELECT name FROM sqlite_master WHERE type='table' AND name='tags'";
        public const string CheckTableSongsHasTags = "SELECT name FROM sqlite_master WHERE type='table' AND name='songs_has_tags'";
        */
    }
}
