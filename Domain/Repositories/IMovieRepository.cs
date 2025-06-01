using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        Movie Add(Movie movie);
        void Delete(Movie movie);
        void Update(Movie movie);
    }
}
