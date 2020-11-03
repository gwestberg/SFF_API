using System;
using SFF_API.Models;

namespace SFF_API.ModelsDto
{
    class RentalDto
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public string MovieName { get; set; }
        public string StudioName { get; set; }

        public RentalDto(Rental rental)
        {
            this.Id = rental.Id;
            this.DateRented = rental.DateRented;
            this.MovieName = rental.Movie.Title;

            if (rental.Studio != null)
            {
            this.StudioName = rental.Studio.Name;
            }
        }
    }
}