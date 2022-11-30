using IonHHBETest.DataDB;
using IonHHBETest.Dto;
using IonHHBETest.Helpers;
using IonHHBETest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace IonHHBETest.Services
{
    public class MovieService : IMovieService
    {
        private readonly carrosf1_ionhhTestContext dbContext;

        public MovieService()
        {
            dbContext = new carrosf1_ionhhTestContext();
        }

        public async Task<ServicesResponse> CreateMovie(MovieCreationDto Movie)
        {
            var movie = dbContext.Movies.Where(x => x.Title == Movie.Title).FirstOrDefault();
            if (movie != null)
            {
                return new ServicesResponse(400, "Movie already exists", movie);
            }

            movie = new Movie();
            movie.Disabled = false;
            movie.Title = Movie.Title;
            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();

            return new ServicesResponse(200, "Movie Created", Movie);
        }

        public async Task<ServicesResponse> DisableMovie(int IdMovie)
        {
            var movie = await dbContext.Movies.SingleOrDefaultAsync(x => x.Id == IdMovie);
            if (movie == null)
            {
                return new ServicesResponse(404, "Movie does not exists", null);
            }

            if (movie.Disabled)
            {
                return new ServicesResponse(428, "Movie had already been disabled", movie.Title);
            }

            movie.Disabled = true;
            await dbContext.SaveChangesAsync();

            return new ServicesResponse(200, "Movie Disabled", movie.Title);
        }

        public async Task<Movie> GetById(int IdMovie)
        {
            return await dbContext.Movies.SingleOrDefaultAsync(x => x.Id == IdMovie);
        }

        public async Task<List<Movie>> GetMovies(string orderBy, int? pageIndex, int? pageSize)
        {
            if (orderBy == null)
                orderBy = "Id";
            var res = await dbContext.Movies.AsQueryable().OrderBy(orderBy).ToListAsync();
            if (pageSize != null)
                return res.Skip(Convert.ToInt32((pageIndex - 1) * pageSize)).Take(Convert.ToInt32(pageSize)).ToList();
            return res;
        }

    }
}
