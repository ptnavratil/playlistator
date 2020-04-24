using System;

namespace Playlistator.Model
{
    public class Tag
    {
        #region Constants
        #endregion //Constants

        #region Attributes
        private DateTime created;
        #endregion //Attributes

        #region Constructors
        public Tag() {}

        public Tag(long id, string name, string description, long created)
        {
            Id = id;
            Name = name;
            Description = description;
            Created = Utils.UnixTimeToDateTime(created);
        }
        #endregion //Constructors

        #region Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
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
            return obj is Tag tag &&
                   Id == tag.Id;
        }
        #endregion //Public Methods

        #region Private Methods
        #endregion //Private Methods

        #region Inner/Nested Types
        #endregion //Inner/Nested Types
    }
}
