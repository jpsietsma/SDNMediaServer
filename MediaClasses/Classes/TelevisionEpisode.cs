using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MediaClasses.Classes
{
    /// <summary>
    /// Class representing a media file that has been classified as a Television Episode.  This is one of two base classes for classified sort items.
    /// </summary>
    public class TelevisionEpisode : MediaFile, IMediaFile, ITelevisionEpisode
    {
        #region ######## Properties ########
            /// <summary>
            /// Name of the Television Show this episode belongs to.
            /// </summary>
            public TelevisionShow TelevisionShow { get; set; }

            /// <summary>
            /// Name of the Television Season this episode belongs to.
            /// </summary>
            public TelevisionSeason TelevisionSeason { get; set; }
        #endregion

        #region ######## Constructors ########
            /// <summary>
            /// Create a new instance of the TelevisionEpisode object.  Television Episodes are one of two base classes for classified sort items.
            /// </summary>
            /// <param name="_file">string path to the episode file.</param>
            public TelevisionEpisode(string _file):base(_file)
            {

            }
       
            /// <summary>
            /// Create a new instance of the Television object.  Television Episodes are one of two base classes for classfied sort items.
            /// </summary>
            /// <param name="_file">FileInfo object related to the episode file.</param>
            public TelevisionEpisode(FileInfo _file):base(_file.FullName)
            {

            }
        #endregion
    }
}
