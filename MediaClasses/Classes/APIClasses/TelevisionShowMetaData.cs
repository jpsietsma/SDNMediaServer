﻿using MediaClasses.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MediaClasses.Classes.APIClasses
{

    public partial class TelevisionShowMetaData : APIResult
    {
        [DisplayName("PosterPath")]
        public string poster_path { get; set; }

        public int id { get; set; }

        public string overview { get; set; }

        [DisplayName("StartDate")]
        public string first_air_date { get; set; }
                
        public List<int> genre_ids { get; set; }

        public List<GenreViewModel> genres { get; set; }

        [DisplayName("ShowName")]
        public string name { get; set; }

        public bool ExactMatch { get; set; }

        public TelevisionShow TelevisionShow { get; set; }
        public TelevisionSeason TelevisionSeason { get; set; }


        public TelevisionShowMetaData()
        {

        }

        public TelevisionShowMetaData(APIResult _metaData)
        {
            id = _metaData.id;
            genre_ids = _metaData.genre_ids;
            backdrop_path = _metaData.backdrop_path;
            first_air_date = _metaData.first_air_date;
            genre_ids = _metaData.genre_ids;
            name = _metaData.name;
            overview = _metaData.overview;
            poster_path = _metaData.poster_path;

            genres.AddRange(GetGenres(genre_ids));

        }

        private List<GenreViewModel> GetGenres(string apiKey = @"c0604d69b7df230f03504bdc8475887a")
        {
            try
            {
                RestClient client = new RestClient($@"https://api.themoviedb.org/3/genre/tv/list?api_key={ apiKey }&language=en-US");

                IRestRequest request = new RestRequest(Method.GET).AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var _results = JsonConvert.DeserializeObject<List<GenreViewModel>>(response.Content);

                return _results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<GenreViewModel> GetGenres(List<int> _genreIds, string apiKey = @"c0604d69b7df230f03504bdc8475887a")
        {
            try
            {
                RestClient client = new RestClient($@"https://api.themoviedb.org/3/genre/tv/list?api_key={ apiKey }&language=en-US");

                IRestRequest request = new RestRequest(Method.GET).AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var _results = JsonConvert.DeserializeObject<List<GenreViewModel>>(response.Content);
                List<string> _matchingGenreNames = new List<string>();

                foreach (GenreViewModel _genre in _results)
                {
                    if (!_genreIds.Contains(_genre.id))
                    {
                        _results.Remove(_genre);
                    }
                }

                return _results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }


}