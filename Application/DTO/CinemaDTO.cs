using Domain.Entities;
using System.Collections.Generic;

namespace Application.DTO
{
    public class CinemaDTO
    {
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
