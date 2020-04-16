using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SFF_API.Models;

namespace SFF_API.Repositories
{
    public interface IReviewRepository
    {
        Task <Review> AddReview(Review review);
        Task<IEnumerable<Review>> GetReviews();
        Task<IEnumerable<Review>> GetReviewByMovie(int id);
        Task<IEnumerable<Review>> GetReviewByStudio(int id);
        Task<Review> DeleteReview(int Id);
    }
}
