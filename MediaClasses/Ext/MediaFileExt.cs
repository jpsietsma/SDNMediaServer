using MediaClasses.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaClasses.Ext
{
    /// <summary>
    /// Class to extend functionality of the MediaFile class.
    /// </summary>
    public static class MediaFileExt
    {
        /// <summary>
        /// Convert this MediaFile object to a SortMediaFile object
        /// </summary>
        /// <param name="_file">MediaFile to convert</param>
        /// <returns>Converted SortMediaFile object</returns>
        public static SortMediaFile ToSort( this MediaFile _file)
        {
            return new SortMediaFile(_file);
        }
    }
}
