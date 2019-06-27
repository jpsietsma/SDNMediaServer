using MediaClasses.Enum;
using MediaClasses.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MediaClasses.Lib
{
    /// <summary>
    /// Static class to handle sort processing and other sort folder functions.
    /// </summary>
    public static class SortProcessing
    {
        /// <summary>
        /// Does this show exist already on a media drive?
        /// </summary>
        /// <param name="showName">name of the show to search</param>
        /// <returns>true if show exists on a media drive, false if not</returns>
        public static bool IsExistingShow(string showName)
        {
            foreach (Tuple<char, DriveTypes, bool> _drivePath in GetMediaDrives())
            {
                string tvTmpExists = $@"{ _drivePath.Item1 }:\TV Shows\{ showName }";

                if ((_drivePath.Item2 == DriveTypes.TV) && (Directory.Exists(tvTmpExists)))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get a list of media drives, their media type, and media airing status (tv shows)
        /// </summary>
        /// <returns>List of tuple with drive letter, media type, and media airing status</returns>
        public static List<Tuple<char, DriveTypes, bool>> GetMediaDrives()
        {
            return new MediaDrive().GetMediaDrives();
        }


    }
}
