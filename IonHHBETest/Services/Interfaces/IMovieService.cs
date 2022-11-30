using IonHHBETest.DataDB;
using IonHHBETest.Dto;
using IonHHBETest.Helpers;

namespace IonHHBETest.Services.Interfaces
{
    public interface IMovieService
    {
        Task<Movie> GetById(int IdMovie);
        Task<List<Movie>> GetMovies(string orderBy, int? pageIndex, int? pageSize);
        Task<ServicesResponse> CreateMovie(MovieCreationDto Movie);
        Task<ServicesResponse> DisableMovie(int IdMovie);

    }
}
