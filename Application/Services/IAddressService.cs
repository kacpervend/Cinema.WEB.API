using Application.DTO;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IAddressService
    {
        IEnumerable<AddressDTO> GetAll();
        AddressDTO GetById(int id);
        AddressDTO Add(CreateOrUpdateAddressDTO createAddressDTO);
        void Update(int id, CreateOrUpdateAddressDTO updateAddressDTO);
        void Delete(int id);
    }
}
