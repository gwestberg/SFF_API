using System;
using System.Collections.Generic;
using SFF_API.Context;
using SFF_API.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace SFF_API.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        #region DBcontext
        readonly RentalServiceContext _context;
        public RentalRepository(RentalServiceContext dbContext)
        {
            this._context = dbContext ?? throw new ArgumentNullException("Somethings wrong with the Database-Connection");
        }
        #endregion

        public async Task<Rental> RentAMovie(Rental rental)
        {
            var movie = await _context.Movies.FindAsync(rental.MovieId);
            if (!movie.IsDigital && movie.NumCopies > 0)
            {
                movie.ReduceAmount(movie);
            }

            if (rental != null)
            {
                rental.DateRented = DateTime.UtcNow;
                await _context.Rentals.AddAsync(rental);
            }
            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return rental;
        }

        public async Task<IEnumerable<Movie>> GetRentableMovies()
        {
            return await _context.Movies
                     .Where(r => r.IsDigital || !r.IsDigital && r.NumCopies > 0)
                     .ToListAsync();
        }

        public async Task<IEnumerable<Rental>> GetRentals()
        {
            return await _context.Rentals
                                .Include(x => x.Movie)
                                .Include(x => x.Studio)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Rental>> GetRental(int id)
        {
            return await _context.Rentals
                                .Where(x => x.Id == id)
                                .Include(x => x.Movie)
                                .Include(x => x.Studio)
                                .ToListAsync();
        }
        public async Task<IEnumerable<Rental>> GetRentalsForStudio(int id)
        {
            return await _context.Rentals
                                .Where(r => r.StudioId == id)
                                .Include(r => r.Movie)
                                .Include(r => r.Studio)
                                .ToListAsync();
        }

        public async Task<Rental> ReturnMovie(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            var movie = await _context.Movies.FindAsync(rental.MovieId);
            if (!movie.IsDigital)
            {
                movie.IncreaseAmount(movie);
            }
            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();
            return rental;
        }



        public async Task<Label> GetLabelForRental(int id)
        {
            var rental = await _context.Rentals.Where(r=>r.Id == id)
                                                .Include(m=>m.Movie)
                                                .Include(s=>s.Studio)
                                                .FirstAsync();

            var label = new Label();
            label.MovieTitle = rental.Movie.Title;
            label.StudioLocation = rental.Studio.Location;
            label.DateRented = DateTime.UtcNow;
            return label;
        }
    }
}
