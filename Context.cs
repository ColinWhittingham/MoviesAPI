namespace MoviesAPI
{
    using MoviesAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;


    public class Context : DbContext
    {
        public Context() : base("MovieDB")
        {
            Database.SetInitializer(new DBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany<UserRating>(m => m.Ratings)
                .WithRequired(r => r.Movie)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<User>()
                .HasMany<UserRating>(u => u.Ratings)
                .WithRequired(r => r.User)
                .HasForeignKey(r => r.UserId);
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRating> UserRatings { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}