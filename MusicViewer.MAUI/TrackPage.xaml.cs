using INF148187148204.MusicViewer.MAUI.ViewModel;

namespace INF148187148204.MusicViewer.MAUI;

public partial class TrackPage : ContentPage
{
	public TrackPage(TrackCollectionViewModel trackCollectionViewModel)
	{
		InitializeComponent();
		BindingContext = trackCollectionViewModel;
	}
}