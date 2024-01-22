using INF148187148204.MusicViewer.Interfaces;

namespace INF148187148204.MusicViewer.DAOMock.Test
{
    public class DaoMockTest
    {

        private DAOMock daomock;

        [SetUp]
        public void Setup()
        {
            daomock = new DAOMock();
        }

        [Test(Description = "Read Artist by Id")]
        public void ReadArtist1()
        {
            IArtist artist = daomock.GetArtist(1);
            Assert.IsNotNull(artist);
            Assert.That(artist.Name, Is.EqualTo("Michael Jackson"));
        }

        [Test(Description = "Read Track by Id")]
        public void ReadTrack1()
        {
            ITrack track = daomock.GetTrack(1);
            Assert.IsNotNull(track);
            Assert.That(track.Name, Is.EqualTo("Billie Jean"));
        }

        [Test(Description = "Read All Artists")]
        public void ReadAllArtist()
        {
            IEnumerable<IArtist> list = daomock.GetAllArtists();
            Assert.IsNotNull(list);
            Assert.That(list.Count(), Is.EqualTo(5));
        }

        [Test(Description = "Read All Tracks")]
        public void ReadAllTracks()
        {
            IEnumerable<ITrack> list = daomock.GetAllTracks();
            Assert.IsNotNull(list);
            Assert.That(list.Count(), Is.EqualTo(6));
        }

        [Test(Description = "Add artist")]
        public void AddArtist()
        {
            IArtist newArtist = daomock.CreateNewArtist();
            newArtist.Name = "Test";
            daomock.SaveArtist(newArtist);

            IEnumerable<IArtist> artists = daomock.GetAllArtists();

            bool isArtistFound = artists.Any(artist => artist.Name == "Test");
            Assert.That(isArtistFound, Is.True);

        }

        [Test(Description = "Add track")]
        public void AddTrack()
        {
            ITrack newTrack = daomock.CreateNewTrack();
            newTrack.Name = "Test";
            daomock.SaveTrack(newTrack);

            IEnumerable<ITrack> tracks = daomock.GetAllTracks();
            
            bool isTrackFound = tracks.Any(track => track.Name == "Test");
            Assert.That(isTrackFound, Is.True);
        }

        [Test(Description = "Update artist")]
        public void UpdateArtist()
        {
            IArtist item = daomock.GetArtist(1);
            item.Name = "Test";
            daomock.SaveArtist(item);

            IArtist sameItem = daomock.GetArtist(1);
            Assert.That(sameItem.Name, Is.EqualTo("Test"));

        }

        [Test(Description = "Update track")]
        public void UpdateTrack()
        {
            ITrack item = daomock.GetTrack(1);
            item.Name = "Test";
            daomock.SaveTrack(item);

            ITrack sameItem = daomock.GetTrack(1);
            Assert.That(sameItem.Name, Is.EqualTo("Test"));

        }

        [Test(Description = "Delete artist")]
        public void DeleteArtist()
        {
            IArtist item = daomock.GetArtist(1);
            daomock.DeleteArtist(1);

            IEnumerable<IArtist> items = daomock.GetAllArtists();
            bool isArtistFound = items.Any(i => i.Name == item.Name);
            Assert.That(isArtistFound, Is.False);
        }

        [Test(Description = "Delete track")]
        public void DeleteTrack()
        {
            ITrack item = daomock.GetTrack(1);
            daomock.DeleteTrack(1);

            IEnumerable<ITrack> items = daomock.GetAllTracks();
            bool isTrackFound = items.Any(i => i.Name == item.Name);
            Assert.That(isTrackFound, Is.False);
        }
    }
}