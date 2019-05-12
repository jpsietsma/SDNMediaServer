using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Config
{
    public class Configuration
    {
        public Dictionary<string, object> _data { get; private set; } = new Dictionary<string, object>();

        public Configuration(string dbServer = ".", string dbInstance = @"SQLEXPRESS", string dbName = "SDNMediaServer", string sortDirectory = @"S:\", string tvDrives = @"E:\TV Shows\;F:\TV Shows\;G:\TV Shows\;H:\TV Shows\;I:\TV Shows\", string movieDrives = @"M:\Movies\")
        {   
            ///DB config
            _data.Add("dbcfg_DatabaseServer", $@"{ dbServer }");
            _data.Add("dbcfg_DatabaseInstance", $@"{ dbInstance }");
            _data.Add("dbcfg_DatabaseName", $@"{ dbName }");

            _data.Add("dbcfg_ConnectionString", $@"Data Source={dbServer}\{ dbInstance };Initial Catalog={ dbName };Integrated Security=True;Connect Timeout=30;Trusted Connection=true;");

            ///Program Config
            _data.Add("SortDrive", $@"{ sortDirectory }");
            _data.Add("TelevisionDrives", $@"{ tvDrives }");
            _data.Add("MovieDrives", $@"{ movieDrives }");
            
        }

        public Dictionary<string, object> GetFullConfiguration()
        {
            return _data;
        }

        public string GetConnectionString()
        {
            return _data["dbcfg_ConnectionString"] as string;
        }

        public List<string> GetTelevisionDrives()
        {
            string a = _data["TelevisionDrives"] as string;
            List<string> final = new List<string>();

            foreach (string _path in a.Split(';'))
            {
                final.Add(_path);
            }

            return final;
        }

        public List<string> GetMovieDrives()
        {
            string a = _data["MovieDrives"] as string;
            List<string> final = new List<string>();

            foreach (string _path in a.Split(';'))
            {
                final.Add(_path);
            }

            return final;
        }

        public string GetSortDrive()
        {
            return _data["SortDrive"] as string;
        }
    }
}
