using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFF_API.Context;
using SFF_API.Models;
using SFF_API.Repositories;

namespace SFF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
     #region DBcontext
        readonly IReviewRepository _context;
        public ReviewController(IReviewRepository context)
        {
            this._context = context ?? throw new ArgumentNullException("Somethings wrong with the Database-Connection");
        }
        #endregion

     #region Recension-relaterade metoder
        
        //POST: api/Review
        [HttpPost]
        public async Task<ActionResult<Review>> AddReview(Review review)
        {
            return Ok(await _context.AddReview(review));
        }

        //GET: api/Review
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> PrintAllReviews()
        {
            return Ok(await _context.GetReviews());
        }

        //Gets Reviews for a specific Movie
        //GET: api/Reviews/{movieId}
        [HttpGet("Movie/{id}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewByMovie(int id)
        {
            return Ok(await _context.GetReviewByMovie(id));
        }

        //Gets Reviews by a specific studio
        //GET: api/Reviews/{studioId}
        [HttpGet("Studio/{id}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewByStudio(int id)
        {
            return Ok(await _context.GetReviewByStudio(id));
        }
        
        //DELETE api/Review/{id}
        [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteReview(int id)
        {
            return Ok(await _context.DeleteReview(id));
        }

        #endregion


    }
    }