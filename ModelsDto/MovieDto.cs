using SFF_API.Models;
namespace SFF_API.ModelsDto
{
    class MovieDto
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string NumCopies { get; set; }

        private MovieDto()
        {

        }
        public MovieDto(Movie movie)
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
            this.Genre = movie.Genre;
            if (!movie.IsDigital)
            {
                this.NumCopies = movie.NumCopies.ToString();
            }
            else
                this.NumCopies = "Digital";
        }
    }



}