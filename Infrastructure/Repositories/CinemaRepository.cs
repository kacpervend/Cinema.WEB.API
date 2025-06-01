using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Infrastructure.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private static readonly ISet<Cinema> _cinemas = new HashSet<Cinema>()
        {
            new Cinema(1, new DateTime(2021, 3, 1), 2, "Cinema City", _movies, _addresses.FirstOrDefault(x => x.Id == 1)),
            new Cinema(2, new DateTime(2023, 10, 14), 2, "Helios", _movies, _addresses.FirstOrDefault(x => x.Id == 2)),
            new Cinema(3, new DateTime(2025, 2, 6), 2, "Multikino", _movies, _addresses.FirstOrDefault(x => x.Id == 3))
        };

        private static readonly List<Address> _addresses = new List<Address>()
        {
            new Address(1, DateTime.Now, 2, "Cracow", "Warszawska", "15", "2", "30-501", "PL"),
            new Address(2, new DateTime(2025, 1, 3), 2, "Kraków", "Wrocławska", "2", null, "30-541", "PL"),
            new Address(3, new DateTime(2025, 2, 8), 2, "Warszawa", "Krakowska", "20", "3", "10-302", "PL"),
        };

        private static readonly List<Movie> _movies = new List<Movie>()
        {
            new Movie(1, DateTime.Now, 2, "Time", "Lorem ipsum"),
            new Movie(2, new DateTime(2020, 10, 1), 2, "Shrek", "Lorem ipsum"),
            new Movie(3, new DateTime(2021, 8, 1), 2, "Scooby Doo", "Lorem ipsum"),
        };

        public IEnumerable<Cinema> GetAll()
        {
            return _cinemas;
        }

        public Cinema GetById(int id)
        {
            return _cinemas.SingleOrDefault(x => x.Id == id);
        }

        public Cinema Add(Cinema cinema)
        {
            cinema.Id = _cinemas.Count + 1;
            cinema.CreatedDate = DateTime.Now;
            cinema.CreatedById = 1;

            _cinemas.Add(cinema);

            return cinema;
        }

        public void Update(Cinema cinema)
        {
            cinema.ModifiedDate = DateTime.Now;
            cinema.ModifiedById = 1;
        }

        public void Delete(Cinema cinema)
        {
            _cinemas.Remove(cinema);
        }
    }
}
