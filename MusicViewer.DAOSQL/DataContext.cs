using INF148187148204.MusicViewer.DAOSQL.BO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace INF148187148204.MusicViewer.DAOSQL
{
    public class DataContext : DbContext
    {
        private IConfiguration _configuration;

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string connectionString = _configuration.GetConnectionString("Sqlite");
            optionsBuilder.UseSqlite(connectionString);

            Debug.WriteLine(String.Format("\n\nUsing connection string: {0}", connectionString));
        }
    }
}
