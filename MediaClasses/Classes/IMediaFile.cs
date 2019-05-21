using System;
using System.IO;

namespace MediaClasses.Classes
{
    /// <summary>
    /// Represents any type of media file in any state within the system.  Base interface for all media files
    /// </summary>
    public interface IMediaFile
    {
        /// <summary>
        /// DateTime file was created.  This can be used to reliably determine the exact moment the download for the file completed.
        /// </summary>
        DateTime FileCreated { get; set; }

        /// <summary>
        /// String of the full path to the file on the filesystem.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Name of the file.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Parent folder of the file.
        /// </summary>
        string FileRootDirectory { get; set; }

        /// <summary>
        /// Size of the file on disk in bytes
        /// </summary>
        long FileSize { get; set; }

    }
}