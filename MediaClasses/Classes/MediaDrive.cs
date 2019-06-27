using MediaClasses.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUI.DatabaseContext
{
    /// <summary>
    /// Class that represents a database record for a media drive in the system.
    /// </summary>
    public partial class MediaDrive : IMediaDrive
    {
        /// <summary>
        /// Database PK of the record for the drive/
        /// </summary>
        [Key]
        public int PkDriveId { get; set; }

        /// <summary>
        /// The system drive letter, ie C, D, etc.
        /// </summary>
        [Description("The System drive letter.")]
        public string DriveLetter { get; set; }

        /// <summary>
        /// The type of media stored on the drive, usually Television or Movies.
        /// </summary>
        [Description("Type of media files held on this drive.")]
        public string DriveMediaType { get; set; }

        /// <summary>
        /// The path to the directory on the drive where the media type is stored.
        /// </summary>
        [Description("The path to the directory on the drive where the media files are held.")]
        public string MediaLibraryPath { get; set; }
    }
}
