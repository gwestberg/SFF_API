using Microsoft.AspNetCore.Mvc;
using SFF_API.Models;
using SFF_API.ModelsDto;
using SFF_API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        #region DBcontext
        readonly IRentalRepository _context;
        public RentalController(IRentalRepository dbContext)
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
            if (rental == null)
            {
                NotFound();
            }
            return Ok(new RentalDto(await _context.RentAMovie(rental)));
        }

        //Gets all available movies
        // GET: api/Rental/AvailableMovies
        [HttpGet("AvailableMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetRentableMovies()
        {
            var rentalsFromRepo = await _context.GetRentableMovies();
            if (rentalsFromRepo == null)
            {
                NotFound();
            }

            var movies = new List<MovieDto>();
            foreach (var movie in rentalsFromRepo)
            {
                movies.Add(new MovieDto(movie));
            }
            return Ok(movies);
        }

        //Gets all active rentals
        // GET: api/Rental
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            var rentalsFromRepo = await _context.GetRentals();
            if (rentalsFromRepo == null)
            {
                NotFound();
            }

            var rentals = new List<RentalDto>();
            foreach (var rental in rentalsFromRepo)
            {
                rentals.Add(new RentalDto(rental));
            }
            return Ok(rentals);
        }

        //Gets the specific rental
        // GET: api/Rental/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRental(int id)
        {
            var rental = new RentalDto( await _context.GetRental(id));
            if (rental == null)
            {
                NotFound();
            }
            return Ok(rental);
        }

        //GET: api/Rental/Studio/RentedMovies/{id}
        [HttpGet("Studio/RentedMovies/{id}")]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentalsForStudio(int id)
        {
            var rentals = await _context.GetRentalsForStudio(id);
            if (rentals == null)
            {
                NotFound();
            }
            return Ok(rentals);
        }

        // DELETE: api/Rentals/{id}
        // Deletes/Returns a Movie
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rental>> ReturnMovie(int id)
        {
            var rental = await _context.ReturnMovie(id);
            if (rental == null)
            {
                NotFound();
            }
            return Ok(rental);
        }

        //// GET: api/Rental/Label
        //[HttpGet("Label/{id}")]

        //GET api/Rental/Label.{format}/{id}
        [HttpGet("Label.{format}/{id}"), FormatFilter]
        public async Task<ActionResult<Label>> GetLabelForRental(int id)
        {
            var label = await _context.GetLabelForRental(id);
            if (label == null)
            {
                NotFound();
            }
            return Ok(label);
        }
    }
    #endregion
}
