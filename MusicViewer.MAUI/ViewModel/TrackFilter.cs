using INF148187148204.MusicViewer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF148187148204.MusicViewer.MAUI.ViewModel
{
    public class TrackFilter
    {
        public string Query { get; set; } = "";
        public string Operator { get; set; } = "=";
        public int Year { get; set; }

        public IEnumerable<ITrack> Filter(IEnumerable<ITrack> collection)
        {
            IEnumerable<ITrack> output = collection;

            if (!String.IsNullOrEmpty(Query))
            {
                string query = Query.ToLower();

                output = output.Where(t =>
                    t.Name.ToLower().Contains(query) ||
                    t.ReleaseYear.ToString().Contains(query) ||
                    t.Artist.Name.ToLower().Contains(query)
                );
            }

            if (Year > 0)
            {
                switch (Operator)
                {
                    case "<":
                        output = output.Where(t => t.ReleaseYear < Year);
                        break;
                    case ">":
                        output = output.Where(t => t.ReleaseYear > Year);
                        break;
                    case "=":
                        output = output.Where(t => t.ReleaseYear == Year);
                        break;
                    case "≤":
                        output = output.Where(t => t.ReleaseYear <= Year);
                        break;
                    case "≥":
                        output = output.Where(t => t.ReleaseYear >= Year);
                        break;
                }
            }

            return output.Select(t => t);
        }
    }
}
