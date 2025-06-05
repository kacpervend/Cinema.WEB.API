using Application.DTO;
using System.Collections.Generic;

namespace Application.Services
{
    public interface ICinemaService
    {
        IEnumerable<CinemaDTO> GetAll();
        CinemaDTO GetById(int id);
        CinemaDTO Add(CreateOrUpdateCinemaDTO createCinemaDTO);
        void Update(int id, CreateOrUpdateCinemaDTO updateCinemaDTO);
        void Delete(int id);
    }
}
