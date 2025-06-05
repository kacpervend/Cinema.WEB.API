using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Infrastructure.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly CinemaContext _context;

        public CinemaRepository(CinemaContext context)
        {
            _context = context;
        }

        public IEnumerable<Cinema> GetAll()
        {
            return _context.Cinema;
        }

        public Cinema GetById(int id)
        {
            return _context.Cinema.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public Cinema Add(Cinema cinema)
        {
            _context.Cinema.Add(cinema);
            _context.SaveChanges();

            return cinema;
        }

        public void Update(Cinema cinema)
        {
            _context.Cinema.Update(cinema);
            _context.SaveChanges();
        }

        public void Delete(Cinema cinema)
        {
            _context.Cinema.Remove(cinema);
            _context.SaveChanges();
        }
    }
}
