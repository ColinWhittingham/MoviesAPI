using MoviesAPI.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace MoviesAPI.Controllers
{
    public class MovieRatingController : ApiController
    {
        private readonly IMovieRatingService _movieRatingService;
        private readonly IValidationService _validationService;

        public MovieRatingController(IMovieRatingService movieRatingService, IValidationService validationService)
        {
            _movieRatingService = movieRatingService;
            _validationService = validationService;
        }
      
        // Endpoint A - Find movies with filters
        [HttpGet]
        [Route("Movies/All")]
        public IHttpActionResult GetMoviesWithFilters(HttpRequestMessage httpRequest)
        {
            if (_validationService.TryExtractFiltersFromRequest(httpRequest, out Dictionary<string, string> filters))
            {
                var movies = _movieRatingService.GetMovies(filters);
                if (_validationService.DoResultsContainMovies(movies))
                {
                    //good response
                    return Ok(movies);
                }
                else
                {
                    //none found
                    return NotFound();
                }
            }
            else
            {
                //no filters or invalid values
                return BadRequest("Invalid search filters");
            }
        }

        //Endpoint B - Find top 5 movies
        [HttpGet]
        [Route("Movies/Top")]
        public IHttpActionResult GetTop5Movies()
        {
            var movies = _movieRatingService.GetTop5Movies();
            if (_validationService.DoResultsContainMovies(movies))
            {
                //good response
                return Ok(movies);
            }
            else
            {
                //none found
                return NotFound();
            }
        }

        //Endpoint C - Find top 5 movies for given user
        [HttpGet]
        [Route("Movies/UserTop")]
        public IHttpActionResult GetUserTop5Movies(HttpRequestMessage httpRequest)
        {
            if (httpRequest.Headers.TryGetValues("user", out IEnumerable<string> userIds))
            {
                var userId = userIds.FirstOrDefault(o => !string.IsNullOrWhiteSpace(o));
                if (userId != null && Int32.TryParse(userId, out int userIntId))
                {
                    if (_validationService.DoesUserExist(userIntId))
                    {
                        var movies = _movieRatingService.GetUserTop5Movies(userIntId);
                        if (_validationService.DoResultsContainMovies(movies))
                        {
                            //good response
                            return Ok(movies);
                        }
                        else
                        {
                            //none found
                            return NotFound();
                        }
                    }
                }
            }
            //problem with user Id
            return BadRequest("Invalid user filter");
        }

        //Endpoint D - Store new rating for given user and movie
        [HttpPost]
        [Route("Movies/AddRating")]
        public IHttpActionResult SetUserMovieRating(HttpRequestMessage httpRequest)
        {
            var userId = MovieHelper.TryGetIntParameterFromRequest(httpRequest, "user");
            var movieId = MovieHelper.TryGetIntParameterFromRequest(httpRequest, "movie");
            var rating = MovieHelper.TryGetIntParameterFromRequest(httpRequest, "rating");

            if (userId.HasValue && movieId.HasValue)
            {
                if (rating.HasValue && _validationService.IsRatingValid(rating.Value))
                {
                    if (_validationService.DoesUserExist(userId.Value) && _validationService.DoesMovieExist(movieId.Value))
                    {
                        var userRating = _movieRatingService.SetMovieUserRating(movieId.Value, userId.Value, rating.Value);
                        return Ok(userRating);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest("Invalid or missing rating");
                }
            }
            else
            {
                return BadRequest("Invalid Id parameter for user or movie");
            }
        }
    }
}
