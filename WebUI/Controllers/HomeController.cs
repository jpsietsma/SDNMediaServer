using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUI.DatabaseContext;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AutomationQueue()
        {
            List<SortQueue> _files = new List<SortQueue>();

            using (DB conn = new DB())
            {
                _files = conn.SortQueue.ToList();
            }

            if (_files.Count() >= 2)
            {
                return View(_files);
            }
            else
            {
                return View();
            }
            
        }

        [Route("Home/Config/MediaDrives")]
        public IActionResult MediaDrives()
        {
            using (DB conn = new DB())
            {
                var _drives = conn.MediaDrives.ToList<MediaDrives>();

                return View(_drives);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
