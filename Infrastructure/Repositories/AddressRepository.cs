﻿using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
            return _context.Address.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public Address Add(Address address)
        {
            _context.Address.Add(address);
            _context.SaveChanges();

            return address;
        }

        public void Update(Address address)
        {
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
