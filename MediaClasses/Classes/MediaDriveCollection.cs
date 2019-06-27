using MediaClasses.Enum;
using MediaClasses.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaClasses.Classes
{
    /// <summary>
    /// Class that represents a collection of MediaDrive objects.
    /// </summary>
    public class MediaDriveCollection
    {
        private List<MediaDrive> _drives = new List<MediaDrive>();

        /// <summary>
        /// Collection of Media Drives being monitored by the SDN Media Server
        /// </summary>
        public List<MediaDrive> Drives { get; set; }

        /// <summary>
        /// Instantiate a new MediaDriveCollection object.
        /// </summary>
        public MediaDriveCollection()
        {
            Drives = new List<MediaDrive>();
        }
    }
}
