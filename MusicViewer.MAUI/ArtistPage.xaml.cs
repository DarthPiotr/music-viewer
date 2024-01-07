using INF148187148204.MusicViewer.MAUI.ViewModel;

namespace INF148187148204.MusicViewer.MAUI;

public partial class ArtistPage : ContentPage
{
	public ArtistPage(ArtistCollectionViewModel artistCollectionViewModel)
	{
		InitializeComponent();
		BindingContext = artistCollectionViewModel;
	}

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		ArtistViewModel artistViewModel = (e.Item as ArtistViewModel).Clone() as ArtistViewModel;
		(BindingContext as ArtistCollectionViewModel).EditedArtist = artistViewModel;
    }
}