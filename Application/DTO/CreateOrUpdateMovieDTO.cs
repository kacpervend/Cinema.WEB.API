using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateOrUpdateMovieDTO
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
