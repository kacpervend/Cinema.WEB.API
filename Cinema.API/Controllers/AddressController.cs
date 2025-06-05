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
        public IActionResult Get([FromRoute] int id)
        {
            var address = _addressService.GetById(id);

            if (address == null)
                return StatusCode(404);

            return StatusCode(200, address);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateOrUpdateAddressDTO createAddressDTO)
        {
            _addressService.Add(createAddressDTO);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CreateOrUpdateAddressDTO updateAddressDTO, [FromRoute] int id)
        {
            var address = _addressService.GetById(id);

            if (address == null)
                return StatusCode(404);

            _addressService.Update(id, updateAddressDTO);

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
