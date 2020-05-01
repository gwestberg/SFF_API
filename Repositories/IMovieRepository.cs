using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SFF_API.Models;

namespace SFF_API.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovie(int id);
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> UpdateMovie(int Id, Movie movie);
        Task <Movie> DeleteMovie(int id);
    }
}
