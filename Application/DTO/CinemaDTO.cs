using Domain.Entities;
using System.Collections.Generic;

namespace Application.DTO
{
    public class CinemaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
