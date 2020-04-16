using System;
using System.Collections.Generic;
using System.Text;
using SFF_API.Models;

namespace SFF_API.Repositories
{
    public interface IRentalServiceRepositoryWrapper
    {
        abstract public IEnumerable<Movie> PrintMovies();
        abstract Movie PrintMovie(int MovieId);
        abstract void AddMovie(Movie movie);
        abstract void UpdateNumCopiesOfMovie(int movieId, int NumCopies);
        abstract bool MovieExistsByTitle(Movie movie);
        abstract bool MovieExistsById(int movieId);


        abstract IEnumerable<Studio> PrintStudios();
        abstract Studio PrintStudio(int StudioId);
        abstract void AddStudio(Studio studio);
        abstract void DeleteStudio(int studioId);
        abstract void UpdateStudio(int studioId, string name, string location);
        abstract bool StudioExistsByTitle(Studio studio);
        abstract bool StudioExistsById(int studioId);

        abstract void AddReview(Review review);
        abstract IEnumerable<Review> PrintAllReviews();
        abstract IEnumerable<Review> PrintReviewByMovieId(int movieId);
        abstract IEnumerable<Review> PrintReviewByStudioId(int studioId);
        abstract bool Save();
    }
}
