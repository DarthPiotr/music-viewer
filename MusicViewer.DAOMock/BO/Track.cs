using INF148187148204.MusicViewer.Core;
using INF148187148204.MusicViewer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148187148204.MusicViewer.DAOMock.BO
{
    public class Track : ITrack
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IArtist Artist { get; set; }
        public int ReleaseYear { get; set; }
        public Genre Genre { get; set; }
    }
}
