using INF148187148204.MusicViewer.Interfaces;
using INF148187148204.MusicViewer.BLC;
using System.Xml.Linq;

namespace INF148187148204.MusicViewer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"];
            BLController blc = BLController.GetInstance(libraryName);

            Console.WriteLine("=== Producers ===");
            foreach (IArtist a in blc.GetArtists())
            {
                Console.WriteLine("[{0}] {1}", a.ID, a.Name);
            }

            Console.WriteLine("=== Cars ===");
            foreach (ITrack t in blc.GetTracks())
            {
                Console.WriteLine("[{0}] {1} - {2} ({3}) {4}", 
                    t.ID, t.Artist.Name, t.Name, t.ReleaseYear, t.Genre);
            }
        }
    }
}