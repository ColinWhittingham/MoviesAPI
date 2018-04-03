namespace MoviesAPI.Services
{
    using MoviesAPI.Interfaces;
    using MoviesAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Data.Entity;

    public class MovieRatingService : IMovieRatingService
    {
        private readonly IContextContainer _contextContainer;

        public MovieRatingService(IContextContainer contextContainer)
        {
            _contextContainer = contextContainer;
        }

        public IEnumerable<Movie> GetMovies(Dictionary<string, string> filters)
        {
            var title = filters["title"];
            var year = filters["year"];
            var genre = filters["genre"];

            using (var ent = _contextContainer.Entities)
            {
                return ent.Movies.Include(o => o.Ratings).Where(o => 
                (title == null || o.Title.Contains(title)) &&
                (year == null || o.YearOfRelease.ToString() == year) &&
                (genre == null || o.Genre == genre)
                ).ToList();                     
            }          
        }

        public IEnumerable<Movie> GetTop5Movies()
        {
            using (var ent = _contextContainer.Entities)
            {
                return ent.Movies.Include(o => o.Ratings).ToList().OrderByDescending(o => o.AverageRating).ThenBy(o => o.Title).Take(5);
            }
        }

        public IEnumerable<Movie> GetUserTop5Movies(int userId)
        {
            using (var ent = _contextContainer.Entities)
            {
                return ent.UserRatings
                    .Include(r => r.Movie)
                    .Where(r => r.UserId == userId)
                    .OrderByDescending(r => r.Score)
                    .ThenBy(r => r.Movie.Title)
                    .Select(r => r.Movie)
                    .Include(o => o.Ratings)
                    .ToList()
                    .Take(5);
            }
        }

        public UserRating SetMovieUserRating(int movieId, int userId, int rating)
        {
            using (var ent = _contextContainer.Entities)
            {
                UserRating userRating;
                userRating = ent.UserRatings.FirstOrDefault(o => o.MovieId == movieId && o.UserId == userId);
                if (userRating == null)
                {
                    userRating = new UserRating { MovieId = movieId, UserId = userId, Score = rating };
                    ent.UserRatings.Add(userRating);
                }
                else
                {
                    userRating.Score = rating;
                }
                ent.SaveChanges();
                return userRating;
            }
        }
    }
}