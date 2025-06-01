using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll();
        Address GetById(int id);
        Address Add(Address address);
        void Delete(Address address);
        void Update(Address address);
    }
}
