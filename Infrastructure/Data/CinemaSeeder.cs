using Domain.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly IPasswordHasher<User> _passwordHasher;

        public CinemaSeeder(CinemaContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
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

                if (!_context.Role.Any())
                {
                    try
                    {
                        _context.Role.AddRange(GetRoles());
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failded to seed data into database. Reason: {ex.Message}");
                    }
                }

                if (!_context.User.Any())
                {
                    try
                    {
                        _context.User.AddRange(GetUsers());
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

        private IEnumerable<Role> GetRoles()
        {
            return new List<Role>()
            {
                new Role()
                {
                    Name = "admin"
                },
                new Role()
                {
                    Name = "manager"
                },
                new Role()
                {
                    Name = "user"
                }
            };
        }

        private IEnumerable<User> GetUsers()
        {
            var user = new User();

            user.Login = "admin";
            user.Password = _passwordHasher.HashPassword(user, "123456");
            user.FirstName = "admin";
            user.LastName = "admin";
            user.Role = _context.Role.SingleOrDefault(x => x.Name == "admin");
            return new List<User>() { user };
        }
    }
}
