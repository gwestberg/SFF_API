using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SFF_API.Context;
using SFF_API.Models;
using System.Linq;

namespace SFF_API.Repositories
{
    public class MovieRepository: IMovieRepository
    {
        #region DBcontext
        readonly RentalServiceContext _context;
        public MovieRepository(RentalServiceContext dbContext)
        {
            this._context = dbContext ?? throw new ArgumentNullException("Somethings wrong with the Database-Connection");
        }
        #endregion

        #region Film-relaterade Metoder
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<ActionResult<Movie>> GetMovie(int Id)
        {
            return await _context.Movies.Where(m => m.Id == Id).FirstAsync();
        }
        public async Task<Movie> UpdateMovie(int Id, Movie movie)
        {
            var dbMovie = await _context.Movies
                                        .Where(m => m.Id == movie.Id)
                                        .FirstAsync();
                                        
             _context.Entry(dbMovie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return dbMovie;
        }
        #endregion

    }
}