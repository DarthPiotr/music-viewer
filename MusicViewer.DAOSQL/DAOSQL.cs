using INF148187148204.MusicViewer.DAOSQL.BO;
using INF148187148204.MusicViewer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace INF148187148204.MusicViewer.DAOSQL
{
    public class DAOSQL : IDAO, IDesignTimeDbContextFactory<DataContext>
    {
        private DataContext context;

        public DAOSQL()
        {
            context = CreateDbContext(new string[] { });
            context.Database.OpenConnection();
        }

        ~DAOSQL()
        {
            context.Database.CloseConnection();
        }

        public DataContext CreateDbContext(string[] args)
        {
            string execPath = Assembly.GetEntryAssembly()!.Location;
            string currentDir = Path.GetDirectoryName(execPath) ?? "";
            string configPath = Path.Join(currentDir, "appsettings.json");


            Debug.WriteLine(String.Format("\n\nReading database settings from: {0}", configPath));

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configPath, optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            return new DataContext(configuration);
        }

        public IArtist CreateNewArtist()
        {
            return new Artist();
        }

        public ITrack CreateNewTrack()
        {

            return new Track() { Artist = new Artist() };
        }

        public void DeleteArtist(int Id)
        {
            context.Remove(GetArtist(Id));
            context.SaveChanges();
        }

        public void DeleteTrack(int Id)
        {
            context.Remove(GetTrack(Id));
            context.SaveChanges();
        }

        public IEnumerable<IArtist> GetAllArtists()
        {
            return context.Artists.ToList();
        }

        public IEnumerable<ITrack> GetAllTracks()
        {
            return context.Tracks.Include(t=> t.Artist).ToList();
        }

        public IArtist GetArtist(int Id)
        {
            return context.Artists.FirstOrDefault(e => e.ID == Id)!;
        }

        public ITrack GetTrack(int Id)
        {
            return context.Tracks.FirstOrDefault(e => e.ID == Id)!;
        }

        public void SaveArtist(IArtist artist)
        {
            var dbArtist = GetArtist(artist.ID);
            if (dbArtist == null)
            {
                //context.Add(ConvertInterfaceToDAOType(artist));
                context.Add(artist);

			} else
            {
                //context.Update(ConvertInterfaceToDAOType(artist));
				context.Update(artist);

			}
            
            context.SaveChanges();
        }

        public void SaveTrack(ITrack track)
        {
            var dbTrack = GetTrack(track.ID);
            if (dbTrack == null)
            {
                //context.Add(ConvertInterfaceToDAOType(track));
                context.Add(track);
            }
            else
            {
                context.Update(track);
                //var newTrack = ConvertInterfaceToDAOType(track);
                //context.Entry<Track>()
            }

            context.SaveChanges();
        }

        public Artist ConvertInterfaceToDAOType(IArtist iartist)
        {
            Artist artist = (Artist)GetArtist(iartist.ID);
            artist.ID = iartist.ID;
            artist.Name = iartist.Name;

            return artist;
        }

        public Track ConvertInterfaceToDAOType(ITrack itrack)
        {
            Track track = (Track)GetTrack(itrack.ID);
            track.ID = itrack.ID;
            track.Name = itrack.Name;
            track.Artist = ConvertInterfaceToDAOType(itrack.Artist);
            track.ReleaseYear = itrack.ReleaseYear;
            track.Genre = itrack.Genre;

            return track;
        }
    }
}