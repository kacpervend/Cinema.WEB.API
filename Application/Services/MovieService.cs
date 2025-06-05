using Application.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _repository = movieRepository;
            _mapper = mapper;
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            var movies = _repository.GetAll();

            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public MovieDTO GetById(int id)
        {
            var movie = _repository.GetById(id);
            return _mapper.Map<MovieDTO>(movie);
        }

        public MovieDTO Add(CreateOrUpdateMovieDTO createMovieDTO)
        {
            var movieDTO = _mapper.Map<MovieDTO>(createMovieDTO);

            var movie = _mapper.Map<Movie>(movieDTO);

            _repository.Add(movie);

            return movieDTO;
        }

        public void Update(int id, CreateOrUpdateMovieDTO updateMovieDTO)
        {
            var movieDTO = GetById(id);

            movieDTO.Title = updateMovieDTO.Title;
            movieDTO.Description = updateMovieDTO.Description;

            var movie = _mapper.Map<Movie>(movieDTO);

            _repository.Update(movie);
        }

        public void Delete(int id)
        {
            var movie = _repository.GetById(id);

            _repository.Delete(movie);
        }
    }
}
