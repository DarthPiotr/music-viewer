using CommunityToolkit.Maui;
using INF148187148204.MusicViewer.BLC;
using INF148187148204.MusicViewer.MAUI.ViewModel;
using Microsoft.Extensions.Logging;

namespace INF148187148204.MusicViewer.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();
            builder.Services.AddSingleton<ArtistCollectionViewModel>();
            builder.Services.AddSingleton<ArtistPage>();
            builder.Services.AddSingleton<TrackCollectionViewModel>();
            builder.Services.AddSingleton<TrackPage>();
            builder.Services.AddSingleton<BLController>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
