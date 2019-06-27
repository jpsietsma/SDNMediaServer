using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MediaClasses.Classes
{
    /// <summary>
    /// A class used to hold genre data from an api result
    /// </summary>
    public class MediaGenreViewModel
    {
        /// <summary>
        /// TheMovieDB.org genre id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Display name of the genre
        /// </summary>
        public string name { get; set; }
    }
}
