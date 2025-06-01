using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CinemaContext _context;

        public AddressRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Address;
        }

        public Address GetById(int id)
        {
            return _context.Address.SingleOrDefault(x => x.Id == id);
        }

        public Address Add(Address address)
        {
            address.CreatedDate = DateTime.Now;
            address.CreatedById = 1;

            _context.Address.Add(address);
            _context.SaveChanges();

            return address;
        }

        public void Update(Address address)
        {
            address.ModifiedDate = DateTime.Now;
            address.ModifiedById = 1;

            _context.Address.Update(address);
            _context.SaveChanges();
        }

        public void Delete(Address address)
        {
            _context.Address.Remove(address);
            _context.SaveChanges();
        }
    }
}
