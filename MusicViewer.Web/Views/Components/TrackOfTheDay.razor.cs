using INF148187148204.MusicViewer.BLC;
using INF148187148204.MusicViewer.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace INF148187148204.MusicViewer.Web.Views.Components
{
    public partial class TrackOfTheDay
    {
        private Random random = new Random();
        [Inject]
        private BLController BLC { get; set; }
        private List<ITrack> Tracks { get; set; } = new List<ITrack>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            RefreshTracks();
            NewRandomTrack();
        }

        public void RefreshTracks()
        {
            Tracks = BLC.GetTracks().ToList();
        }

        public ITrack RandomTrack()
        {
			int randomIndex = random.Next(0, Tracks.Count);
			return Tracks[randomIndex];
		}
    }
}
