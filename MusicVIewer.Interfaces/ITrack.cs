using INF148187148204.MusicViewer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148187148204.MusicViewer.Interfaces
{
    public interface ITrack
    {
        [DisplayName("Id")]
        int ID { get; set; }

        [DisplayName("Title")]
        string Name { get; set; }

        [DisplayName("Artist")]
        IArtist Artist { get; set; }
        
        [DisplayName("Release year")]
        int ReleaseYear { set; get; }

        [DisplayName("Genre")]
        Genre Genre { set; get; }
    }
}
