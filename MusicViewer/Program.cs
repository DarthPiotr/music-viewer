﻿using INF148187148204.MusicViewer.Interfaces;
using INF148187148204.MusicViewer.BLC;
using System.Xml.Linq;

namespace INF148187148204.MusicViewer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string execPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            Console.WriteLine("Executing from: {0}", execPath);

            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DBLibraryName"];
            BLController blc = BLController.GetInstance(libraryName);

            Console.WriteLine("=== Artists ===");
            foreach (IArtist a in blc.GetArtists())
            {
                Console.WriteLine("[{0}] {1}", a.ID, a.Name);
            }

            Console.WriteLine("=== Tracks ===");
            foreach (ITrack t in blc.GetTracks())
            {
                Console.WriteLine("[{0}] {1} - {2} ({3}) {4}",
                    t.ID, t.Artist.Name, t.Name, t.ReleaseYear, t.Genre);
            }

            Console.WriteLine("=== Stuff happened ===");
            var track = blc.CreateNewTrack();
            track.Name = "MY NEW FANCY TRACK";
            track.Artist = blc.GetArtist(3);
            track.Genre = Core.Genre.Electronic;
            track.ReleaseYear = 1998;
            blc.SaveTrack(track);
            

            Console.WriteLine("=== Artists ===");
            foreach (IArtist a in blc.GetArtists())
            {
                Console.WriteLine("[{0}] {1}", a.ID, a.Name);
            }

            Console.WriteLine("=== Tracks ===");
            foreach (ITrack t in blc.GetTracks())
            {
                Console.WriteLine("[{0}] {1} - {2} ({3}) {4}",
                    t.ID, t.Artist.Name, t.Name, t.ReleaseYear, t.Genre);
            }
        }
    }
}