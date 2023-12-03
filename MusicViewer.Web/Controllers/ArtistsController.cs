﻿using INF148187148204.MusicViewer.BLC;
using INF148187148204.MusicViewer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INF148187148204.MusicViewer.Web.Controllers
{
    public class ArtistsController : Controller
    {
        private BLController BLC { get; set; }

        public ArtistsController()
        {
            string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            Console.WriteLine("Executing from: {0}", execPath);

            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"];
            BLC = BLController.GetInstance(libraryName);
        }

        // GET: ArtistsController
        public ActionResult Index()
        {
            return View(BLC.GetArtists());
        }

        // GET: ArtistsController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Tracks = BLC.GetTracks().Where(t => t.Artist.ID == id);

            return View(BLC.GetArtist(id));
        }

        // GET: ArtistsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var artist = BLC.CreateNewArtist();
                artist.Name = collection["Name"].ToString();
                BLC.SaveArtist(artist);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Create();
            }
        }

        // GET: ArtistsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(BLC.GetArtist(id));
        }

        // POST: ArtistsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var artist = BLC.GetArtist(id);
                artist.Name = collection["Name"].ToString();
                BLC.SaveArtist(artist);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Edit(id);
            }
        }

        // GET: ArtistsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(BLC.GetArtist(id));
        }

        // POST: ArtistsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                BLC.DeleteArtist(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Delete(id);
            }
        }
    }
}
