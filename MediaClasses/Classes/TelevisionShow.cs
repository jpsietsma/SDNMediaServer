using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MediaClasses.Classes
{
    public class TelevisionShow
    {
        public string ShowName { get; set; }
        public string ShowHomePath { get; set; }
        public int NumberOfSeasons { get; set; }
        public int NumberOfEpisodes { get; set; }

        public List<TelevisionSeason> ShowSeasons { get; set; } = new List<TelevisionSeason>();
        public List<TelevisionEpisode> ShowEpisodes { get; set; } = new List<TelevisionEpisode>();

        public TelevisionShow(string showDirectory)
        {
            ShowHomePath = showDirectory;
            ShowName = showDirectory.Split('\\').Last();
            NumberOfSeasons = Directory.GetDirectories(showDirectory).Count();
            NumberOfEpisodes = Directory.GetFiles(showDirectory, "*", SearchOption.AllDirectories).Count();

            List<string> dirs = Directory.GetDirectories(showDirectory).ToList();

            foreach (string _path in dirs)
            {
                ShowSeasons.Add(new TelevisionSeason(_path));
            }

            foreach (TelevisionSeason _season in ShowSeasons)
            {
                foreach (TelevisionEpisode _episode in _season.SeasonEpisodes)
                {
                    ShowEpisodes.Add(_episode);
                }
            }
        }


    }
}
