using System;
using System.Collections.Generic;

namespace WebUI.DatabaseContext
{
    public partial class MediaDrives : IMediaDrives
    {
        public int PkDriveId { get; set; }
        public string DriveLetter { get; set; }
        public string DriveMediaType { get; set; }
        public string MediaLibraryPath { get; set; }
    }
}
