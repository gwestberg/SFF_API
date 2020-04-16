using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF_API.Context;
using SFF_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriviaController : ControllerBase
    {
        #region DBcontext
        readonly RentalServiceContext _context;
        public TriviaController(RentalServiceContext dbContext)
        {
            this._context = dbContext ?? throw new ArgumentNullException("Somethings wrong with the Database-Connection");
        }
        #endregion

        #region Trivia-related

        // POST: api/Trivia
        [HttpPost]
        public async Task<ActionResult<Trivia>> PostTrivia(Trivia trivia)
        {
            try
            {
                await _context.Trivias.AddAsync(trivia);
            }
            catch (Exception e)
            {
                throw e;
            }
            await _context.SaveChangesAsync();
            return trivia;
        }

        // GET: api/Trivia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTrivias()
        {
            return await _context.Trivias
                            .Include(t => t.Movie)
                            .Include(t => t.Studio)
                            .ToListAsync();
        }

        // GET: api/Trivia/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTrivia(int id)
        {
            var trivia = _context.Trivias
                            .Where(t => t.Id == id)
                            .Include(t => t.Movie)
                            .Include(t => t.Studio)
                            .ToListAsync(); ;
            if (trivia == null)
            {
                return NotFound();
            }

            return await trivia;
        }

        // GET: api/Trivia/Movie/{id}
        [HttpGet("Movie/{id}")]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTriviaByMovieId(int id)
        {
            var trivia = _context.Trivias
                            .Where(t => t.Movie.Id == id)
                            .Include(t => t.Movie)
                            .Include(t => t.Studio)
                            .ToListAsync();

            if (trivia == null)
            {
                return NotFound();
            }

            return await trivia;
        }

        // PUT: api/Trivia/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrivia(int id, Trivia trivia)
        {
            if (id != trivia.Id)
            {
                return BadRequest();
            }
            using (_context)
            {
                _context.Entry(trivia).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        // DELETE: api/Trivia/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trivia>> DeleteTrivia(int id)
        {
            var trivia = await _context.Trivias.FindAsync(id);
            if (trivia == null)
            {
                return NotFound();
            }
            _context.Entry(trivia).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return Ok();
        }

        #endregion


    }
}