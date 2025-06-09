using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Application.DTO;
using Application.Exceptions;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CinemaContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _config;

        public UserRepository(CinemaContext context, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _config = configuration;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User;
        }

        public User GetById(int id)
        {
            return _context.User.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public User Add(User user)
        {
            if (_context.User.Where(x => x.Login == user.Login).Any())
                throw new Application.Exceptions.InvalidOperationException($"User with login '{user.Login}' already exists!");

            if (!_context.Role.Any(x => x.Name == user.Role.Name))
            {
                throw new Application.Exceptions.InvalidOperationException($"Provided role '{user.Role.Name}' doesn't exist!");
            }
            else
            {
                user.Role = _context.Role.SingleOrDefault(x => x.Name == user.Role.Name);
            }

            _context.User.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(User user)
        {
            if (_context.User.Where(x => x.Login == user.Login).Any())
                throw new Application.Exceptions.InvalidOperationException($"User with login '{user.Login}' already exists!");

            if (!_context.Role.Any(x => x.Name == user.Role.Name))
            {
                throw new Application.Exceptions.InvalidOperationException($"Provided role '{user.Role.Name}' doesn't exist!");
            }
            else
            {
                user.Role = _context.Role.SingleOrDefault(x => x.Name == user.Role.Name);
            }

            _context.User.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public User GetByLogin(string login)
        {
            return _context.User.AsNoTracking().Include(x => x.Role).SingleOrDefault(x => x.Login == login);
        }

        public string GenerateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:JwtKey"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(int.Parse(_config["Authentication:JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _config["Authentication:JwtIssuer"],
                _config["Authentication:JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}
