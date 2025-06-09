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
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _movieService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var movie = _movieService.GetById(id);

            if (movie == null)
                return StatusCode(404);

            return StatusCode(200, movie);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateOrUpdateMovieDTO createMovieDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(400, ModelState);

            _movieService.Add(createMovieDTO);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CreateOrUpdateMovieDTO updateMovieDTO, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return StatusCode(400, ModelState);

            var movie = _movieService.GetById(id);

            if (movie == null)
                return StatusCode(404);

            _movieService.Update(id, updateMovieDTO);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _movieService.GetById(id);

            if (movieToDelete == null)
                return StatusCode(404);

            _movieService.Delete(id);

            return StatusCode(204);
        }
    }
}
