using System;
using System.Collections.Generic;
using System.Text;

namespace SFF_API.Models
{
    [Serializable]
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public bool IsDigital { get; set; }
        public int? NumCopies { get; set; }

        public Movie ReduceAmount(Movie movie)
        {
            movie.NumCopies--;
            return movie;
        }

        public Movie IncreaseAmount(Movie movie)
        {
            movie.NumCopies++;
            return movie;
        }
    }
}
