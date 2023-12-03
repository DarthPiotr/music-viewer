using INF148187148204.MusicViewer.BLC;
using INF148187148204.MusicViewer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace INF148187148204.MusicViewer.Web.Controllers
{
	public class TracksController : Controller
	{
		private BLController BLC { get; set; }

        public TracksController()
        {
			string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
			Console.WriteLine("Executing from: {0}", execPath);

			string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"];
			BLC = BLController.GetInstance(libraryName);
		}

        // GET: TracksController
        public ActionResult Index()
		{
			return View(BLC.GetTracks());
		}

		// GET: TracksController/Details/5
		public ActionResult Details(int id)
		{
            var track = BLC.GetTrack(id);
            return View(track);
        }

		// GET: TracksController/Create
		public ActionResult Create()
		{
			ViewBag.Artists = BLC.GetArtists();
			return View();
		}

		// POST: TracksController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				var track = BLC.CreateNewTrack();
				track.Name = collection["Name"].ToString();
				track.Genre = (Genre)Convert.ToInt32(collection["Genre"].ToString());
				track.ReleaseYear = Convert.ToInt32(collection["ReleaseYear"].ToString());
				track.Artist = BLC.GetArtist(Convert.ToInt32(collection["Artist"].ToString()));
				BLC.SaveTrack(track);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return Create();
			}
		}

		// GET: TracksController/Edit/5
		public ActionResult Edit(int id)
		{
            ViewBag.Artists = BLC.GetArtists();

            var track = BLC.GetTrack(id);
			return View(track);
		}

		// POST: TracksController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				var track = BLC.GetTrack(id);
				track.Name = collection["Name"].ToString();
				track.Genre = (Genre)Convert.ToInt32(collection["Genre"].ToString());
				track.ReleaseYear = Convert.ToInt32(collection["ReleaseYear"].ToString());
				track.Artist = BLC.GetArtist(Convert.ToInt32(collection["Artist"].ToString()));
                BLC.SaveTrack(track);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return Edit(id);
			}
		}

		// GET: TracksController/Delete/5
		public ActionResult Delete(int id)
		{
            var track = BLC.GetTrack(id);
            return View(track);
        }

		// POST: TracksController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				BLC.DeleteTrack(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return Delete(id);
            }
		}
	}
}
