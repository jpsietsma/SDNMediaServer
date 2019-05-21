using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Config
{
    public class Configuration
    {
        private Dictionary<string, object> _data { get; set; } = new Dictionary<string, object>();

        public Configuration(bool trustedConnection, string user = "", string password = "", string dbServer = ".", string dbInstance = @"SQLEXPRESS", string dbName = "SDNMediaServer", string sortDirectory = @"S:\", string tvDrives = @"E:\TV Shows\;F:\TV Shows\;G:\TV Shows\;H:\TV Shows\;I:\TV Shows\", string movieDrives = @"M:\Movies\", int timeout = 30)
        {
            // ######################   Database Config   ##############################

            List<KeyValuePair<string, object>> dbVals = new List<KeyValuePair<string, object>>();
            dbVals.Add(new KeyValuePair<string, object>("DatabaseServer", $@"{ dbServer }"));
            dbVals.Add(new KeyValuePair<string, object>("DatabaseInstance", $@"{ dbInstance }"));
            dbVals.Add(new KeyValuePair<string, object>("DatabaseName", $@"{ dbName }"));

            _data["dbcfg"] = dbVals;

            // ######################   Program Config   ##############################

            List<KeyValuePair<string, object>> sysVals = new List<KeyValuePair<string, object>>();            
                sysVals.Add(new KeyValuePair<string, object>("SortDrive", $@"{ sortDirectory }"));
                sysVals.Add(new KeyValuePair<string, object>("TelevisionDrives", $@"{ tvDrives }"));
                sysVals.Add(new KeyValuePair<string, object>("MovieDrives", $@"{ movieDrives }"));

                    List<KeyValuePair<string, string>> sysLogs = new List<KeyValuePair<string, string>>();
                        sysLogs.Add(new KeyValuePair<string, string>("SessionLogs", ""));
                        sysLogs.Add(new KeyValuePair<string, string>("SystemLogs", ""));
                        sysLogs.Add(new KeyValuePair<string, string>("ErrorLogs", ""));
                        sysLogs.Add(new KeyValuePair<string, string>("SortLogs", ""));

                sysVals.Add(new KeyValuePair<string, object>("Logging", sysLogs));
           
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

        private string BuildConnectionString(string dbServer, string dbName, string dbInstance, bool trustedConnection, string Username, string Password, int Timeout)
        {
            bool integratedSecurity;

            if (trustedConnection)
            {
                integratedSecurity = true;

                return $@"Data Source={dbServer}\{ dbInstance };Initial Catalog={ dbName };Integrated Security={ integratedSecurity.ToString().ToUpperInvariant() };Connect Timeout={ Timeout };Trusted Connection={ trustedConnection.ToString() };";
            }
            else
            {
                integratedSecurity = false;

                return $@"Data Source={dbServer}\{ dbInstance };Initial Catalog={ dbName };Integrated Security={ integratedSecurity.ToString().ToUpperInvariant() };Connect Timeout={ Timeout };Trusted Connection={ trustedConnection };User Id={ Username };Password={ Password };";
            }
        }


    }
}
