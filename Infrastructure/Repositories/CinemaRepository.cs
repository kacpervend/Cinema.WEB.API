using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
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
            return _context.Cinema.SingleOrDefault(x => x.Id == id);
        }

        public Cinema Add(Cinema cinema)
        {
            cinema.CreatedDate = DateTime.Now;
            cinema.CreatedById = 1;

            _context.Cinema.Add(cinema);
            _context.SaveChanges();

            return cinema;
        }

        public void Update(Cinema cinema)
        {
            cinema.ModifiedDate = DateTime.Now;
            cinema.ModifiedById = 1;

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
