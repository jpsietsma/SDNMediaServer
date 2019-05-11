using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MediaClasses.Config
{
    /// <summary>
    /// Class for retrieving and manipulating program configuration data and options.
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Class for dealing with the program App.config file
        /// </summary>
        public static class AppConfig
        {
            /// <summary>
            /// Retrieve the connection string from the App.config file.
            /// </summary>
            /// <returns>string SQL connection string</returns>
            private static string GetConnectionString()
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }

            /// <summary>
            /// Retrieve the database server from the App.config file
            /// </summary>
            /// <returns>string database server name</returns>
            private static string GetDatabaseServer()
            {
                return ConfigurationManager.AppSettings["DatabaseServer"];
            }

            /// <summary>
            /// Retrieve the database name from the App.config file
            /// </summary>
            /// <returns>string database name</returns>
            private static string GetDatabaseName()
            {
                return ConfigurationManager.AppSettings["DatabaseName"];
            }

            /// <summary>
            /// Retrieve the database instance name from the App.config file
            /// </summary>
            /// <returns>string database instance name</returns>
            private static string GetDatabaseInstance()
            {
                return ConfigurationManager.AppSettings["DatabaseInstance"];
            }

            /// <summary>
            /// Retrieve the sort directory path from the App.config file
            /// </summary>
            /// <returns>string directory path</returns>
            private static string GetSortDirectory()
            {
                return ConfigurationManager.AppSettings["SortDirectoryPath"];
            }

            /// <summary>
            /// Retrieve the list of Television Show drives from the App.config file
            /// </summary>
            /// <returns>List of drives containing television shows</returns>
            private static List<string> GetTelevisionDrives()
            {
                string sort = ConfigurationManager.AppSettings["TelevisionDrives"];

                return sort.Split(';').ToList();
            }

            /// <summary>
            /// Retrieve the list of Movie drives from the App.config file
            /// </summary>
            /// <returns>List of drives containing movies</returns>
            private static List<string> GetMovieDrives()
            {
                string sort = ConfigurationManager.AppSettings["MovieDrives"];

                return sort.Split(';').ToList();
            }

            /// <summary>
            /// Retrieve program settings from the App.config file
            /// </summary>
            /// <returns>Dictionary of program settings</returns>
            public static Dictionary<string, object> GetConfigurationSettings()
            {
                Dictionary<string, object> _settings = new Dictionary<string, object>();

                _settings.Add("cfg_TVDrives", GetTelevisionDrives());
                _settings.Add("cfg_MovieDrives", GetMovieDrives());
                _settings.Add("cfg_SortDirectory", GetSortDirectory());
                _settings.Add("cfg_SqlServer", GetDatabaseServer());
                _settings.Add("cfg_SqlDatabase", GetDatabaseName());
                _settings.Add("cfg_SqlInstance", GetDatabaseInstance());
                _settings.Add("SQL_ConnectionString", GetConnectionString());

                return _settings;
            }

        }


    }
}
