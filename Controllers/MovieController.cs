using Microsoft.AspNetCore.Mvc;
using SFF_API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SFF_API.Repositories;

namespace SFF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        #region DBcontext RentalServiceRepository
        readonly IMovieRepository _context;
        public MovieController(IMovieRepository context)
        {
            this._context = context ?? throw new ArgumentNullException("Somethings wrong with the connection");
        }
        #endregion


        #region Film-relaterade Metoder

        //Create a movie and return it
        //Checks if the title already exists in the library
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            if(movie==null)
            {
                return NotFound();
            }
            await _context.AddMovie(movie);
            return Ok(movie);
        }

        //GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.GetMovies();
        }
        
        //GET: api/Movies/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            return Ok( await _context.GetMovie(id)); 
        }

        //PUT: api/Movie/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieIAction(int id, Movie movie)
        {
            if(movie.Id != id)
            {
                return BadRequest();
            }
            if(movie==null)
            {
                return NotFound();
            }
            return Ok(await _context.UpdateMovie(id,movie));
        }

        #endregion

    }
}