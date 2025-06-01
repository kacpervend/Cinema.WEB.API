using Application.DTO;
using AutoMapper;
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
    }
}
