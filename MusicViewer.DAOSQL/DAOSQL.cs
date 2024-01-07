﻿using INF148187148204.MusicViewer.DAOSQL.BO;
using INF148187148204.MusicViewer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

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
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            return new DataContext(configuration);
        }

        public IArtist CreateNewArtist()
        {
            return new Artist();
        }

        public ITrack CreateNewTrack()
        {
            return new Track();
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
            return context.Artists;
        }

        public IEnumerable<ITrack> GetAllTracks()
        {
            return context.Tracks;
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
                context.Add(ConvertInterfaceToDAOType(artist));
            } else
            {
                context.Update(ConvertInterfaceToDAOType(artist));
            }
            
            context.SaveChanges();
        }

        public void SaveTrack(ITrack track)
        {
            var dbTrack = GetTrack(track.ID);
            if (dbTrack == null)
            {
                context.Add(ConvertInterfaceToDAOType(track));
            }
            else
            {
                context.Update(ConvertInterfaceToDAOType(track));
            }

            context.SaveChanges();
        }

        public Artist ConvertInterfaceToDAOType(IArtist iartist)
        {
            Artist artist = new Artist();
            artist.ID = iartist.ID;
            artist.Name = iartist.Name;

            return artist;
        }

        public Track ConvertInterfaceToDAOType(ITrack itrack)
        {
            Track track = new Track();
            track.ID = itrack.ID;
            track.Name = itrack.Name;
            track.Artist = ConvertInterfaceToDAOType(itrack.Artist);
            track.ReleaseYear = itrack.ReleaseYear;
            track.Genre = itrack.Genre;

            return track;
        }
    }
}