using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private static readonly ISet<Movie> _movies = new HashSet<Movie>()
        {
            new Movie(1, DateTime.Now, 2, "Time", "Lorem ipsum"),
            new Movie(2, new DateTime(2020, 10, 1), 2, "Shrek", "Lorem ipsum"),
            new Movie(3, new DateTime(2021, 8, 1), 2, "Scooby Doo", "Lorem ipsum"),
        };

        public IEnumerable<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetById(int id)
        {
            return _movies.SingleOrDefault(x => x.Id == id);
        }

        public Movie Add(Movie movie)
        {
            movie.Id = _movies.Count + 1;
            movie.CreatedDate = DateTime.Now;
            movie.CreatedById = 1;

            _movies.Add(movie);

            return movie;
        }

        public void Update(Movie movie)
        {
            movie.ModifiedDate = DateTime.Now;
            movie.ModifiedById = 1;
        }

        public void Delete(Movie movie)
        {
            _movies.Remove(movie);
        }
    }
}
