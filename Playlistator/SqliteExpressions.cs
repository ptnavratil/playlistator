namespace Playlistator
{
    class SqliteExpressions
    {
        // nepouzito
        public static readonly string[] TableNames = { "songs", "tags", "songs_has_tags" };

        #region Create tables
        public const string CreateTableSongs = "CREATE TABLE IF NOT EXISTS `songs` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `song_name` TEXT NOT NULL UNIQUE, `author_name` TEXT NOT NULL, `filesystem_path` TEXT NOT NULL, `created` INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP )";
        public const string CreateTableTags = "CREATE TABLE IF NOT EXISTS `tags` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `name` TEXT NOT NULL UNIQUE, `description` TEXT, `created` INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP )";
        public const string CreateTableSongsHasTags = "CREATE TABLE IF NOT EXISTS `songs_has_tags` ( `song_id` INTEGER NOT NULL, `tag_id` INTEGER NOT NULL, `created` INTEGER NOT NULL DEFAULT CURRENT_TIMESTAMP, PRIMARY KEY(`song_id`,`tag_id`) )";
        #endregion

        #region Tags
        public const string InsertTag = "INSERT INTO `tags` (name, description, created) VALUES ($name, $description, strftime('%s','now'))";
        public const string DeleteTag = "DELETE FROM `tags` WHERE `id`=$id";
        public const string SelectAllTags = "SELECT id, name, description, created FROM `tags` ORDER BY name ASC";
        #endregion

        #region Songs
        public const string InsertSong = "INSERT INTO `songs` (song_name, author_name, filesystem_path, created) VALUES ($song_name, $author_name, $filesystem_path, strftime('%s','now'))";
        public const string DeleteSong = "DELETE FROM `songs` WHERE `id`=$id";
        public const string SelectAllSongs = "SELECT id, song_name, author_name, filesystem_path, created FROM `songs` ORDER BY song_name ASC";

        public const string SelectAllSongsWithSpecifiedTag = "SELECT songs.id AS 'song_id', songs.song_name AS 'song_name', songs.author_name AS 'song_author_name', songs.filesystem_path AS 'song_filesystem_path', songs.created AS 'song_created' FROM songs JOIN songs_has_tags ON songs.id = songs_has_tags.song_id JOIN tags ON songs_has_tags.tag_id = tags.id WHERE tags.id=$tag_id";
        #endregion

        #region SongHasTag
        public const string InsertSongHasTag = "INSERT INTO `songs_has_tags` (song_id, tag_id, created) VALUES ($song_id, $tag_id, strftime('%s','now'))";
        public const string DeleteSongHasTag = "DELETE FROM `songs_has_tags` WHERE `song_id`=$song_id AND `tag_id`=$tag_id";
        public const string DeleteSongHasTagOfSpecifiedSong = "DELETE FROM `songs_has_tags` WHERE `song_id`=$song_id";
        public const string DeleteSongHasTagOfSpecifiedTag = "DELETE FROM `songs_has_tags` WHERE `tag_id`=$tag_id";
        public const string SelectTagIdsOfSelectedSong = "SELECT tag_id FROM songs_has_tags WHERE song_id =$song_id";
        #endregion

        /*
        public const string CheckTableSongs = "SELECT name FROM sqlite_master WHERE type='table' AND name='songs'";
        public const string CheckTableTags = "SELECT name FROM sqlite_master WHERE type='table' AND name='tags'";
        public const string CheckTableSongsHasTags = "SELECT name FROM sqlite_master WHERE type='table' AND name='songs_has_tags'";
        */
    }
}
