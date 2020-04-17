using System;
using System.Collections.Generic;
using SFF_API.Context;
using SFF_API.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SFF_API.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        #region DBcontext
        readonly RentalServiceContext _context;
        public ReviewRepository(RentalServiceContext dbContext)
        {
            this._context = dbContext ?? throw new ArgumentNullException("Somethings wrong with the Database-Connection");
        }
        #endregion

        public async Task<Review> AddReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<IEnumerable<Review>> GetReviews()
        {
            return await _context.Reviews
                            .Include(r => r.Movie)
                            .Include(s => s.Studio)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewByMovie(int id)
        {
            return await _context.Reviews
                .Where(r => r.Movie.Id == id)
                .Include(s => s.Studio)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewByStudio(int id)
        {
            return await _context.Reviews
                .Where(r => r.Studio.Id == id)
                .Include(s => s.Studio)
                .ToListAsync();

        }
        public async Task<Review> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Entry(review).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return review;
        }

    }
}