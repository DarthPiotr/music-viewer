using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using INF148187148204.MusicViewer.BLC;
using INF148187148204.MusicViewer.Interfaces;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148187148204.MusicViewer.MAUI.ViewModel
{
    public partial class ArtistCollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ArtistViewModel> artists;

        private BLController blc;

        [ObservableProperty]
        private ArtistViewModel editedArtist;

        [ObservableProperty]
        private bool editingExisting = false;

        public ArtistCollectionViewModel()
        {
            Artists = new ObservableCollection<ArtistViewModel>();
            string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            Console.WriteLine("Executing from: {0}", execPath);

            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"];
            blc = BLController.GetInstance(libraryName);

            foreach (IArtist artist in blc.GetArtists())
            {
                Artists.Add(new ArtistViewModel(artist));
            }

            CreateNewArtist();
        }

        [RelayCommand]
        public void CreateNewArtist()
        {
            EditingExisting = false;

            IArtist newArtist = blc.CreateNewArtist();
            EditedArtist = new ArtistViewModel(newArtist);
            EditedArtist.PropertyChanged += OnEditedArtistPropertyChanged;
            SaveArtistCommand.NotifyCanExecuteChanged();
            DeleteArtistCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand(CanExecute = nameof(CanSaveArtist))] 
        public void SaveArtist() 
        { 
            blc.SaveArtist(EditedArtist);
            EditingExisting = true;

            Artists = new ObservableCollection<ArtistViewModel>();
            foreach (IArtist artist in blc.GetArtists())
            {
                Artists.Add(new ArtistViewModel(artist));
            }
        }

        public bool CanSaveArtist()
        {
            if (EditedArtist == null || EditedArtist.Name == null) 
                return false;

            return EditedArtist.Name.Length > 0;
        }

        public void SetEditingArtist(ArtistViewModel artist)
        {
            EditedArtist = artist;
            EditingExisting = true;
            EditedArtist.PropertyChanged += OnEditedArtistPropertyChanged;
            SaveArtistCommand.NotifyCanExecuteChanged();
            DeleteArtistCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand(CanExecute = nameof(CanDeleteArtist))]
        public void DeleteArtist() 
        {
            blc.DeleteArtist(EditedArtist.ID);
            
            Artists = new ObservableCollection<ArtistViewModel>();
            foreach (IArtist artist in blc.GetArtists())
            {
                Artists.Add(new ArtistViewModel(artist));
            }

            CreateNewArtist();
        }

        public bool CanDeleteArtist()
        {
            return EditingExisting;
        }

        private void OnEditedArtistPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            SaveArtistCommand.NotifyCanExecuteChanged();
            DeleteArtistCommand.NotifyCanExecuteChanged();
        }
    }
}
