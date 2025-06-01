using Application.DTO;
using System.Collections.Generic;

namespace Application.Services
{
    public interface ICinemaService
    {
        IEnumerable<CinemaDTO> GetAll();
        CinemaDTO GetById(int id);
        CinemaDTO Add(CinemaDTO cinemaDTO);
        CinemaDTO Update(CinemaDTO cinemaDTO);
        void Delete(int id);
    }
}
