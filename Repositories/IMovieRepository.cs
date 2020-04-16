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
        Task<ActionResult<IEnumerable<Movie>>> GetMovies();
        Task<ActionResult<Movie>> GetMovie(int id);
        Task<ActionResult<Movie>> AddMovie(Movie movie);
        Task<Movie> UpdateMovie(int Id, Movie movie);
    }
}
