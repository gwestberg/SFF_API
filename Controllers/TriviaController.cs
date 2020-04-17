using Microsoft.AspNetCore.Mvc;
using SFF_API.Models;
using SFF_API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriviaController : ControllerBase
    {
        #region DBcontext
        readonly ITriviaRepository _context;
        public TriviaController(ITriviaRepository dbContext)
        {
            this._context = dbContext ?? throw new ArgumentNullException("Somethings wrong with the Database-Connection");
        }
        #endregion

        #region Trivia-related

        // POST: api/Trivia
        [HttpPost]
        public async Task<ActionResult<Trivia>> AddTrivia(Trivia trivia)
        {
            return await _context.AddTrivia(trivia);
        }

        // GET: api/Trivia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTrivias()
        {
            return Ok(await _context.GetTrivias());
        }

        // GET: api/Trivia/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTrivia(int id)
        {
            return Ok(await _context.GetTrivia(id));
        }

        // GET: api/Trivia/Movie/{id}
        [HttpGet("Movie/{id}")]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTriviaByMovieId(int id)
        {
            return Ok(await _context.GetTriviaByMovieId(id));
        }

        // PUT: api/Trivia/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrivia(int id, Trivia trivia)
        {
            return Ok(await _context.UpdateTrivia(id, trivia));
        }

        // DELETE: api/Trivia/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trivia>> DeleteTrivia(int id)
        {
            return Ok(await _context.DeleteTrivia(id));
        }

        #endregion


    }
}