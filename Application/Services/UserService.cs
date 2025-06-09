using Application.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Application.Exceptions;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository movieRepository, IMapper mapper , IPasswordHasher<User> passwordHasher)
        {
            _repository = movieRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = _repository.GetAll();

            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO GetById(int id)
        {
            var user = _repository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO Add(CreateOrUpdateUserDTO createUserDTO)
        {
            var userDTO = _mapper.Map<UserDTO>(createUserDTO);

            var user = _mapper.Map<User>(userDTO);

            var hashedPassword = _passwordHasher.HashPassword(user, user.Password);

            user.Password = hashedPassword;

            _repository.Add(user);

            return userDTO;
        }

        public void Update(int id, CreateOrUpdateUserDTO updateUserDTO)
        {
            var userDTO = GetById(id);

            userDTO.Login = updateUserDTO.Login;
            userDTO.Password = updateUserDTO.Password;
            userDTO.FirstName = updateUserDTO.FirstName;
            userDTO.LastName = updateUserDTO.LastName;
            userDTO.Role = _mapper.Map<RoleDTO>(updateUserDTO.Role);

            var user = _mapper.Map<User>(userDTO);

            var hashedPassword = _passwordHasher.HashPassword(user, user.Password);

            user.Password = hashedPassword;

            _repository.Update(user);
        }

        public void Delete(int id)
        {
            var user = _repository.GetById(id);

            _repository.Delete(user);
        }

        public string GenerateToken(LoginDTO loginDTO)
        {
            var user = _repository.GetByLogin(loginDTO.Login);

            if (user == null)
                throw new NotFoundException("User with provided login doesn't exist!");

            var verifyResult = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDTO.Password);

            if (verifyResult == PasswordVerificationResult.Failed)
                throw new UnauthorizedException("Invalid username or password!");

            return _repository.GenerateToken(user);
        }
    }
}
