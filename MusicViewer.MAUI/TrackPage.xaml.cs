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
        (BindingContext as TrackCollectionViewModel).OnItemTapped(sender, e);
    }

    private void TrackContentPageName_Appearing(object sender, EventArgs e)
    {
        (BindingContext as TrackCollectionViewModel).OnAppearing(sender, e);
    }
}