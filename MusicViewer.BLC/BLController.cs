using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using INF148187148204.MusicViewer.Interfaces;

namespace INF148187148204.MusicViewer.BLC
{
    public class BLController
    {
        private static BLController? blc;
        private IDAO dao;

        private BLController(string libraryName)
        {
            Assembly assembly = Assembly.UnsafeLoadFrom(libraryName);
            Type? typeToCreate = null;

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsAssignableTo(typeof(IDAO)))
                {
                    typeToCreate = type;
                    break;
                }
            }

            dao = (IDAO)Activator.CreateInstance(typeToCreate, null);
        }

        public static BLController GetInstance(string libraryName)
        {
            blc ??= new BLController(libraryName);
            return blc;
        }

        public IEnumerable<IArtist> GetArtists() => dao.GetAllArtists();
        public IEnumerable<ITrack> GetTracks() => dao.GetAllTracks();

        public IArtist GetArtist(int Id) => dao.GetArtist(Id); 
        public ITrack GetTrack(int Id) => dao.GetTrack(Id);

        public IArtist CreateNewArtist() => dao.CreateNewArtist();
        public ITrack CreateNewTrack() => dao.CreateNewTrack();

        public void SaveArtist(IArtist artist)=> dao.SaveArtist(artist);
        public void SaveTrack(ITrack track)=> dao.SaveTrack(track);

        public void DeleteArtist(int Id) => dao.DeleteArtist(Id);
        public void DeleteTrack(int Id) => dao.DeleteTrack(Id);
    }
}
