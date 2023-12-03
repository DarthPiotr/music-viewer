using INF148187148204.MusicViewer.DAOSQL;
using INF148187148204.MusicViewer.Interfaces;
using Microsoft.Extensions.Configuration;

namespace DAOSQLConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            Console.WriteLine("Executing from: {0}", execPath);


            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            Console.WriteLine(configuration.GetConnectionString("Sqlite"));
            using var db = new DataContext(configuration);
            
            
            
            Console.WriteLine("=== Artists ===");
            foreach (IArtist a in db.Artists)
            {
                Console.WriteLine("[{0}] {1}", a.ID, a.Name);
            }

            Console.WriteLine("=== Tracks ===");
            foreach (ITrack t in db.Tracks)
            {
                Console.WriteLine("[{0}] {1} - {2} ({3}) {4}",
                    t.ID, t.Artist.Name, t.Name, t.ReleaseYear, t.Genre);
            }
        }
    }
}