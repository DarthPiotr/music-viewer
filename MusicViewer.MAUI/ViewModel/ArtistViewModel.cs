using CommunityToolkit.Mvvm.ComponentModel;
using INF148187148204.MusicViewer.Interfaces;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148187148204.MusicViewer.MAUI.ViewModel
{
    public partial class ArtistViewModel : ObservableObject, IArtist, ICloneable
    {
        [ObservableProperty]
        private int iD;

        [ObservableProperty]
        private string name;

        public IArtist Artist { get; init; }

        public ArtistViewModel(IArtist artist)
        {
            iD = artist.ID;
            name = artist.Name;

            Artist = artist;
        }

        public object Clone()
        {
            return new ArtistViewModel(Artist);
        }

        public IArtist GetModifiedArtist()
        {
            Artist.Name = Name;

            return Artist;
        }
    }
}
