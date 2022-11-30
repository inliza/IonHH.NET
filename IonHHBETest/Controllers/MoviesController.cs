using IonHHBETest.DataDB;
using IonHHBETest.Dto;
using IonHHBETest.Helpers;
using IonHHBETest.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IonHHBETest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService service;
        public MoviesController(IMovieService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> getMovies(string? orderBy, int? pageIndex, int? pageSize )
        {
            try
            {
                if((pageIndex == null && pageSize != null) || (pageIndex != null && pageSize == null))
                {
                    return StatusCode(400, new ServicesResponse(400, "Invalid pagination configuration. To be able to paginate you must send pageIndex and PageSize", null));
                }

                var movies = await service.GetMovies(orderBy, pageIndex, pageSize);
                var response = new ServicesResponse(movies.Count > 0 ? 200 : 404, movies.Count > 0 ? "Success" : "Not Found", movies);
                return StatusCode(response.Code, response); ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServicesResponse(500, "Internal error", ex));
            }



        }


        [HttpGet]
        [Route("Get/{movieId}")]
        public async Task<IActionResult> getMovie(int movieId)
        {
            try
            {
                var movie = await service.GetById(movieId);
                var response = new ServicesResponse(movie != null ? 200 : 404, movie != null? "Success" : "Not Found", movie);
                return StatusCode(response.Code, response); ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServicesResponse(500, "Internal error", ex));
            }

        }



        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> createMovie(MovieCreationDto movie)
        {
            try
            {
                if (movie == null)
                {
                    return StatusCode(400, new ServicesResponse(400, "Invalid movie", movie));
                }
                var response = await service.CreateMovie(movie);
                return StatusCode(response.Code, response); ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServicesResponse(500, "Internal error", ex));
            }

        }

        [HttpPatch]
        [Route("Disable")]
        public async Task<IActionResult> DisabledMovie(int idMovie)
        {
            try
            {
                if (idMovie <= 0)
                {
                    return StatusCode(400, new ServicesResponse(400, "Invalid movie", null));
                }
                var response = await service.DisableMovie(idMovie);
                return StatusCode(response.Code, response); ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServicesResponse(500, "Internal error", ex));
            }



        }

    }



}
