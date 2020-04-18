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
            var trivias = await _context.AddTrivia(trivia);
            if (trivias == null)
            {
                NotFound();
            }
            return Ok(trivias);
        }

        // GET: api/Trivia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTrivias()
        {
            var trivias = await _context.GetTrivias();
            if (trivias == null)
            {
                NotFound();
            }
            return Ok(trivias);
        }

        // GET: api/Trivia/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTrivia(int id)
        {
            var trivias = await _context.GetTrivia(id);
            if (trivias == null)
            {
                NotFound();
            }
            return Ok(trivias);
        }

        // GET: api/Trivia/Movie/{id}
        [HttpGet("Movie/{id}")]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTriviaByMovieId(int id)
        {
            var trivias = await _context.GetTriviaByMovieId(id);
            if (trivias == null)
            {
                NotFound();
            }
            return Ok(trivias);
        }

        // PUT: api/Trivia/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrivia(int id, Trivia trivia)
        {
            if (id != trivia.Id)
            {
                BadRequest();
            }
            if (trivia == null)
            {
                NotFound();
            }
            return Ok(await _context.UpdateTrivia(id, trivia));
        }

        // DELETE: api/Trivia/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trivia>> DeleteTrivia(int id)
        {
            var trivias = await _context.DeleteTrivia(id);
            if (trivias == null)
            {
                NotFound();
            }
            return Ok(trivias);
        }

        #endregion


    }
}