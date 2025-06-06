using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateOrUpdateCinemaDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<CreateOrUpdateMovieDTO>? Movies { get; set; }
        [Required]
        public CreateOrUpdateAddressDTO Address { get; set; }
    }
}
