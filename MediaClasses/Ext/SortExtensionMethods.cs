using MediaClasses.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static MediaClasses.Config.Configuration;

namespace MediaClasses.Ext
{
    /// <summary>
    /// Methods to add additional functionality to SortMedia objects.
    /// </summary>
    public static class SortExtensionMethods
    {
        /// <summary>
        /// Check if the show this file belongs to exists on the server filesystem
        /// </summary>
        /// <param name="_file">SortMediaFile object representing the sort file to check</param>
        /// <returns>true if show exists.</returns>
        public static bool ShowExists(this SortMediaFile _file)
        {
            string _show = _file.FileName;
            string _showName = string.Empty; //Determine show name from the media file name - need to use regex in sortmediafile to explode out to property


            List<string> _drives = AppConfig.GetConfigurationSettings()["TelevisionDrives"] as List<string>;

            bool exists = false;

            foreach (string path in _drives)
            {               
                if (Directory.Exists(path + @"\TV Shows\" + _showName))
                {
                    exists = true;
                }
            }

            return exists;
        }
    }
}
