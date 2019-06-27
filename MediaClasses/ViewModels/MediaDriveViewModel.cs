using MediaClasses.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MediaClasses.ViewModels
{
    /// <summary>
    /// Represents a system hard drive used to stored a type of media files.
    /// </summary>
    public class MediaDrive
    {
        private DriveTypes _driveType;
        private char _driveLetter;
        private ShowAiringStatus _airing;
        private string _rootPath;
        private List<Tuple<char, DriveTypes, bool>> _drives = new List<Tuple<char, DriveTypes, bool>>();

        /// <summary>
        /// System drive letter of the hard drive
        /// </summary>
        public char? DriveLetter
        {
            get
            {
                return _driveLetter;
            }
            private set
            {
                _driveLetter = value.Value;

                foreach (Tuple<char, DriveTypes, bool> _mediaDrive in GetMediaDrives())
                {
                    if (_mediaDrive.Item1 == value)
                    {
                        DriveTypes _driveType = _mediaDrive.Item2;

                        if (_mediaDrive.Item3)
                        {
                            MediaAiringStatus = ShowAiringStatus.ACTIVE;
                        }
                        else
                        {
                            MediaAiringStatus = ShowAiringStatus.ENDED;
                        }
                    }
                }                
            } 
        }

        /// <summary>
        /// Status of whether the drive holds active shows or ended shows
        /// </summary>
        public ShowAiringStatus MediaAiringStatus
        {
            get
            {
                return _airing;
            }
            private set
            {
                if (true)
                {
                    _airing = value;
                }
            }
        }

        /// <summary>
        /// Type of media stored on the drive
        /// </summary>
        public DriveTypes DriveType {
            get
            {
                return _driveType;
            }
            private set
            {
                _driveType = value;

                switch (value)
                {
                    case DriveTypes.SORT:
                        {
                            MediaRootPath = @"S:\";

                            if (!DriveLetter.HasValue)
                            {
                                DriveLetter = MediaRootPath[0];
                            }

                            break;
                        }
                    case DriveTypes.TV:
                        {
                            if (!DriveLetter.HasValue)
                            {
                                throw new Exception("Drive letter must be set before choosing TV as the drive type.");
                            }

                            MediaRootPath = $@"{ DriveLetter }\TV Shows\";

                            break;
                        }
                    case DriveTypes.MOVIE:
                        {
                            MediaRootPath = $@"M:\Movies\";

                            if (!DriveLetter.HasValue)
                            {
                                DriveLetter = MediaRootPath[0];
                            }

                            break;
                        }
                    default:
                        {
                            MediaRootPath = null;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// The path to the root folder where media is stored on this drive
        /// </summary>
        public string MediaRootPath
        {
            get
            {
                return _rootPath;
            }
            private set
            {
                if (true)
                {
                    _rootPath = value;
                }
            }
        }

        /// <summary>
        /// Create a new instance of a media drive from a DirectoryInfo object.
        /// </summary>
        /// <param name="_info">DirectoryInfo object to use</param>
        public MediaDrive(DirectoryInfo _info)
        {
            DriveLetter = _info.FullName[0];

            _drives = GetMediaDrives();

            foreach (Tuple<char, DriveTypes, bool> _item in _drives)
            {
                if (_info.FullName[0] == _item.Item1)
                {
                    DriveType = _item.Item2;

                    if (_item.Item3)
                    {
                        MediaAiringStatus = ShowAiringStatus.ACTIVE;
                    }
                    else
                    {
                        MediaAiringStatus = ShowAiringStatus.ENDED;
                    }
                }
            }
        }

        /// <summary>
        /// Create a new instance of a media drive from a drive letter and DriveType
        /// </summary>
        /// <param name="_driveLetter">Drive letter to use</param>
        /// <param name="_driveType">DriveTypes.DriveType to use</param>
        public MediaDrive(char _driveLetter, DriveTypes _driveType)
        {
            _drives = GetMediaDrives();

            foreach (Tuple<char, DriveTypes, bool> _item in _drives)
            {
                if (_driveLetter == _item.Item1)
                {
                    DriveType = _item.Item2;

                    if (_item.Item3)
                    {
                        MediaAiringStatus = ShowAiringStatus.ACTIVE;
                    }
                    else
                    {
                        MediaAiringStatus = ShowAiringStatus.ENDED;
                    }
                }
            }
        }

        /// <summary>
        /// Create a new instance of a media drive from a file path as a string
        /// </summary>
        /// <param name="_mediaPath">string file path to use</param>
        public MediaDrive(string _mediaPath)
        {
            DriveLetter = _mediaPath[0];
            MediaRootPath = _mediaPath;

            _drives = GetMediaDrives();

            foreach (Tuple<char, DriveTypes, bool> _item in _drives)
            {
                if (DriveLetter == _item.Item1)
                {
                    DriveType = _item.Item2;

                    if (_item.Item3)
                    {
                        MediaAiringStatus = ShowAiringStatus.ACTIVE;
                    }
                    else
                    {
                        MediaAiringStatus = ShowAiringStatus.ENDED;
                    }
                }
            }
        }

        /// <summary>
        /// Create a new instance of a media drive.
        /// </summary>
        public MediaDrive()
        {
            _drives = GetMediaDrives();
        }

        /// <summary>
        /// Get a list of tuples representing media drives, with values for drive letter, media type, and media airing status.  
        /// </summary>
        /// <param name="_mediaType">Type of media stored on the drive.  Ignored if getting all types.</param>
        /// <param name="_getAllTypes">True if all drives should be returned or false if just ones with the specified media type </param>
        /// <returns>List of tuples containing drive letter, drive media type, and media airing status.</returns>
        public List<Tuple<char, DriveTypes, bool>> GetMediaDrives(DriveTypes? _mediaType = null, bool _getAllTypes = true)
        {
            if (_getAllTypes || _mediaType == null)
            {
                return _drives;
            }
            else
            {
                if (!_mediaType.HasValue)
                {
                    throw new Exception("You must specify a DriveTypes value if not retrieving drives of all types.");
                }
                else
                {
                    return _drives.Where(x => x.Item2 == _mediaType.Value).ToList();
                }                
            }
        }

        /// <summary>
        /// Get the media drives from the temporary static array, upgrade to database later on.
        /// </summary>
        /// <returns>List of tuples containing the drive letter, media type stored on the drive, and boolean determining if the drive stores active shows or not</returns>
        private List<Tuple<char, DriveTypes, bool>> GetMediaDrives()
        {
            List<Tuple<char, DriveTypes, bool>> _final = new List<Tuple<char, DriveTypes, bool>>();
            Tuple<char, DriveTypes, bool> drive1, drive2, drive3, drive4, drive5, drive6, drive7;

            drive1 = new Tuple<char, DriveTypes, bool>('E', DriveTypes.TV, true);
            drive2 = new Tuple<char, DriveTypes, bool>('F', DriveTypes.TV, true);
            drive3 = new Tuple<char, DriveTypes, bool>('G', DriveTypes.TV, false);
            drive4 = new Tuple<char, DriveTypes, bool>('H', DriveTypes.TV, false);
            drive5 = new Tuple<char, DriveTypes, bool>('I', DriveTypes.TV, false);
            drive6 = new Tuple<char, DriveTypes, bool>('M', DriveTypes.MOVIE, true);
            drive7 = new Tuple<char, DriveTypes, bool>('S', DriveTypes.SORT, true);

            _final.Add(drive1);
            _final.Add(drive2);
            _final.Add(drive3);
            _final.Add(drive4);
            _final.Add(drive5);
            _final.Add(drive6);
            _final.Add(drive7);

            return _final;
        }
    }
}
