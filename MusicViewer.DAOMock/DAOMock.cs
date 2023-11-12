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

        public IEnumerable<IArtist> GetAllArtists()
        {
            return artists;
        }

        public IEnumerable<ITrack> GetAllTracks()
        {
            return tracks;
        }
    }
}
