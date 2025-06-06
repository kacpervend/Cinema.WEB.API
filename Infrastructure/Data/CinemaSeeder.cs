using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CinemaSeeder
    {
        private readonly CinemaContext _context;

        public CinemaSeeder(CinemaContext context)
        {
            _context = context; 
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Cinema.Any())
                {
                    try
                    {
                        _context.Cinema.AddRange(GetCinemas());
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failded to seed data into database. Reason: {ex.Message}");
                    }
                }

                if (!_context.Movie.Any())
                {
                    try
                    {
                        _context.Movie.AddRange(GetMovies());
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failded to seed data into database. Reason: {ex.Message}");
                    }
                }

                if (!_context.Address.Any())
                {
                    try
                    {
                        _context.Address.AddRange(GetAddresses());
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failded to seed data into database. Reason: {ex.Message}");
                    }
                }
            }
        }

        private IEnumerable<Cinema> GetCinemas()
        {
            return new List<Cinema>()
            {
                new Cinema()
                {
                    Name = "Cinema City",
                    Movies = new List<Movie>()
                    {
                        new Movie()
                        {
                            Title = "Scooby Doo",
                            Description = "Some description"
                        },
                        new Movie()
                        {
                            Title = "Tom & Jerry",
                            Description = "Some description"
                        }
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Ulicowa",
                        BuildingNumber = "12",
                        ApartmentNumber = "2",
                        PostalCode = "30-555",
                        Country = "Polska"
                    }
                },
                new Cinema()
                {
                    Name = "Multikino",
                    Movies = new List<Movie>()
                    {
                        new Movie()
                        {
                            Title = "Shrek",
                            Description = "Some description"
                        },
                        new Movie()
                        {
                            Title = "The Lion King",
                            Description = "Some description"
                        }
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Warszawska",
                        BuildingNumber = "15",
                        PostalCode = "30-555",
                        Country = "Polska"
                    }
                }
            };
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie()
                {
                    Title = "Scooby Doo",
                    Description = "Some description"
                },
                new Movie()
                {
                    Title = "Tom & Jerry",
                    Description = "Some description"
                },
                new Movie()
                {
                    Title = "Shrek",
                    Description = "Some description"
                },
                new Movie()
                {
                    Title = "The Lion King",
                    Description = "Some description"
                }
            };
        }

        private IEnumerable<Address> GetAddresses()
        {
            return new List<Address>()
            {
                new Address()
                {
                    City = "Kraków",
                    Street = "Ulicowa",
                    BuildingNumber = "12",
                    ApartmentNumber = "2",
                    PostalCode = "30-555",
                    Country = "Polska"
                },
                new Address()
                {
                    City = "Kraków",
                    Street = "Warszawska",
                    BuildingNumber = "15",
                    PostalCode = "30-555",
                    Country = "Polska"
                }
            };
        }
    }
}
