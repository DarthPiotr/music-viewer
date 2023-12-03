using INF148187148204.MusicViewer.BLC;
using Microsoft.AspNetCore.Mvc;
using INF148187148204.MusicViewer.Web.Models;
using System.Diagnostics;

namespace MusicViewer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BLController BLC { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            Console.WriteLine("Executing from: {0}", execPath);

            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"];
            BLC = BLController.GetInstance(libraryName);
        }

        public IActionResult Index()
        {
            var art = BLC.GetArtists().ToList();
            return View();
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