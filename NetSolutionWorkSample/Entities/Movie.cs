using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NetSolutionWorkSample.Entity
{
    public class Movie
    {
        public string Title { get; set; }
        public double Popularity { get; set; }
        public string Overview { get; set; }
        public DateTime Release_Date { get; set; }
    }
}
