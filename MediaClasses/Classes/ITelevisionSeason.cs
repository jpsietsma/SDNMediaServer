using System.Collections.Generic;

namespace MediaClasses.Classes
{
    public interface ITelevisionSeason
    {
        List<TelevisionEpisode> SeasonEpisodes { get; set; }
        string SeasonNumber { get; set; }
        string SeasonShowName { get; set; }
    }
}