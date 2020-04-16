using System;

namespace SFF_API.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }


        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; }
    }
}