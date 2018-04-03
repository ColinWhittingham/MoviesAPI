namespace MoviesAPI.Services
{
    using MoviesAPI.Interfaces;
    using MoviesAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web;

    public class ValidationService : IValidationService
    {
        private readonly IContextContainer _contextContainer;

        public ValidationService(IContextContainer contextContainer)
        {
            _contextContainer = contextContainer;
        }

        public bool DoesMovieExist(int movieId)
        {
            using (var ent = _contextContainer.Entities)
            {
                return ent.Movies.Any(o => o.Id == movieId);
            }
        }

        public bool DoesUserExist(int userId)
        {
            using (var ent = _contextContainer.Entities)
            {
                return ent.Users.Any(o => o.Id == userId);
            }
        }

        public bool DoResultsContainMovies(IEnumerable<Movie> results)
        {
            return results?.Any() == true;
        }

        public bool IsRatingValid(int rating)
        {
            return rating >= 1 && rating <= 5;
        }

        public bool TryExtractFiltersFromRequest(HttpRequestMessage httpRequest, out Dictionary<string, string> filters)
        {
            filters = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { "title", null },
                    { "year", null },
                    { "genre", null }
                };

            var filterNames = new List<string>(filters.Keys);

            foreach (var filterName in filterNames)
            {
                if (httpRequest.Headers.TryGetValues(filterName, out IEnumerable<string> filterValues))
                {
                    var filterValue = filterValues.FirstOrDefault(o => !string.IsNullOrWhiteSpace(o));
                    if (filterValue != null && (filterName != "year" || (filterName == "year" && Int32.TryParse(filterValue, out int intResult))))
                    {
                        filters[filterName] = filterValue;
                    }
                }
            }
            return filters.Any(o => o.Value != null);
        }
    }
}