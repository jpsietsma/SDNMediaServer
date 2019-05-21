using MediaClasses.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static MediaClasses.Enum.SortEnums;

namespace MediaClasses.Classes
{
    /// <summary>
    /// Class representing a media file in the sort folder, not yet classified into a TelevisionEpisode
    /// </summary>
    public class SortMediaFile : MediaFile, ISortMediaFile
    {
        #region ######## Properties ########
            /// <summary>
            /// Full path to the file
            /// </summary>
            public new string FilePath { get; set; }

            /// <summary>
            /// Name of the show this media file is an episode belonging to
            /// </summary>
            public string ShowName { get; set; }

            /// <summary>
            /// Season number this media file episode belongs to
            /// </summary>
            public string ShowSeason { get; set; }

            /// <summary>
            /// Does the folder for the season exist on the filesystem?
            /// </summary>
            public bool SeasonExists { get; set; }

            /// <summary>
            /// Full file path to the season folder
            /// </summary>
            public string SeasonPath { get; set; }

            /// <summary>
            /// Has this sort file been scanned and classified?
            /// </summary>
            public bool IsClassified { get; set; }

            /// <summary>
            /// Classification of the file after being scanned
            /// </summary>
            public SortTypeClassification Classification { get; set; }

            /// <summary>
            /// Is this sort file a valid television episode?
            /// </summary>
            public bool ValidEpisodeFile { get; set; }

            /// <summary>
            /// Is this sort file a valid movie file?
            /// </summary>
            public bool ValidMovieFile { get; set; }

            /// <summary>
            /// Full file path value split by the '\' character.
            /// </summary>
            public string[] FilePathParts { get; set; }
        #endregion

        #region ######## Constructors ########
            /// <summary>
            /// New instance of a SortMediaFile object
            /// </summary>
            /// <param name="_file">Full file path to the media file.</param>
            public SortMediaFile(string _file):base(_file)
            {
                FilePathParts = SplitFullPath(FileInfo.FullName);
            }

            /// <summary>
            /// New instance of a SortMediaFile object
            /// </summary>
            /// <param name="_file">FileInfo object of the media file.</param>
            public SortMediaFile(FileInfo _file):base(_file)
            {
                FilePathParts = SplitFullPath(FileInfo.FullName);
            }

            /// <summary>
            /// New instance of a SortMediaFile object
            /// </summary>
            /// <param name="_file"></param>
            public SortMediaFile(IMediaFile _file):base(new FileInfo(_file.FilePath))
            {
                FilePathParts = SplitFullPath(FileInfo.FullName);
            }
        #endregion

        #region ######## Object Methods ########
            /// <summary>
            /// Split the full path of the media file by the '\' character
            /// </summary>
            /// <param name="_path">string full filesystem path to the file.</param>
            /// <returns></returns>
            public string[] SplitFullPath(string _path)
            {
                return _path.Split('\\');
            }

            /// <summary>
            /// Split the full path of the media file by the '\' character
            /// </summary>
            /// <param name="_file">FileInfo object representing our file</param>
            /// <returns></returns>
            public string[] SplitFullPath(FileInfo _file)
            {
                return _file.FullName.Split('\\');
            }
        #endregion

    }
}
