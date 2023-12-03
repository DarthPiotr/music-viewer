using INF148187148204.MusicViewer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148187148204.MusicViewer.DAOSQL.BO
{
    public class Artist : IArtist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; } = new List<Track>();
    }
}
