using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private static readonly ISet<Address> _addresses = new HashSet<Address>()
        {
            new Address(1, DateTime.Now, 2, "Kraków", "Warszawska", "15", "2", "30-501", "PL"),
            new Address(2, new DateTime(2025, 1, 3), 2, "Kraków", "Wrocławska", "2", null, "30-541", "PL"),
            new Address(3, new DateTime(2025, 2, 8), 2, "Warszawa", "Krakowska", "20", "3", "10-302", "PL"),
        };

        public IEnumerable<Address> GetAll()
        {
            return _addresses;
        }

        public Address GetById(int id)
        {
            return _addresses.SingleOrDefault(x => x.Id == id);
        }

        public Address Add(Address address)
        {
            address.Id = _addresses.Count + 1;
            address.CreatedDate = DateTime.Now;
            address.CreatedById = 1;

            _addresses.Add(address);

            return address;
        }

        public void Update(Address address)
        {
            address.ModifiedDate = DateTime.Now;
            address.ModifiedById = 1;
        }

        public void Delete(Address address)
        {
            _addresses.Remove(address);
        }
    }
}
