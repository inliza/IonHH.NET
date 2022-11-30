using IonHHBETest.DataDB;
using IonHHBETest.Dto;
using IonHHBETest.Helpers;

namespace IonHHBETest.Services.Interfaces
{
    public interface IReviewService
    {
        Task<List<Review>> GetReviews(int IdMovie);
        Task<ServicesResponse> addReview(ReviewCreationDto review);
    }
}
