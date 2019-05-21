using MediaClasses.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaClasses.ViewModels
{
    /// <summary>
    /// Class representing the view model for a media file.  This is the base class for all others within SDN Media Server.
    /// </summary>
    public class MediaFileViewModel : IMediaFile
    {
        /// <summary>
        /// Database ID for the entity record
        /// </summary>
        [Key]
        [Description()]
        public int Id { get; private set; }

        /// <summary>
        /// Name of the media file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Full file system path to the file.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Size of the media file in bytes
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// Root directory where the file resides
        /// </summary>
        public string FileRootDirectory { get; set; }

        /// <summary>
        /// Filesystem file info about the media file.
        /// </summary>
        public FileInfo FileInfo { get; set; }

        /// <summary>
        /// DateTime object representing the creation date of the media file.  This can reliably be used to determine the DateTime of when the file download was completed.
        /// </summary>
        public DateTime FileCreated { get; set; }

        /// <summary>
        /// Create a new instance of the MediaFileViewModel class object.
        /// </summary>
        /// <param name="_data">MediaFile object representing the scanned file</param>
        public MediaFileViewModel(MediaFile _data)
        {
            FileInfo = new FileInfo(_data.FilePath);
            FilePath = FileInfo.FullName;
            FileName = FileInfo.Name;                     
            FileSize = FileInfo.Length;
            FileRootDirectory = FileInfo.DirectoryName;
            FileCreated = FileInfo.CreationTime;

        }

        /// <summary>
        /// Create a new instance of the MediaFile class object.
        /// </summary>
        public MediaFileViewModel()
        {

        }

    }
}
