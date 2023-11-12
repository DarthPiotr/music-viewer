using INF148187148204.MusicViewer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148187148204.MusicViewer.Interfaces
{
    public interface ITrack
    {
        int ID { get; set; }
        string Name { get; set; }
        IArtist Artist { get; set; }
        int ReleaseYear { set; get; }

        Genre Genre { set; get; }
    }
}
