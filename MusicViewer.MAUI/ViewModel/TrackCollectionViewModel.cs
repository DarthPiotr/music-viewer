using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using INF148187148204.MusicViewer.BLC;
using INF148187148204.MusicViewer.Core;
using INF148187148204.MusicViewer.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private ObservableCollection<IArtist> artists;

        [ObservableProperty]
        private TrackViewModel? editedTrack;

        [ObservableProperty]
        private bool editingExisting = false;

        [ObservableProperty]
        private TrackFilter filter;

        private BLController blc;

        public TrackCollectionViewModel(BLController blc)
        {
            this.blc = blc;

            RefreshArtists();
            Filter = new TrackFilter();
            Search();
        }

        public void RefreshArtists()
        {
            Artists = new ObservableCollection<IArtist>(blc.GetArtists());
        }

        [RelayCommand]
        public void CreateNewTrack()
        {
            EditingExisting = false;

            ITrack newTrack = blc.CreateNewTrack();
            EditedTrack = new TrackViewModel(newTrack);
            EditedTrack.PropertyChanged += OnEditedTrackPropertyChanged;
            SaveTrackCommand.NotifyCanExecuteChanged();
            DeleteTrackCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand(CanExecute = nameof(CanSaveTrack))]
        public void SaveTrack()
        {
            blc.SaveTrack(EditedTrack!.GetModifiedTrack());
            EditingExisting = true;

            Search();
        }



        public bool CanSaveTrack()
        {
            if (EditedTrack == null || EditedTrack.Name == null) // TODO: reszta properties
                return false;

            return EditedTrack.Name.Length > 0;
        }

        public void SetEditingTrack(TrackViewModel track)
        {
            EditedTrack = track;
            EditingExisting = true;
            EditedTrack.PropertyChanged += OnEditedTrackPropertyChanged;
            SaveTrackCommand.NotifyCanExecuteChanged();
            DeleteTrackCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand(CanExecute = nameof(CanDeleteTrack))]
        public void DeleteTrack()
        {
            blc.DeleteTrack(EditedTrack!.ID);

            Tracks = new ObservableCollection<TrackViewModel>();
            foreach (ITrack track in blc.GetTracks())
            {
                Tracks.Add(new TrackViewModel(track));
            }

            CreateNewTrack();
        }

        public bool CanDeleteTrack()
        {
            return EditingExisting;
        }

        [RelayCommand]
        public void Search()
        {
            var allTracks = blc.GetTracks();
            IEnumerable<ITrack>? filteredTracks = Filter.Filter(allTracks);

            List<TrackViewModel> list = new List<TrackViewModel>();
            foreach (ITrack track in filteredTracks)
            {
                list.Add(new TrackViewModel(track));
            }
            Tracks = new ObservableCollection<TrackViewModel>(list.OrderBy(t => t.ID));

            //Tracks = new ObservableCollection<TrackViewModel>();
            //foreach (ITrack track in blc.GetTracks())
            //{
            //    Tracks.Add(new TrackViewModel(track));
            //}


            CreateNewTrack();
        }

        [RelayCommand]
        public void ClearSearch()
        {
            Filter = new TrackFilter();
            Search();
        }

        private void OnEditedTrackPropertyChanged(object? sender, PropertyChangedEventArgs args)
        {
            SaveTrackCommand.NotifyCanExecuteChanged();
            DeleteTrackCommand.NotifyCanExecuteChanged();
        }

        public void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            TrackViewModel? trackViewModel = (e.Item as TrackViewModel)!.Clone() as TrackViewModel;
            SetEditingTrack(trackViewModel!);
        }

        public void OnAppearing(object sender, EventArgs e)
        {
            RefreshArtists();
            Search();
		}
    }
}
