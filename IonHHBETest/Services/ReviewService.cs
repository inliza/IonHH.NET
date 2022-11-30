using IonHHBETest.DataDB;
using IonHHBETest.Dto;
using IonHHBETest.Helpers;
using IonHHBETest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IonHHBETest.Services
{
    public class ReviewService : IReviewService
    {
        private readonly carrosf1_ionhhTestContext dbContext;

        public ReviewService()
        {
            dbContext = new carrosf1_ionhhTestContext();
        }

        public async Task<ServicesResponse> addReview(ReviewCreationDto review)
        {
            var movie = dbContext.Movies.Where(x => x.Id == review.MovieId).FirstOrDefault();
            if (movie == null)
            {
                return new ServicesResponse(400, "Movie does not exists", movie);
            }
            var re = new Review();
            re.Rating = review.Rating;
            re.Comment = review.Comment;
            re.Created_dt = DateTime.Now;
            re.MovieId = review.MovieId;
            await dbContext.Reviews.AddAsync(re);
            await dbContext.SaveChangesAsync();

            return new ServicesResponse(200, "Review Created", review);
        }

        public async Task<List<Review>> GetReviews(int IdMovie)
        {
            return await dbContext.Reviews.Where(x => x.MovieId == IdMovie).ToListAsync();
        }
    }
}
