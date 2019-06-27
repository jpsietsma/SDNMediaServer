using MediaClasses.Enum;
using MediaClasses.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaClasses.Lib
{
    /// <summary>
    /// Class for dealing with various functions and processes regarding media libraries and file storeage within the system
    /// </summary>
    public static class LibraryStorageLib
    {

        /// <summary>
        /// Get the available space on a system hard drive used to store media
        /// </summary>
        /// <returns>decimal representing available space in MB</returns>
        public static decimal GetAvailableDriveSpace(MediaDrive _drive)
        {
            decimal _final = 0.00M;            

            return _final;
        }

        /// <summary>
        /// Check if the Drive with the matching supplied letter has the correct DriveTypes value
        /// </summary>
        /// <param name="_driveLetter">Letter of the MediaDrive to check</param>
        /// <param name="_type">Expected DriveTypes value of the drive represented by the letter</param>
        /// <returns>True if drive represented by letter has the provided DriveTypes value, otherwise false.</returns>
        public static bool IsCorrectDriveType(char _driveLetter, DriveTypes _type)
        {
            bool _IsCorrectType = false;

                //do some code

            return _IsCorrectType;
        }

        /// <summary>
        /// Check if the supplied MediaDrive holds the correct ShowAiringStatus value.  Also set out decimal variable to MB of space remaining.
        /// </summary>
        /// <param name="_drive">MediaDrive object to check</param>
        /// <param name="_status">Expected ShowAiringStatus value of MediaDrive object</param>
        /// <param name="_remainingSpace">Out decimal to hold available space on MediaDrive object.</param>
        /// <returns>True is correct type, otherwise false.</returns>
        public static bool IsCorrectDriveAiringType(MediaDrive _drive, ShowAiringStatus _status, out decimal _remainingSpace)
        {
            if (_drive.MediaAiringStatus == _status)
            {
                _remainingSpace = 0.00M;
                return true;
            }

            _remainingSpace = 0.00M;
            return false;
        }
    }
}
