using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _addressService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var address = _addressService.GetById(id);

            if (address == null)
                return StatusCode(404);

            return StatusCode(200, address);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddressDTO addressDTO)
        {
            if (string.IsNullOrEmpty(addressDTO.City) || string.IsNullOrEmpty(addressDTO.Street) || string.IsNullOrEmpty(addressDTO.BuildingNumber) || string.IsNullOrEmpty(addressDTO.PostalCode))
            {
                throw new Exception("Not all parameters were provided.");
            }

            _addressService.Add(addressDTO);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Update([FromBody] AddressDTO addressDTO)
        {
            if (string.IsNullOrEmpty(addressDTO.City) || string.IsNullOrEmpty(addressDTO.Street) || string.IsNullOrEmpty(addressDTO.BuildingNumber) || string.IsNullOrEmpty(addressDTO.PostalCode))
            {
                throw new Exception("Not all parameters were provided.");
            }

            _addressService.Update(addressDTO);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var addressToDelete = _addressService.GetById(id);

            if (addressToDelete == null)
                return StatusCode(404);

            _addressService.Delete(id);

            return StatusCode(204);
        }
    }
}
