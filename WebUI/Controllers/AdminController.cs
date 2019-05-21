using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
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

            string[] _filesDownloading = Directory.GetFiles(@"S:\~downloading\");

            ViewData["TotalDownloading"] = _filesDownloading.Count();

            return View();
        }

        public IActionResult Dashboard2()
        {
            return View();
        }

    }
}