using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult Get(int id)
        {
            var movie = _movieService.GetById(id);

            if (movie == null)
                return StatusCode(404);

            return StatusCode(200, movie);
        }

        [HttpPost]
        public IActionResult Add([FromBody] MovieDTO movieDTO)
        {
            if (string.IsNullOrEmpty(movieDTO.Title))
            {
                throw new Exception("Parameter 'Title' was not provided.");
            }

            _movieService.Add(movieDTO);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Update([FromBody] MovieDTO movieDTO)
        {
            if (string.IsNullOrEmpty(movieDTO.Title))
            {
                throw new Exception("Parameter 'Title' was not provided.");
            }

            _movieService.Update(movieDTO);

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
