using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        
        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _cinemaService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cinema = _cinemaService.GetById(id);

            if (cinema == null)
                return StatusCode(404);

            return StatusCode(200, cinema);
        }

        [HttpPost]
        public IActionResult Add([FromBody]CinemaDTO cinemaDTO)
        {
            if (string.IsNullOrEmpty(cinemaDTO.Name) || !cinemaDTO.Movies.Any()) 
            {
                throw new Exception("Not all parameters were provided.");
            }

            _cinemaService.Add(cinemaDTO);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CinemaDTO cinemaDTO)
        {
            if (string.IsNullOrEmpty(cinemaDTO.Name))
            {
                throw new Exception("Parameter 'Name' was not provided.");
            }

            _cinemaService.Update(cinemaDTO);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cinemaToDelete = _cinemaService.GetById(id);

            if (cinemaToDelete == null)
                return StatusCode(404);

            _cinemaService.Delete(id);

            return StatusCode(204);
        }
    }
}
