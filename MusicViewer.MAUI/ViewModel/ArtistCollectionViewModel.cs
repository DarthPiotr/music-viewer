using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using INF148187148204.MusicViewer.BLC;
using INF148187148204.MusicViewer.Interfaces;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            artists = new ObservableCollection<ArtistViewModel>();
            string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            Console.WriteLine("Executing from: {0}", execPath);

            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"];
            blc = BLController.GetInstance(libraryName);

            foreach (IArtist artist in blc.GetArtists())
            {
                artists.Add(new ArtistViewModel(artist));
            }
        }

        [RelayCommand]
        public void CreateNewArtist()
        {
            EditingExisting = false;

            IArtist newArtist = blc.CreateNewArtist();
            EditedArtist = new ArtistViewModel(newArtist);
        }


        [RelayCommand(CanExecute = nameof(CanSaveArtist))] 
        public void SaveArtist() 
        { 
            blc.SaveArtist(EditedArtist);
        }

        public bool CanSaveArtist()
        {
            return true;
        }


        [RelayCommand]
        public void DeleteArtist() { }
    }
}
