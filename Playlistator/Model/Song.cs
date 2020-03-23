using System;

namespace Playlistator.Model
{
    public class Song
    {
        #region Constants
        #endregion //Constants

        #region Attributes
        private DateTime created;
        #endregion //Attributes

        #region Constructors
        public Song()
        {
        }

        public Song(long id, string songName, string authorName, string filesystemPath, long created)
        {
            Id = id;
            SongName = songName;
            AuthorName = authorName;
            FilesystemPath = filesystemPath;
            Created = new DateTime(created);
        }
        #endregion //Constructors

        #region Properties
        public long Id { get; set; }
        public string SongName { get; set; }
        public string AuthorName { get; set; }
        public string FilesystemPath { get; set; }
        public DateTime Created
        {
            get { return created; }
            set
            {
                created = value;
                CreatedString = Created.ToString("dd.MM.yyyy, HH:mm:ss");
            }
        }
        public string CreatedString { get; private set; }


        #endregion //Properties

        #region Public Methods
        public override bool Equals(object obj)
        {
            return obj is Song song &&
                   Id == song.Id;
        }
        #endregion //Public Methods

        #region Private Methods
        #endregion //Private Methods

        #region Inner/Nested Types
        #endregion //Inner/Nested Types
    }
}
