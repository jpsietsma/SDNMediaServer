using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MediaClasses.Classes
{
    public class TelevisionSeason : ITelevisionSeason
    {
        public string SeasonNumber { get; set; }
        public string SeasonShowName { get; set; }
        public string SeasonHomePath { get; set; }
        public char SeasonHomeDrive { get; set; }

        public List<TelevisionEpisode> SeasonEpisodes { get; set; } = new List<TelevisionEpisode>();

        public TelevisionSeason(string seasonHome)
        {
            SeasonHomePath = seasonHome;
            SeasonHomeDrive = SeasonHomePath[0];
            SeasonShowName = SeasonHomePath.Split('\\')[2];
            SeasonNumber = SeasonHomePath.Split('\\').Last().Replace("Season", "");

            foreach (string _episode in Directory.GetFiles(SeasonHomePath))
            {
                SeasonEpisodes.Add(new TelevisionEpisode(new FileInfo(_episode)));
            }

        }
    }
}
