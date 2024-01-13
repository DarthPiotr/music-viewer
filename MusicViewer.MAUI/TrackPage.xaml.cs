using INF148187148204.MusicViewer.MAUI.ViewModel;

namespace INF148187148204.MusicViewer.MAUI;

public partial class TrackPage : ContentPage
{
	public TrackPage(TrackCollectionViewModel trackCollectionViewModel)
	{
		InitializeComponent();
		BindingContext = trackCollectionViewModel;
	}

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        TrackViewModel trackViewModel = (e.Item as TrackViewModel).Clone() as TrackViewModel;
        (BindingContext as TrackCollectionViewModel).SetEditingTrack(trackViewModel);
    }
}