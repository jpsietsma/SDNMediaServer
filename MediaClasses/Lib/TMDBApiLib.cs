using MediaClasses.Classes.APIClasses;
using MediaClasses.Enum;
using MediaClasses.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MediaClasses.Lib
{
    /// <summary>
    /// Class for making requests to and from the TheMovieDB API.
    /// </summary>
    public static class TMDBApiLib
    {
        /// <summary>
        /// Find the show information on the searched string
        /// </summary>
        /// <param name="queryShowName">Show name to search</param>
        /// <param name="page">Get the results from a specified page, default is 1</param>
        /// <param name="apiKey">Developer API key for accessing TheMovieDB API and making requests</param>
        /// <returns>APISearchResults object with the results from the API query</returns>
        public static APISearchResults SearchShows(string queryShowName, int page = 1, string apiKey = @"c0604d69b7df230f03504bdc8475887a")
        {
            try
            {
                RestClient client = new RestClient($@"https://api.themoviedb.org/3/search/tv?page={ page }&query={ queryShowName }&language=en-US&api_key={ apiKey }");

                IRestRequest request = new RestRequest(Method.GET).AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var _results = JsonConvert.DeserializeObject<APISearchResults>(response.Content);

                foreach (APIResult _result in _results.results)
                {
                    if (_result.name == queryShowName)
                    {
                        _result.ExactMatch = true;
                    }
                }

                return _results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get a list of Television Show Genres
        /// </summary>
        /// <param name="apiKey">TheMovieDB developer API key</param>
        /// <returns>List of genre view models representing the genres available</returns>
        public static List<GenreViewModel> GetGenres(string apiKey = @"c0604d69b7df230f03504bdc8475887a")
        {
            try
            {
                RestClient client = new RestClient($@"https://api.themoviedb.org/3/genre/tv/list?api_key={ apiKey }&language=en-US");

                IRestRequest request = new RestRequest(Method.GET).AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var _results = JsonConvert.DeserializeObject<GenreApiResults>(response.Content);

                return _results.genres;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get a list of Television Show genres using the provided list of genre ids
        /// </summary>
        /// <param name="_genreIds">List of genre ids used to get view models</param>
        /// <param name="apiKey">TheMovieDB developer API key</param>
        /// <returns>List of genre view models populated with the results</returns>
        public static List<GenreViewModel> GetGenres(List<int> _genreIds, string apiKey = @"c0604d69b7df230f03504bdc8475887a")
        {
            List<GenreViewModel> _finalViewModels = new List<GenreViewModel>();

            try
            {
                RestClient client = new RestClient($@"https://api.themoviedb.org/3/genre/tv/list?api_key={ apiKey }&language=en-US");

                IRestRequest request = new RestRequest(Method.GET).AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var _results = JsonConvert.DeserializeObject<GenreApiResults>(response.Content);

                foreach (GenreViewModel _genre in _results.genres)
                {
                    if (_genreIds.Contains(_genre.id))
                    {
                        _finalViewModels.Add(_genre);
                    }
                }

                return _finalViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get the shows that are scheduled to air new episodes for today
        /// </summary>
        /// <param name="apiKey">TheMovieDB developer API key</param>
        /// <returns></returns>
        public static DailyAiringApiResult GetTodaysAiringShows(string apiKey = @"c0604d69b7df230f03504bdc8475887a")
        {
            try
            {
                RestClient client = new RestClient($@"https://api.themoviedb.org/3/tv/airing_today?api_key={ apiKey }&language=en-US&page=1");

                IRestRequest request = new RestRequest(Method.GET).AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var _results = JsonConvert.DeserializeObject<DailyAiringApiResult>(response.Content);

                return _results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Determine if a show is scheduled to air a new episode today
        /// </summary>
        /// <param name="showName">name of show to check</param>
        /// <param name="apiKey">TheMovieDB developer API key</param>
        /// <returns>true if show is scheduled to air new episode, false if not</returns>
        public static bool IsAiringToday(string showName, string apiKey = @"c0604d69b7df230f03504bdc8475887a")
        {
            try
            {
                RestClient client = new RestClient($@"https://api.themoviedb.org/3/tv/airing_today?api_key={ apiKey }&language=en-US&page=1");

                IRestRequest request = new RestRequest(Method.GET).AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var _results = JsonConvert.DeserializeObject<DailyAiringApiResult>(response.Content);

                foreach (DailyShowAiringViewModel _airingToday in _results.results)
                {
                    if (_airingToday.name.ToUpper() == showName.ToUpper())
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       

        /// <summary>
        /// Determine if a show is airing by querying a previous API call's results
        /// </summary>
        /// <param name="showName">Name of the show to search</param>
        /// <param name="_data">Results from prior api call to query</param>
        /// <returns>True if show is set to air today, otherwise false.</returns>
        public static bool IsAiringToday(string showName, DailyAiringApiResult _data = null)
        {
            if (_data != null)
            {
                foreach (DailyShowAiringViewModel _item in _data.results)
                {
                    if (_item.name == showName)
                    {
                        return true;
                    }
                }
            }           

            return false;
        }
    }
}
