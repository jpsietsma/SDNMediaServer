using MediaClasses.Classes;
using MediaClasses.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using static MediaClasses.Config.Configuration;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string _file = @"S:\Family.Guy.S17E17.Island.Adventure.720p.AMZN.WEB-DL.DD+5.1.H.264-CtrlHD[eztv].mkv";

            MediaFile _model = new MediaFile(_file);

            Console.WriteLine($@"######### File Information ##############");
            Console.WriteLine();
            Console.WriteLine($@"File Name: { _model.FileName }");
            Console.WriteLine($@"File Size in b: {_model.GetFileSize(null)}");
            Console.WriteLine($@"File Size in KB: {_model.GetFileSize(MediaFile.SizeFormat.KB)}");
            Console.WriteLine($@"File Size in MB: {_model.GetFileSize(MediaFile.SizeFormat.MB)}");
            Console.WriteLine($@"File Size in GB: {_model.GetFileSize(MediaFile.SizeFormat.GB)}");
            Console.WriteLine();
            Console.ReadLine();

            Console.WriteLine(@"######### Program Configuration ##########");
            Console.WriteLine();
            Console.WriteLine($@"Sort Directory: { AppConfig.GetConfigurationSettings()["cfg_SortDirectory"] }");           
            Console.WriteLine($@"Television Drives: ");

            foreach (string _drive in AppConfig.GetConfigurationSettings()["cfg_TVDrives"] as List<string>)
                {
                    Console.WriteLine($@"   -{ _drive }");
                }

            Console.WriteLine($@"Movie Drives: ");

            foreach (string _drive in AppConfig.GetConfigurationSettings()["cfg_MovieDrives"] as List<string>)
            {
                Console.WriteLine($@"   -{ _drive }");
            }

            Console.WriteLine();
            Console.WriteLine($@"######### Database Connection Settings ##########");
            Console.WriteLine();
            Console.WriteLine($@"Database Server: { AppConfig.GetConfigurationSettings()["cfg_SqlServer"] }");
            Console.WriteLine($@"Database Name: { AppConfig.GetConfigurationSettings()["cfg_SqlDatabase"] }");
            Console.WriteLine($@"Instance Name: { AppConfig.GetConfigurationSettings()["cfg_SqlInstance"] }");
            Console.WriteLine();
            Console.WriteLine($@"Connection String: { AppConfig.GetConfigurationSettings()["SQL_ConnectionString"] }");
            Console.ReadLine();

            SortMediaFile _sortFile = new SortMediaFile(_file);
            var x =  _sortFile.GetType();

            Console.WriteLine("######## Sort Object: ###########");
            Console.WriteLine();

            foreach (PropertyInfo item in _sortFile.GetType().GetProperties())
            {
                Console.WriteLine($@"{ item.Name }: { item.GetValue(_sortFile) }");
            }

            Console.ReadLine();
        }
    }
}
