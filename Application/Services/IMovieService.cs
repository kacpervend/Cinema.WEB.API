using Application.DTO;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IMovieService
    {
        IEnumerable<MovieDTO> GetAll();
        MovieDTO GetById(int id);
        MovieDTO Add(MovieDTO movieDTO);
        MovieDTO Update(MovieDTO movieDTO);
        void Delete(int id);
    }
}
