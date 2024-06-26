﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        private IEnumerable<IArtist> artists { get; set; }
        private IEnumerable<ITrack> tracks { get; set; }

        public BLController()
        {
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"] ?? "";

            if (!Path.IsPathFullyQualified(libraryName))
            {
                string execPath = Assembly.GetEntryAssembly()!.Location;
                string currentDir = Path.GetDirectoryName(execPath) ?? "";
                libraryName = Path.Join(currentDir, libraryName);
            }

            Setup(libraryName);
        }

        private BLController(string libraryName)
        {
            Setup(libraryName);
        }

        private void Setup(string libraryName)
        {
            Debug.WriteLine(String.Format("\n\nLoading library: {0}", libraryName));
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

        public IEnumerable<IArtist> GetArtists() 
        { 
            if(artists == null)
                artists = dao.GetAllArtists();
            return artists;
        }
        public IEnumerable<ITrack> GetTracks()
        {
            if (tracks == null)
                tracks = dao.GetAllTracks();
            return tracks;
        }
        public IArtist GetArtist(int Id)
        {
            if(artists == null)
                return dao.GetArtist(Id);

            return artists.FirstOrDefault(a => a.ID == Id)!;
        }

        public ITrack GetTrack(int Id)
        {
            if (tracks == null)
                return dao.GetTrack(Id);

            return tracks.FirstOrDefault(t => t.ID == Id)!;
        }

        public IArtist CreateNewArtist() => dao.CreateNewArtist();
        public ITrack CreateNewTrack() => dao.CreateNewTrack();

        public void SaveArtist(IArtist artist)
        {
            dao.SaveArtist(artist);
            artists = dao.GetAllArtists();
        }
        public void SaveTrack(ITrack track)
        {
            dao.SaveTrack(track);
            tracks = dao.GetAllTracks();
        }

        public void DeleteArtist(int Id)
        {
            dao.DeleteArtist(Id);
            artists = dao.GetAllArtists();
        }
        public void DeleteTrack(int Id)
        {
            dao.DeleteTrack(Id);
            tracks = dao.GetAllTracks();
        }
    }
}
