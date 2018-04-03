namespace MoviesAPI
{
    using MoviesAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    public class DBInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            IList<Movie> defaultMovies = new List<Movie>();
            IList<User> defaultUsers = new List<User>();
            IList<UserRating> defaultRatings = new List<UserRating>();

            defaultMovies.Add(new Movie { Id = 1, Title = "Groundhog Day", Genre = "Comedy", YearOfRelease = 1985, RunningTimeMins = 94 });
            defaultMovies.Add(new Movie { Id = 2, Title = "Jurassic Park", Genre = "Action", YearOfRelease = 1994, RunningTimeMins = 98 });
            defaultMovies.Add(new Movie { Id = 3, Title = "Mrs. Doubtfire", Genre = "Comedy", YearOfRelease = 1992, RunningTimeMins = 88 });
            defaultMovies.Add(new Movie { Id = 4, Title = "Scream", Genre = "Horror", YearOfRelease = 1999, RunningTimeMins = 102 });
            defaultMovies.Add(new Movie { Id = 5, Title = "Lord of the Rings", Genre = "Action", YearOfRelease = 2001, RunningTimeMins = 180 });
            defaultMovies.Add(new Movie { Id = 6, Title = "Moon", Genre = "SciFi", YearOfRelease = 2009, RunningTimeMins = 99 });
            defaultMovies.Add(new Movie { Id = 7, Title = "The Martian", Genre = "SciFi", YearOfRelease = 2015, RunningTimeMins = 104 });

            defaultUsers.Add(new User { Id = 1, Name = "Colin" });
            defaultUsers.Add(new User { Id = 2, Name = "Dog" });
            defaultUsers.Add(new User { Id = 3, Name = "Cat" });
            defaultUsers.Add(new User { Id = 4, Name = "Bird" });
            defaultUsers.Add(new User { Id = 5, Name = "Turtle" });

            defaultRatings.Add(new UserRating { Id = 1, MovieId = 1, UserId = 1, Score = 5 });
            defaultRatings.Add(new UserRating { Id = 2, MovieId = 2, UserId = 1, Score = 4 });
            defaultRatings.Add(new UserRating { Id = 3, MovieId = 3, UserId = 1, Score = 3 });
            defaultRatings.Add(new UserRating { Id = 4, MovieId = 4, UserId = 1, Score = 2 });
            defaultRatings.Add(new UserRating { Id = 5, MovieId = 5, UserId = 1, Score = 4 });
            defaultRatings.Add(new UserRating { Id = 6, MovieId = 6, UserId = 1, Score = 4 });
            defaultRatings.Add(new UserRating { Id = 7, MovieId = 7, UserId = 2, Score = 5 });
            defaultRatings.Add(new UserRating { Id = 8, MovieId = 4, UserId = 2, Score = 2 });
            defaultRatings.Add(new UserRating { Id = 9, MovieId = 5, UserId = 2, Score = 5 });
            defaultRatings.Add(new UserRating { Id = 10, MovieId = 6, UserId = 3, Score = 2 });
            defaultRatings.Add(new UserRating { Id = 11, MovieId = 2, UserId = 3, Score = 3 });
            defaultRatings.Add(new UserRating { Id = 12, MovieId = 3, UserId = 3, Score = 2 });
            defaultRatings.Add(new UserRating { Id = 13, MovieId = 2, UserId = 4, Score = 3 });
            defaultRatings.Add(new UserRating { Id = 14, MovieId = 5, UserId = 4, Score = 1 });
            defaultRatings.Add(new UserRating { Id = 15, MovieId = 6, UserId = 4, Score = 5 });
            defaultRatings.Add(new UserRating { Id = 16, MovieId = 7, UserId = 5, Score = 3 });
            defaultRatings.Add(new UserRating { Id = 17, MovieId = 1, UserId = 5, Score = 3 });
            defaultRatings.Add(new UserRating { Id = 18, MovieId = 3, UserId = 5, Score = 1 });
            defaultRatings.Add(new UserRating { Id = 19, MovieId = 1, UserId = 2, Score = 4 });
            defaultRatings.Add(new UserRating { Id = 20, MovieId = 3, UserId = 2, Score = 4 });
            defaultRatings.Add(new UserRating { Id = 21, MovieId = 2, UserId = 2, Score = 4 });

            context.Movies.AddRange(defaultMovies);
            context.Users.AddRange(defaultUsers);
            context.UserRatings.AddRange(defaultRatings);

            base.Seed(context);
        }
    }
}