using System.ComponentModel;

namespace INF148187148204.MusicViewer.Interfaces
{
    public interface IArtist
    {

        [DisplayName("Id")]
        int ID { get; set; }

        [DisplayName("Name")]
        string Name { get; set; }
    }
}