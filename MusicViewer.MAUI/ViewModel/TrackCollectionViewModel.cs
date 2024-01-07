using CommunityToolkit.Mvvm.ComponentModel;
using INF148187148204.MusicViewer.BLC;
using INF148187148204.MusicViewer.Core;
using INF148187148204.MusicViewer.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148187148204.MusicViewer.MAUI.ViewModel
{
    public partial class TrackCollectionViewModel: ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TrackViewModel> tracks;

        [ObservableProperty]
        private IEnumerable<Genre> genres = Enum.GetValues(typeof(Genre)).Cast<Genre>();

        [ObservableProperty]
        private IEnumerable<IArtist> artists;

        private BLController blc;

        public TrackCollectionViewModel()
        {
            tracks = new ObservableCollection<TrackViewModel>();
            string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            Console.WriteLine("Executing from: {0}", execPath);

            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"];
            blc = BLController.GetInstance(libraryName);

            Artists = blc.GetArtists();

            foreach (ITrack track in blc.GetTracks())
            {
                tracks.Add(new TrackViewModel(track));
            }
        }
    }
}
