using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using SFF_API.Context;
using SFF_API.Models;
using SFF_API.Repositories;
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
           return Ok(await _context.RentAMovie(rental));
        }

        //Gets all available movies
        // GET: api/Rental/AvailableMovies
        [HttpGet("AvailableMovies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetRentableMovies()
        {
            return Ok(await _context.GetRentableMovies());
        }
        
        //Gets all active rentals
        // GET: api/Rental/ActiveRentals
        [HttpGet("ActiveRentals")]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            return Ok(await _context.GetRentals());
        }

        //Gets the specific rental
        // GET: api/Rental/{id}
        [HttpGet("{id}")]
        public async  Task<ActionResult<IEnumerable<Rental>>> GetRental(int id)
        {
            return Ok(await _context.GetRental(id));
        }

        //GET: api/Rental/Studio/RentedMovies/{id}
        [HttpGet("Studio/RentedMovies/{id}")]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentalsForStudio(int id)
        {
            return Ok(await _context.GetRentalsForStudio(id));
        }

        // DELETE: api/Rentals/{id}
        // Deletes/Returns a Movie
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rental>> ReturnMovie(int id)
        {

            return Ok(await _context.ReturnMovie(id));
        }

        //// GET: api/Rental/Label
        //[HttpGet("Label/{id}")]

        //GET api/Rental/Label.{format}/{id}
        [HttpGet("Label.{format}/{id}"), FormatFilter]
        public async Task<ActionResult<Label>> GetLabelForRental(int id)
        {
            return Ok(await _context.GetLabelForRental(id));
        }
    }
    #endregion
}
