using AutoMapper;
using MediaClasses.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediaClasses.Classes
{
    /// <summary>
    /// Class representing the view model for a media file.  This is the base class for all others within SDN Media Server.
    /// </summary>
    public class MediaFile : IMediaFile, IDisposable
    {
        #region ######## Media File Object Properties ########
            /// <summary>
            /// Database ID for the entity
            /// </summary>
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
            /// DateTime object representing the creation date of the media file.  This can can reliably be used to determine the DateTime of when the file was downloaded.
            /// </summary>
            public DateTime FileCreated { get; set; }
        #endregion

        #region ######## Media File Object Constructors ########
            /// <summary>
            /// Create a new instance of the MediaFile class object.
            /// </summary>
            /// <param name="_file">Path to file used to populate properties.</param>
            public MediaFile(string _file)
            {
                FileInfo = new FileInfo(_file);
                FilePath = FileInfo.FullName;
                FileName = FileInfo.Name;
            
                FileSize = FileInfo.Length;
                FileRootDirectory = FileInfo.DirectoryName;
                FileCreated = FileInfo.CreationTime;
            }

            /// <summary>
            /// Create a new instance of the MediaFile class object.
            /// </summary>
            /// <param name="_file">FileInfo object reference used to populate properties.</param>
            public MediaFile(FileInfo _file)
        {
            FileInfo = _file;
            FilePath = FileInfo.FullName;
            FileName = FileInfo.Name;
            FileSize = FileInfo.Length;
            FileRootDirectory = FileInfo.DirectoryName;
            FileCreated = FileInfo.CreationTime;
        }

        #endregion

        #region ######## Media File Object Methods ########

            /// <summary>
            /// Get a view model of the data object.
            /// </summary>
            /// <returns>MediaFileViewModel representing the data object.</returns>
            public MediaFileViewModel GetViewModel()
            {
                return new MediaFileViewModel() { FileInfo = FileInfo, FilePath = FilePath, FileCreated = FileCreated, FileName = FileName, FileRootDirectory = FileRootDirectory, FileSize = FileSize };
            }

            /// <summary>
            /// Split the full path of the media file into a string array by the '\' character
            /// </summary>
            /// <param name="_path">string full path to the media file on the filesystem</param>
            /// <returns>Media file name as a string</returns>
            /// <example>
            /// string _path = @"C:\Documents\Media\TV\TestMedia.mkv";
            /// MediaFile _model = new MediaFile(_path)
            /// Console.WriteLine(_model.NameFromPath())
            /// 
            /// //This will output: TestMedia.mkv
            /// </example>
            private string NameFromPath(string _path)
            {
                return _path.Split('\\').Last();
            }

            /// <summary>
            /// Retrieve the file size in a specified format.  Default will return the file size in bytes.
            /// </summary>
            /// <param name="_format">enum value representing the unit of measurement to convert with. </param>
            /// <returns>file size in selected format.</returns>
            public double GetFileSize(SizeFormat? _format)
        {
            switch (_format)
            {
                case SizeFormat.KB:
                    {
                        return (FileInfo.Length / 1024);
                    }

                case SizeFormat.MB:
                    {
                        return (FileInfo.Length / 1048576);
                    }

                case SizeFormat.GB:
                    {
                        return (FileInfo.Length / 1073741824);
                    }

                case SizeFormat.TB:
                    {
                        return (FileInfo.Length / 1099511627776);
                    }

                default:
                    {
                        return FileInfo.Length;
                    }
            }
        }
            
            /// <summary>
            /// Disposes of object when no longer needed.
            /// </summary>
            public virtual void Dispose()
            {
                foreach (PropertyInfo _prop in GetType().GetProperties())
                {
                    _prop.SetValue(this, null);
                }

            }

        #endregion

        #region ######## Media File Object Enums ########
            /// <summary>
            /// Enum representing the different ways to display a file's size
            /// </summary>
            public enum SizeFormat
            {
                /// <summary>
                /// Format size to Kilobytes
                /// </summary>
                KB,

                /// <summary>
                /// Format size to Megabytes
                /// </summary>
                MB,

                /// <summary>
                /// Format size to Gigabytes
                /// </summary>
                GB,

                /// <summary>
                /// Format size to Terabytes
                /// </summary>
                TB
            }

            /// <summary>
            /// Enum representing valid extensions (file types) for media files
            /// </summary>
            public enum ValidMediaFileTypes
        {
            /// <summary>
            /// File of type Matroska Video
            /// </summary>
            MKV,

            /// <summary>
            /// File of type Windows Media Video
            /// </summary>
            WMV,

            /// <summary>
            /// File of type Audio Video Interleave
            /// </summary>
            AVI,

            /// <summary>
            /// File of type MPEG-4 Part 14
            /// </summary>
            MP4
        }
        #endregion
    }
}
