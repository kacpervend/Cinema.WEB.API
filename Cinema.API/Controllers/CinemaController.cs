using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public IActionResult Get([FromRoute] int id)
        {
            var cinema = _cinemaService.GetById(id);

            if (cinema == null)
                return StatusCode(404);

            return StatusCode(200, cinema);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateOrUpdateCinemaDTO createCinemaDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(400, ModelState);

            _cinemaService.Add(createCinemaDTO);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CreateOrUpdateCinemaDTO updateCinemaDTO, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return StatusCode(400, ModelState);

            var cinema = _cinemaService.GetById(id);

            if (cinema == null)
                return StatusCode(404);

            _cinemaService.Update(id, updateCinemaDTO);

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
