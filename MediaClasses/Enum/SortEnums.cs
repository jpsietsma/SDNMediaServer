using System;
using System.Collections.Generic;
using System.Text;

namespace MediaClasses.Enum
{
    /// <summary>
    /// Enums related to sort files
    /// </summary>
    public static class SortEnums
    {
        /// <summary>
        /// Enum whose values represent classification types of sort files.
        /// </summary>
        public enum SortTypeClassification
        {
            /// <summary>
            /// File has not yet been classified.
            /// </summary>
            SORT = 0,

            /// <summary>
            /// File has been classified as a Television Episode.
            /// </summary>
            TV = 1,

            /// <summary>
            /// File has been classified as a Movie file.
            /// </summary>
            MOVIE = 2
        }
    }
}
