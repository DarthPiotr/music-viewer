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

        IArtist CreateNewArtist();
        ITrack CreateNewTrack();
    }
}
