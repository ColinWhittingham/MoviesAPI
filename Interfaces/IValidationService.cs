namespace MoviesAPI.Interfaces
{
    using MoviesAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public interface IValidationService
    {
        //is there at least one filter
        bool TryExtractFiltersFromRequest(HttpRequestMessage httpRequest, out Dictionary<string, string> filters);
        //does user exist
        bool DoesUserExist(int userId);
        //does movie exist
        bool DoesMovieExist(int movieId);
        //is rating a valid value
        bool IsRatingValid(int rating);
        //are there any results
        bool DoResultsContainMovies(IEnumerable<Movie> results);
    }
}
