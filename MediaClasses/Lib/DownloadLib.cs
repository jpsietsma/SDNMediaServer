using MediaClasses.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaClasses.Lib
{
    /// <summary>
    /// Static library for dealing with different aspects of downloads.
    /// </summary>
    public static class DownloadLib
    {
       
        /// <summary>
        /// Get the DateTime object that represents the completion time of the download of a sort media file.
        /// </summary>
        /// <param name="_filePath">string file path to the file to check</param>
        /// <returns>DateTime of the download completion if file has finished, otherwise null</returns>
        public static DateTime? GetCompletionDateTime(string _filePath)
        {
            string filepath = _filePath;

            DateTime? _final = null;
                                 
            if (_final.HasValue && !string.IsNullOrEmpty(filepath))
            {
                return _final.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get the DateTime object that represents the completion time of the download.
        /// </summary>
        /// <param name="_sortFile">SortMediaFile object to check</param>
        /// <returns>DateTime of the download completion if file has finished, otherwise null</returns>
        public static DateTime? GetCompletionDateTime(this SortMediaFile _sortFile)
        {
            string filepath = _sortFile.FilePath;

            DateTime? _final = null;

            if (_final.HasValue && !string.IsNullOrEmpty(filepath))
            {
                return _final.Value;
            }
            else
            {
                return null;
            }
        }



    }
}
