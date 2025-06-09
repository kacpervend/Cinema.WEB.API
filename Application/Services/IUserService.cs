using Application.DTO;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAll();
        UserDTO GetById(int id);
        UserDTO Add(CreateOrUpdateUserDTO createUserDTO);
        void Update(int id, CreateOrUpdateUserDTO updateUserDTO);
        void Delete(int id);
        string GenerateToken(LoginDTO loginDTO);
    }
}
