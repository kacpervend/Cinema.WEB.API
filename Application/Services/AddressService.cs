using Application.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _repository = addressRepository;
            _mapper = mapper;
        }

        public IEnumerable<AddressDTO> GetAll()
        {
            var addresses = _repository.GetAll();

            return _mapper.Map<IEnumerable<AddressDTO>>(addresses);
        }

        public AddressDTO GetById(int id)
        {
            var address = _repository.GetById(id);
            return _mapper.Map<AddressDTO>(address);
        }

        public AddressDTO Add(CreateOrUpdateAddressDTO createAddressDTO)
        {
            var addressDTO = _mapper.Map<AddressDTO>(createAddressDTO);

            var address = _mapper.Map<Address>(addressDTO);

            _repository.Add(address);

            return addressDTO;
        }

        public void Update(int id, CreateOrUpdateAddressDTO updateAddressDTO)
        {
            var addressDTO = GetById(id);
            
            addressDTO.City = updateAddressDTO.City;
            addressDTO.Street = updateAddressDTO.Street;
            addressDTO.BuildingNumber = updateAddressDTO.BuildingNumber;
            addressDTO.ApartmentNumber = updateAddressDTO.ApartmentNumber;
            addressDTO.PostalCode = updateAddressDTO.PostalCode;
            addressDTO.Country = updateAddressDTO.Country;

            var address = _mapper.Map<Address>(addressDTO);

            _repository.Update(address);
        }

        public void Delete(int id)
        {
            var address = _repository.GetById(id);

            _repository.Delete(address);
        }
    }
}
