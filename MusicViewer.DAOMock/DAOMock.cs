using INF148187148204.MusicViewer.DAOMock.BO;
using INF148187148204.MusicViewer.Interfaces;
using INF148187148204.MusicViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148187148204.MusicViewer.DAOMock
{
    public class DAOMock : IDAO
    {
        private List<Artist> artists;
        private List<Track> tracks;

        public DAOMock()
        {
            artists = new List<Artist>()
            {
                new Artist()
                {
                    ID = 1,
                    Name = "Michael Jackson"
                },
                new Artist()
                {
                    ID = 2,
                    Name = "David Guetta"
                },
                new Artist()
                {
                    ID = 3,
                    Name = "Lady Pank"
                },
                new Artist()
                {
                    ID = 4,
                    Name = "Rammstein"
                },
                new Artist()
                {
                    ID = 5,
                    Name = "Ludwig van Beethoven"
                },
            };

            tracks = new List<Track>()
            {
                new Track() 
                {
                    ID = 1,
                    Name = "Billie Jean",
                    Artist = artists[0],
                    Genre = Genre.Pop,
                    ReleaseYear = 1982
                },
                new Track() 
                {
                    ID = 2,
                    Name = "Black Or White",
                    Artist = artists[0],
                    Genre = Genre.Pop,
                    ReleaseYear = 1991
                },
                new Track()
                {
                    ID = 3,
                    Name = "Memories",
                    Artist = artists[1],
                    Genre = Genre.Electronic,
                    ReleaseYear = 2009
                },
                new Track()
                {
                    ID = 4,
                    Name = "Kryzysowa narzeczona",
                    Artist = artists[2],
                    Genre = Genre.Rock,
                    ReleaseYear = 1983
                },
                new Track()
                {
                    ID = 5,
                    Name = "America",
                    Artist = artists[3],
                    Genre = Genre.Metal,
                    ReleaseYear = 2004
                },
                new Track()
                {
                    ID = 6,
                    Name = "Fur Elise",
                    Artist = artists[4],
                    Genre = Genre.Classical,
                    ReleaseYear = 1810
                },
            };
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
            tracks.RemoveAll(t => t.Artist.ID == Id);
            artists.RemoveAll(a => a.ID == Id);
        }

        public void DeleteTrack(int Id)
        {
            tracks.RemoveAll(t => t.ID == Id);
        }

        public IEnumerable<IArtist> GetAllArtists()
        {
            return artists;
        }

        public IEnumerable<ITrack> GetAllTracks()
        {
            return tracks;
        }

        public IArtist GetArtist(int Id)
        {
            return artists.FirstOrDefault(a => a.ID == Id)!;
        }

        public ITrack GetTrack(int Id)
        {
            return tracks.FirstOrDefault(t => t.ID == Id)!;
        }

        public void SaveArtist(IArtist artist)
        {
            artists.RemoveAll(a => a.ID == artist.ID);
            artists.Add(ConvertInterfaceToDAOType(artist));
        }

        public void SaveTrack(ITrack track)
        {
            tracks.RemoveAll(t => t.ID ==  track.ID);
            tracks.Add(ConvertInterfaceToDAOType(track));
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
