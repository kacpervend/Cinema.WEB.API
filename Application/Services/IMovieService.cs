using Application.DTO;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IMovieService
    {
        IEnumerable<MovieDTO> GetAll();
        MovieDTO GetById(int id);
        MovieDTO Add(CreateOrUpdateMovieDTO createMovieDTO);
        void Update(int id, CreateOrUpdateMovieDTO updateMovieDTO);
        void Delete(int id);
    }
}
