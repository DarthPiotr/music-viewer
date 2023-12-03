using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148187148204.MusicViewer.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IArtist> GetAllArtists();
        IEnumerable<ITrack> GetAllTracks();

        IArtist GetArtist(int Id);
        ITrack GetTrack(int Id);

        IArtist CreateNewArtist();
        ITrack CreateNewTrack();

        void SaveArtist(IArtist artist);
        void SaveTrack(ITrack artist);

        void DeleteArtist(int Id);
        void DeleteTrack(int Id);

    }
}
