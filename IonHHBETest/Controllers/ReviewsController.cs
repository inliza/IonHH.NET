using IonHHBETest.Dto;
using IonHHBETest.Helpers;
using IonHHBETest.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IonHHBETest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService service;
        public ReviewsController(IReviewService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> getReviews(int idMovie)
        {
            try
            {
                if (idMovie <= 0)
                {
                    return StatusCode(400, new ServicesResponse(400, "Invalid movie", null));
                }

                var reviews = await service.GetReviews(idMovie);
                var response = new ServicesResponse(reviews.Count > 0 ? 200 : 404, reviews.Count > 0 ? "Success" : "Not Found", reviews);
                return StatusCode(response.Code, response); ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServicesResponse(500, "Internal error", ex));
            }



        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> createReview(ReviewCreationDto review)
        {
            try
            {
                if (review == null)
                {
                    return StatusCode(400, new ServicesResponse(400, "Invalid review", review));
                }
                var response = await service.addReview(review);
                return StatusCode(response.Code, response); ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServicesResponse(500, "Internal error", ex));
            }

        }


    }



}
