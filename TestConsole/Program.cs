using AutoMapper;
using MediaClasses.Classes;
using MediaClasses.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using static MediaClasses.Config.Configuration;
using MediaClasses.Classes.APIClasses;
using MediaClasses.Lib;
using WebUI.Config.MappedProfiles;

namespace TestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            string showName = "Cops";

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
            //{
            //    Console.WriteLine($@"   -{ _drive }");
            //}

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
            //var x = _sortFile.GetType();

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

            APISearchResults results = TMDBApiLib.SearchShows(showName);
            List<GenreViewModel> genres = TMDBApiLib.GetGenres(results.results.First().genre_ids);
            DailyAiringApiResult allAiring = TMDBApiLib.GetTodaysAiringShows();            

            Console.Clear();
            Console.WriteLine(@"Show Search: " + results.results.FirstOrDefault().name);
            Console.WriteLine($@"Is { showName } airing today? " + TMDBApiLib.IsAiringToday(showName, TMDBApiLib.GetTodaysAiringShows()));            
            Console.WriteLine(@"Show Genres: ");

            foreach (GenreViewModel _genre in genres)
            {
                Console.WriteLine(" -" + _genre.name);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(@"Shows airing today: ");

            foreach (DailyShowAiringViewModel _airingToday in allAiring.results)
            {
                if (SortProcessing.IsExistingShow(_airingToday.name))
                {
                    Console.Write(@"[X] ");
                }
                else
                {
                    Console.Write(@"[ ] ");
                }
                Console.WriteLine(_airingToday.name);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(@"Media Drives: ");
            Console.WriteLine();

            foreach (var _drive in SortProcessing.GetMediaDrives())
            {
                Console.WriteLine($@"Drive Letter: { _drive.Item1 }");
                Console.WriteLine($@"Drive Type: { _drive.Item2 }");
                Console.WriteLine($@"Holds Active? { _drive.Item3 }");
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadLine();


        }      
    }
}
