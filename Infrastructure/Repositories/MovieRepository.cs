using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaContext _context;

        public MovieRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movie;
        }

        public Movie GetById(int id)
        {
            return _context.Movie.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public Movie Add(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();

            return movie;
        }

        public void Update(Movie movie)
        {
            _context.Movie.Update(movie);
            _context.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            _context.Movie.Remove(movie);
            _context.SaveChanges();
        }
    }
}
