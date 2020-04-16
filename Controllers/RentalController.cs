using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF_API.Context;
using SFF_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SFF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        #region DBcontext
        readonly RentalServiceContext _context;
        public RentalController(RentalServiceContext dbContext)
        {
            this._context = dbContext ?? throw new ArgumentNullException("Somethings wrong with the Database-Connection");
        }
        #endregion

        #region Rentals
        //Rent a movie
        // POST: api/Rentals
        [HttpPost]
        public async Task<ActionResult<Rental>> RentAMovie(Rental rental)
        {
            /* TODO: FLYTTA UT!!! LOGIK SKA INTE VARA I CONTROLLERS*/
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

            throw new OperationCanceledException("Rental Could Not Be Executed");
        }

        /* TODO: FLYTTA UT!!! LOGIK SKA INTE VARA I CONTROLLERS*/
        //Gets all available movies
        // GET: api/Rental/AvailableMovies
        [HttpGet("AvailableMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetRentableMovies()
        {
            return await _context.Movies
                                 .Where(r => r.IsDigital || !r.IsDigital && r.NumCopies > 0) 
                                 .ToListAsync();
        }
        
        //Gets all active rentals
        // GET: api/Rental/ActiveRentals
        [HttpGet("ActiveRentals")]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            return await _context.Rentals
                                 .Include(r => r.Movie)
                                 .Include(r => r.Studio)
                                 .ToListAsync();
        }

        //Gets the specific rental
        // GET: api/Rental/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            return rental;
        }

        //GET: api/Rental/Studio/RentedMovies/{id}
        [HttpGet("Studio/RentedMovies/{id}")]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentalsForStudio(int id)
        {
            var rental = await _context.Rentals
                                .Where(r => r.StudioId == id)
                                .Include(r => r.Movie) 
                                .Include(r=> r.Studio)
                                .ToListAsync();
            if (rental == null)
            {
                return NotFound();
            }
            return rental;
        }

        // DELETE: api/Rentals/{id}
        // Deletes/Returns a Movie
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rental>> ReturnMovie(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            /* TODO: FLYTTA UT!!! LOGIK SKA INTE VARA I CONTROLLERS*/
            var movie = await _context.Movies.FindAsync(rental.MovieId);
            if (!movie.IsDigital)
            {
                movie.IncreaseAmount(movie);
            }
            //------------------------------//
            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /* TODO: FLYTTA UT!!! LOGIK SKA INTE VARA I CONTROLLERS*/
        // GET: api/Rental/Label
        [HttpGet("Label/{id}")]
        public async Task<ActionResult<XElement>>GetLabelForRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id) ;
            if (rental == null)
            {
                return NotFound();
            }

            var movie = _context.Movies
                                    .Where(m => m.Id == rental.MovieId)
                                    .Select(m => m.Title);
            var studio = _context.Studios
                                    .Where(s => s.Id == rental.StudioId)
                                    .Select(s => s.Name);

            var xmlfromLinq = new XElement("EtikettData",
                new XElement("FilmNamn",movie
                    ),
                new XElement("Ort",
                    studio),
                new XElement("Datum",
                    DateTime.UtcNow));

            return Content (xmlfromLinq.ToString());
        }
    }
    #endregion
}
