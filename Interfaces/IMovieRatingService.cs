using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAPI.Interfaces
{
    public interface IMovieRatingService
    {
        IEnumerable<Movie> GetMovies(Dictionary<string, string> filters);
        IEnumerable<Movie> GetTop5Movies();
        IEnumerable<Movie> GetUserTop5Movies(int userId);
        UserRating SetMovieUserRating(int movieId, int userId, int rating);
    }
}
