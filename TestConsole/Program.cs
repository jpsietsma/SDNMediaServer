using AutoMapper;
using MediaClasses.Classes;
using MediaClasses.Exceptions;
using MediaClasses.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using static MediaClasses.Config.Configuration;
using Newtonsoft.Json;
using MediaClasses.Classes.APIClasses;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //string _file = @"S:\Family.Guy.S17E17.Island.Adventure.720p.AMZN.WEB-DL.DD+5.1.H.264-CtrlHD[eztv].mkv";

            //MediaFile _model = new MediaFile(_file);

            //Console.WriteLine($@"######### File Information ##############");
            //Console.WriteLine();
            //Console.WriteLine($@"File Name: { _model.FileName }");
            //Console.WriteLine($@"File Size in b: {_model.GetFileSize(null)}");
            //Console.WriteLine($@"File Size in KB: {_model.GetFileSize(MediaFile.SizeFormat.KB)}");
            //Console.WriteLine($@"File Size in MB: {_model.GetFileSize(MediaFile.SizeFormat.MB)}");
            //Console.WriteLine($@"File Size in GB: {_model.GetFileSize(MediaFile.SizeFormat.GB)}");
            //Console.WriteLine();
            //Console.ReadLine();

            //Console.WriteLine(@"######### Program Configuration ##########");
            //Console.WriteLine();
            //Console.WriteLine($@"Sort Directory: { AppConfig.GetConfigurationSettings()["cfg_SortDirectory"] }");           
            //Console.WriteLine($@"Television Drives: ");

            //foreach (string _drive in AppConfig.GetConfigurationSettings()["cfg_TVDrives"] as List<string>)
            //    {
            //        Console.WriteLine($@"   -{ _drive }");
            //    }

            //Console.WriteLine($@"Movie Drives: ");

            //foreach (string _drive in AppConfig.GetConfigurationSettings()["cfg_MovieDrives"] as List<string>)
            //{
            //    Console.WriteLine($@"   -{ _drive }");
            //}

            //Console.WriteLine();
            //Console.WriteLine($@"######### Database Connection Settings ##########");
            //Console.WriteLine();
            //Console.WriteLine($@"Database Server: { AppConfig.GetConfigurationSettings()["cfg_SqlServer"] }");
            //Console.WriteLine($@"Database Name: { AppConfig.GetConfigurationSettings()["cfg_SqlDatabase"] }");
            //Console.WriteLine($@"Instance Name: { AppConfig.GetConfigurationSettings()["cfg_SqlInstance"] }");
            //Console.WriteLine();
            //Console.WriteLine($@"Connection String: { AppConfig.GetConfigurationSettings()["SQL_ConnectionString"] }");
            //Console.ReadLine();

            //SortMediaFile _sortFile = new SortMediaFile(_file);
            //var x =  _sortFile.GetType();

            //Console.WriteLine("######## Sort Object: ###########");
            //Console.WriteLine();

            //foreach (PropertyInfo item in _sortFile.GetType().GetProperties())
            //{
            //    if (item.Name == "FilePathParts")
            //    {
            //        Console.WriteLine("FileNameParts: ");
            //        string[] parts = item.GetValue(_sortFile) as string[];

            //        foreach (string part in parts)
            //        {
            //            Console.WriteLine($@"  -{ part }");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine($@"{ item.Name }: { item.GetValue(_sortFile) }");
            //    }                
            //}
            //Console.WriteLine();
            //Console.ReadLine();



            ////try
            ////{
            ////    throw new InvalidFileTypeException("pdf");
            ////}
            ////catch (InvalidFileTypeException ex)
            ////{
            ////    Console.WriteLine(ex.Message);
            ////}

            ////Console.ReadLine();


            //string showName = "Cops";

            //TelevisionShow _show = new TelevisionShow($@"E:\TV Shows\{ showName }");

            //Console.WriteLine($@"######## { _show.ShowName } Show Info ########");
            //Console.WriteLine();
            //Console.WriteLine($@"Home Folder: { _show.ShowHomePath }");
            //Console.WriteLine($@"# Seasons: { _show.NumberOfSeasons }");
            //Console.WriteLine($@"# Episodes: { _show.NumberOfEpisodes }");
            //Console.WriteLine($@"Show Seasons: ");

            //foreach (TelevisionSeason _season in _show.ShowSeasons)
            //{
            //    Console.WriteLine($@"  #### Season{ _season.SeasonNumber } ####");

            //    foreach (TelevisionEpisode _episode in _season.SeasonEpisodes)
            //    {
            //        Console.WriteLine($@"   [{ _episode.FileName }]");
            //    }

            //    Console.WriteLine();
            //}

            //Console.WriteLine();
            //Console.ReadLine();

            //List<string> _files = Directory.GetFiles(AppConfig.GetConfigurationSettings()["cfg_SortDirectory"] as string).ToList();
            //List<ISortMediaFile> _sortList = new List<ISortMediaFile>();

            //foreach (string _path in _files)
            //{
            //    _sortList.Add(new SortMediaFile(new FileInfo(_path)));
            //}

            //Console.ReadLine();



            //Console.Clear();
            //Console.WriteLine();
            //Console.WriteLine("############  Automapper Testing ############");
            //Console.WriteLine();

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile<MediaServerMapProfile>();
            //});


            //var y = new MediaFile(@"S:\Family.Guy.S17E17.Island.Adventure.720p.AMZN.WEB-DL.DD+5.1.H.264-CtrlHD[eztv].mkv");

            //Console.WriteLine($@"Beginning 'y' Type: { y.GetType() }");

            //var z = Mapper.Map<MediaFile, MediaFileViewModel>(y);

            //Console.WriteLine($@"Ending 'y' Type: { z.GetType() }");
            //Console.WriteLine();

            //foreach (var item in z.GetType().GetProperties())
            //{
            //    Console.WriteLine($@"{ item.Name }: { item.GetValue(z) }");
            //}

            //Console.WriteLine();
            //Console.ReadLine();
            //int w = 0;

            //for (int i = 0; i < 4000000; i++)            
            //{
            //    Console.Write(@"Scanning Files");
            //    Thread.Sleep(1000);
            //    Console.Write(@".");

            //    Thread.Sleep(1000);
            //    Console.Write(@".");

            //    Thread.Sleep(1000);
            //    Console.Write(@".");

            //    Thread.Sleep(1000);
            //    Console.Write(@".");

            //    Thread.Sleep(1000);
            //    Console.Write(@".");
            //    Console.Clear();

            //    w++;
            //}

            //Console.ReadLine();

            APISearchResults results = SearchShows(@"Cops");

            List<Genre> genres = GetGenres(new List<int>());

            Console.WriteLine(results.results.Where(x => x.ExactMatch == true).FirstOrDefault().name);       
            Console.ReadLine();

        }

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

        public static List<Genre> GetGenres(List<int> _genreIDs, string apiKey = @"c0604d69b7df230f03504bdc8475887a")
        {
            try
            {
                RestClient client = new RestClient($@"https://api.themoviedb.org/3/genre/tv/list?api_key={ apiKey }&language=en-US");

                IRestRequest request = new RestRequest(Method.GET).AddParameter("undefined", "{}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var _results = JsonConvert.DeserializeObject<List<Genre>>(response.Content);

                return _results;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
