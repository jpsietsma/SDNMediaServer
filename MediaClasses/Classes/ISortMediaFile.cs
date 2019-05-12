using System.IO;
using static MediaClasses.Enum.SortEnums;

namespace MediaClasses.Classes
{
    /// <summary>
    /// Class that represents a sort file.  Sort files have been scanned but not necessarily classified yet.
    /// </summary>
    public interface ISortMediaFile
    {
        /// <summary>
        /// Full path to the file
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Program media file classification type of file
        /// </summary>
        SortTypeClassification Classification { get; set; }

        /// <summary>
        /// String array of file parts split by 'SxxExx' in filename.  Used to determine show name, season number, and episode number.
        /// </summary>
        string[] FilePathParts { get; set; }

        /// <summary>
        /// Boolean has the file been classified yet?
        /// </summary>
        bool IsClassified { get; set; }

        /// <summary>
        /// Does the season folder exist?  If this is Episode 1 then we may have to create the season folder.
        /// </summary>
        bool SeasonExists { get; set; }

        /// <summary>
        /// The full filepath to the season folder
        /// </summary>
        string SeasonPath { get; set; }

        /// <summary>
        /// The show name as calculated strictly from the filename of the sort file.  This has not been verified or sanitized yet.
        /// </summary>
        string ShowName { get; set; }

        /// <summary>
        /// The show season as calculated strictly from the filename of the sort file.  This has not been verified or sanitized yet.
        /// </summary>
        string ShowSeason { get; set; }

        /// <summary>
        /// Is this a television show episode file?
        /// </summary>
        bool ValidEpisodeFile { get; set; }

        /// <summary>
        /// Is this a movie file?
        /// </summary>
        bool ValidMovieFile { get; set; }        

        /// <summary>
        /// Split the full filename into an array by the '\' character.
        /// </summary>
        /// <param name="_file">FileInfo object used to determine full file path.</param>
        /// <returns></returns>
        string[] SplitFullPath(FileInfo _file);

        /// <summary>
        /// Split the full filename into an array by the '\' character.
        /// </summary>
        /// <param name="_path">string full file path to the file.</param>
        /// <returns></returns>
        string[] SplitFullPath(string _path);
    }
}