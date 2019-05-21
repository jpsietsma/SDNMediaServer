using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediaClasses.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.DatabaseContext;

namespace WebUI.Controllers
{
    public class SortController : Controller
    {
        public ActionResult ScanSort()
        {
            string path = @"S:\";

            using (DB conn = new DB())
            {
                foreach (string _path in Directory.GetFiles(path))
                {
                    FileInfo info = new FileInfo(_path);
                    var a = conn.SortQueue.Where(x => x.FilePath == _path).Count();

                    if (a == 0)
                    {
                        DatabaseContext.SortQueue _new = new DatabaseContext.SortQueue
                        {
                            Classification = "Sort",
                            ClassificationDate = DateTime.Now.Date.ToString(),
                            FileName = info.Name,
                            FilePath = _path,
                            ShowDrive = null,
                            ShowName = null,
                            ShowSeason = null
                        };

                        try
                        {
                            conn.SortQueue.Add(_new);
                            conn.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }                    
                }

                
            }

            return View("ViewSort");
        }

        public ActionResult ViewSort()
        {
            List<SortQueue> _models = new List<SortQueue>();

            using (DB conn = new DB())
            {
                foreach (var _item in conn.SortQueue)
                {
                    _models.Add(_item);
                }
            }

            return View(_models);
        }

        // GET: Sort
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            MediaFileInfo info = new MediaFileInfo(id);
            return View(info);
        }

        // GET: Sort/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sort/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sort/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sort/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sort/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sort/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}