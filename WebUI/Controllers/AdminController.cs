using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUI.DatabaseContext;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            using (DB conn = new DB())
            {
                ViewData["UserName"] = @"jpsietsma";
                ViewData["Permissions"] = @"Administrator";

                string path = @"S:\";
                List<string> sortFiles = Directory.GetFiles(path).ToList();

                ViewData["SortFiles"] = sortFiles.Count();

                DriveInfo _sortDrive = new DriveInfo(@"S:\");

                ViewData["SortDriveFree"] = ((_sortDrive.TotalFreeSpace / 1024) / 1024) / 1024;
                ViewData["SortDriveTotal"] = ((_sortDrive.TotalSize / 1024) / 1024) / 1024;

                string[] _drives = { @"E:\TV Shows\", @"F:\TV Shows\", @"G:\TV Shows\", @"H:\TV Shows\", @"I:\TV Shows\" };

                List<string> _activeShows = new List<string>();
                List<string> _endedShows = new List<string>();

                foreach (string _drive in _drives)
                {
                    string[] _showFolders = Directory.GetDirectories(_drive);

                    foreach (string _show in _showFolders)
                    {
                        if (_drive == @"E:\TV Shows\" || _drive == @"F:\TV Shows\" || _drive == @"H:\TV Shows\")
                        {
                            _activeShows.Add(_show);
                        }
                        else
                        {
                            _endedShows.Add(_show);
                        }
                    }
                }

                ViewData["TotalShows"] = _activeShows.Concat(_endedShows).Count();
                ViewData["ActiveShows"] = _activeShows.Count();
                ViewData["EndedShows"] = _endedShows.Count();

                var shows = _activeShows.Concat(_endedShows);
                int episodeCount = 0;

                foreach (string _showFolder in shows)
                {
                    string[] _showFiles = Directory.GetFiles(_showFolder, "*", SearchOption.AllDirectories);

                    foreach (string _episode in _showFiles)
                    {
                        episodeCount++;
                    }
                }

                ViewData["Television-TotalEpisodes"] = episodeCount;

                ViewData["Television-PriorityCount"] = conn.UserPriorityShows.ToList().Count();

                string[] _filesDownloading = Directory.GetFiles(@"S:\~downloading\");

                ViewData["TotalDownloading"] = _filesDownloading.Count();

                ViewData["Movies-Genre-Action"] = Directory.GetFiles(@"M:\Movies\Action\", "*", SearchOption.AllDirectories).Count();
                ViewData["Movies-Genre-Drama"] = Directory.GetFiles(@"M:\Movies\Drama\", "*", SearchOption.AllDirectories).Concat(Directory.GetFiles(@"M:\Movies\Crime Drama\", "*", SearchOption.AllDirectories)).Count();
                ViewData["Movies-Genre-Horror"] = Directory.GetFiles(@"M:\Movies\Horror\", "*", SearchOption.AllDirectories).Count();
                ViewData["Movies-Genre-Comedy"] = Directory.GetFiles(@"M:\Movies\Comedy\", "*", SearchOption.AllDirectories).Count();
                ViewData["Movies-Genre-Unclassified"] = Directory.GetFiles(@"M:\Movies\Unsorted\", "*", SearchOption.AllDirectories).Count();
                
                List<int> movieGenreTotals = new List<int>();
                movieGenreTotals.Add(Convert.ToInt32(ViewData["Movies-Genre-Action"]));
                movieGenreTotals.Add(Convert.ToInt32(ViewData["Movies-Genre-Drama"]));
                movieGenreTotals.Add(Convert.ToInt32(ViewData["Movies-Genre-Horror"]));
                movieGenreTotals.Add(Convert.ToInt32(ViewData["Movies-Genre-Comedy"]));
                movieGenreTotals.Add(Convert.ToInt32(ViewData["Movies-Genre-Unclassified"]));

                ViewData["Movies-Genre-Total"] = movieGenreTotals.Sum();


            }            

            return View();
        }

        public IActionResult Dashboard2()
        {
            return View();
        }

    }
}