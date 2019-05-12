using MediaClasses.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaClasses.Lib
{
    /// <summary>
    /// Class to convert between media classes.
    /// </summary>
    public static class MediaConversion
    {
        /// <summary>
        /// Convert SortMediaFile object into TelevisionEpisode object.
        /// </summary>
        /// <param name="_sortFile">Sort file to convert</param>
        /// <returns>Converted TelevisionEpisode object</returns>
        public static TelevisionEpisode ToEpisode(ISortMediaFile _sortFile)
        {
            return new TelevisionEpisode(_sortFile.FilePath);
        }

        /// <summary>
        /// Convert MediaFile object into SortMediaFile object.
        /// </summary>
        /// <param name="_mediaFile">Media file to convert</param>
        /// <returns>Converted SortMediaFile object</returns>
        public static SortMediaFile ToSort(IMediaFile _mediaFile)
        {
            return new SortMediaFile(_mediaFile);
        }

    }
}
