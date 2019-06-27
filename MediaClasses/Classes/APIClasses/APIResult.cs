using MediaClasses.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaClasses.Classes.APIClasses
{
    public class APIResult
    {
        public string poster_path { get; set; }
        public double popularity { get; set; }
        public int id { get; set; }
        public string backdrop_path { get; set; }
        public double vote_average { get; set; }
        public string overview { get; set; }
        public string first_air_date { get; set; }
        public List<string> origin_country { get; set; }
        public List<int> genre_ids { get; set; }
        public string original_language { get; set; }
        public int vote_count { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public bool ExactMatch { get; set; }

        public APIResult(string jsonResult)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<APIResult>(jsonResult);

                poster_path = result.poster_path;
                popularity = result.popularity;
                id = result.id;
                backdrop_path = result.backdrop_path;
                vote_average = result.vote_average;
                overview = result.overview;
                first_air_date = result.first_air_date;
                origin_country = result.origin_country;
                genre_ids = result.genre_ids;
                original_language = result.original_language;
                vote_count = result.vote_count;
                name = result.name;
                original_name = result.original_name;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public APIResult(string jsonResult, string queryShowName)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<APIResult>(jsonResult);

                poster_path = result.poster_path;
                popularity = result.popularity;
                id = result.id;
                backdrop_path = result.backdrop_path;
                vote_average = result.vote_average;
                overview = result.overview;
                first_air_date = result.first_air_date;
                origin_country = result.origin_country;
                genre_ids = result.genre_ids;
                original_language = result.original_language;
                vote_count = result.vote_count;
                name = result.name;
                original_name = result.original_name;


                if (name == queryShowName)
                {
                    ExactMatch = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public APIResult()
        {

        }

        private TelevisionShowMetaData ToShowMetaData()
        {
            return new TelevisionShowMetaData(this)
            {

            };
        }

        /// <summary>
        /// Get a DailyShowAiringViewModel object representing the current api result
        /// </summary>
        /// <returns>DailyShowAiringViewModel representing the api result from the daily airing show feed.</returns>
        public DailyShowAiringViewModel ToShowViewModel()
        {
            return new DailyShowAiringViewModel { id = id, name = name, first_air_date = Convert.ToDateTime(first_air_date) };
        }

    }



}
