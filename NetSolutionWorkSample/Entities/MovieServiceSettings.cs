using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetSolutionWorkSample.Entities
{
    public class MovieServiceSettings
    {
        public string BaseUri { get; set; }
        public string TopRated_Uri { get; set; }
        public string Popular_Uri { get; set; }
        public string Upcoming_Uri { get; set; }
        public string Search_Movie_Uri { get; set; }
        public string Search_Movie_Uri_End { get; set; }
        public string Movie_Details_Uri { get; set; }
        public string ApiKey { get; set; }

    }
}
