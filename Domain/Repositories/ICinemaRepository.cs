using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ICinemaRepository
    {
        IEnumerable<Cinema> GetAll();
        Cinema GetById(int id);
        Cinema Add(Cinema cinema);
        void Delete(Cinema cinema);
        void Update(Cinema cinema);
    }
}
