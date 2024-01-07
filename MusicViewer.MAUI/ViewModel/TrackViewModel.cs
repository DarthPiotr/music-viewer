using CommunityToolkit.Mvvm.ComponentModel;
using INF148187148204.MusicViewer.Core;
using INF148187148204.MusicViewer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148187148204.MusicViewer.MAUI.ViewModel
{
    public partial class TrackViewModel : ObservableObject, ITrack, ICloneable
    {
        [ObservableProperty]
        private int iD;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private IArtist artist;

        [ObservableProperty]
        private int releaseYear;

        [ObservableProperty]
        private Genre genre ;

        public TrackViewModel(ITrack track)
        {
            iD = track.ID;
            name = track.Name;
            artist = track.Artist;
            releaseYear = track.ReleaseYear;
            genre = track.Genre;
        }

        public object Clone()
        {
            return new TrackViewModel(this);
        }
    }
}
